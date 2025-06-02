using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class MenuSystem : MonoBehaviour
{
    public enum MenuState { Gameplay, Pause, OtherMenu }

    [Header("Configurações Principais")]
    public KeyCode pauseKey = KeyCode.Escape;
    public AudioClip buttonSound;
    public GameObject pauseMenu;      // Menu de pausa (um dos 50, mas podemos tratá-lo como referência especial)
    public GameObject crosshair;

    [Header("Referências")]
    public FirstPersonController fpsController;

    // **Lista/array para armazenar todos os menus encontrados pela Tag "Menu"**
    private GameObject[] allMenus;

    private AudioSource audioSource;
    private MenuState currentState = MenuState.Gameplay;
    private Stack<GameObject> menuStack = new Stack<GameObject>();

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;

        // 1) Carrega todos os GameObjects marcados com Tag “Menu”
        allMenus = GameObject.FindGameObjectsWithTag("Menu");

        // 2) Desativa TODOS eles no início
        foreach (GameObject m in allMenus)
        {
            m.SetActive(false);
        }

        // Se o pauseMenu estiver atribuído, certifica que ele está inativo
        if (pauseMenu != null)
            pauseMenu.SetActive(false);

        // Garante que a crosshair comece ativa e cursor bloqueado
        if (crosshair != null)
            crosshair.SetActive(true);

        LockCursor(true);
    }

    void Update()
    {
        HandlePauseInput();
    }

    private void HandlePauseInput()
    {
        if (!Input.GetKeyDown(pauseKey)) return;

        PlayButtonSound();

        if (menuStack.Count > 0)
        {
            // Já existe ao menos um menu aberto: fecha o topo da pilha
            CloseTopMenu();
        }
        else
        {
            // Não há menus na pilha: abre o menu de pausa
            if (currentState == MenuState.Gameplay)
            {
                OpenMenu(pauseMenu, true);
                currentState = MenuState.Pause;
            }
            else
            {
                // Caso extremo: estava com outro estado diferente de Gameplay, fecha tudo
                CloseAllMenus();
            }
        }
    }

    /// <summary>
    /// Abre um menu “qualquer” (GameObject) e empilha ele. 
    /// Se for o primeiro menu, pausa o jogo ou apenas “trava cursor” caso pauseGame = false.
    /// </summary>
    public void OpenMenu(GameObject menu, bool pauseGame)
    {
        if (menu == null) return;

        // Se outro menu já estava ativo, desativa-o antes de empilhar o novo
        if (menuStack.Count > 0)
        {
            menuStack.Peek().SetActive(false);
        }

        // Ativa o novo e põe na pilha
        menu.SetActive(true);
        menuStack.Push(menu);

        // Se for o primeiro menu da pilha, decide o estado do jogo
        if (menuStack.Count == 1)
        {
            if (pauseGame)
            {
                PauseGame();
                currentState = MenuState.Pause;
            }
            else
            {
                currentState = MenuState.OtherMenu;
                LockCursor(false);
                if (crosshair != null)
                    crosshair.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Fecha o topo da pilha (último menu aberto). 
    /// Reativa o menu que ficou logo abaixo, se existir; senão volta ao gameplay normal.
    /// </summary>
    public void CloseTopMenu()
    {
        if (menuStack.Count == 0) return;

        GameObject topMenu = menuStack.Pop();
        topMenu.SetActive(false);

        if (menuStack.Count > 0)
        {
            menuStack.Peek().SetActive(true);
        }
        else
        {
            // Se não sobrou nenhum menu na pilha, volta ao gameplay
            UnpauseGame();
            LockCursor(true);
            if (crosshair != null)
                crosshair.SetActive(true);
            currentState = MenuState.Gameplay;
        }
    }

    /// <summary>
    /// Fecha absolutamente todos os menus, limpando a pilha.
    /// </summary>
    public void CloseAllMenus()
    {
        while (menuStack.Count > 0)
        {
            GameObject m = menuStack.Pop();
            m.SetActive(false);
        }

        UnpauseGame();
        LockCursor(true);
        if (crosshair != null)
            crosshair.SetActive(true);
        currentState = MenuState.Gameplay;
    }

    /// <summary>
    /// Retorna true se houver ao menos um menu aberto (pilha não vazia).
    /// </summary>
    public bool MenuEstaAberto()
    {
        return menuStack.Count > 0;
    }

    /// <summary>
    /// Fecha/Abre um menu específico (alternando). 
    /// Se o menu já está no topo da pilha, fecha-o; senão abre em cima da pilha.
    /// </summary>
    public void AlternarMenuPorObjeto(GameObject menuObjeto)
    {
        if (menuObjeto == null) return;

        if (menuStack.Count > 0 && menuStack.Peek() == menuObjeto)
        {
            CloseTopMenu();
        }
        else
        {
            // Ao abrir via alternar, presumimos que pausa o jogo (pauseGame = true)
            OpenMenu(menuObjeto, true);
        }
    }

    /// <summary>
    /// Retorna true se o menu específico estiver exatamente no topo da pilha.
    /// </summary>
    public bool MenuEspecificoEstaAberto(GameObject menu)
    {
        return menuStack.Count > 0 && menuStack.Peek() == menu;
    }

    private void PlayButtonSound()
    {
        if (buttonSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        LockCursor(false);
        if (fpsController != null)
        {
            fpsController.m_MouseLook.SetCursorLock(false);
            fpsController.m_MouseLook.XSensitivity = 0;
            fpsController.m_MouseLook.YSensitivity = 0;
        }
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
        LockCursor(true);
        if (fpsController != null)
        {
            fpsController.m_MouseLook.SetCursorLock(true);
            fpsController.m_MouseLook.XSensitivity = 2;
            fpsController.m_MouseLook.YSensitivity = 2;
        }
    }

    private void LockCursor(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }
}
