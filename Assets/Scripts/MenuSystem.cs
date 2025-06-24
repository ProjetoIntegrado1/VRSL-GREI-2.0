using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MenuSystem : MonoBehaviour
{
    public enum MenuState { Crosshair, TabletMenu, OtherMenu }
    
    [Header("Configurações Principais")]
    public KeyCode pauseKey = KeyCode.Escape;
    public AudioClip buttonSound;
    public GameObject pauseMenu;
    public GameObject crosshair;

    [Header("Referências")]
    public FirstPersonController fpsController;

    private AudioSource audioSource;
    private MenuState currentState = MenuState.Crosshair;

    private bool cursosIsLock = true;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;

        // Fecha todos os menus (qualquer objeto com tag "Menu") no início
        GameObject[] taggedMenus = GameObject.FindGameObjectsWithTag("Menu");
        foreach (GameObject m in taggedMenus)
        {
            if (m.activeSelf)
                m.SetActive(false);
        }

        // Garante que o pauseMenu comece inativo (caso não tenha tag "Menu")
        if (pauseMenu != null && pauseMenu.activeSelf)
            pauseMenu.SetActive(false);

        // Desliga todas as câmeras com tag "Cameras" no início
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("Cameras");
        foreach (GameObject cam in cameras)
        {
            if (cam.activeSelf)
                cam.SetActive(false);
        }

        // Reativa o FPSController (caso tenha sido desativado)
        if (fpsController != null && !fpsController.gameObject.activeSelf)
            fpsController.gameObject.SetActive(true);

        // Deixa apenas a crosshair ativa e trava cursor
        if (crosshair != null)
            crosshair.SetActive(true);

        LockCursor(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            PlayButtonSound();

            if (IsMenusOpen())
            {
                CloseAllMenus();
            }
            else if (currentState == MenuState.Crosshair)
            {
                OpenMenu(pauseMenu, true);
            }
        }

        // Chama nossa função de toggle Alt-esq / Botão direito
        HandleAltRightToggle();
    }

    private void HandleAltRightToggle()
    {
        // Detecta clique direito do mouse OU Alt esquerdo
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftAlt))
        {
            PlayButtonSound();

            // Se já está pausado (Time.timeScale == 0) --> despausa
            if (Time.timeScale == 0f)
            {
                ResumeGame();   // reativa o jogo, trava cursor, reseta sensitivities, atualiza currentState
            }
            else // senão, pausa
            {
                PauseGame();    // pausa o jogo, libera cursor, zera sensitivities
            }
        }
    }

    public void EscMenu()
    {
        PlayButtonSound();
        if (IsMenusOpen())
        {
            CloseAllMenus();
        }
        else if (currentState == MenuState.Crosshair)
        {
            OpenMenu(pauseMenu, true);
        }
    }

    public void OpenMenu(GameObject menu, bool pausar)
    {
        if (menu == null) return;

        menu.SetActive(true);

        if (pausar)
        {
            PauseGame();
            currentState = MenuState.TabletMenu;
        }
        else
        {
            currentState = MenuState.OtherMenu;
            LockCursor(false);
        }
    }

    public void CloseAllMenus()
    {
        // 1) Fecha todos os objetos ativos com tag "Menu"
        GameObject[] taggedMenus = GameObject.FindGameObjectsWithTag("Menu");
        foreach (GameObject m in taggedMenus)
        {
            if (m.activeSelf)
                m.SetActive(false);
        }

        // 2) Garante que o pauseMenu seja fechado também
        if (pauseMenu != null && pauseMenu.activeSelf)
            pauseMenu.SetActive(false);

        // 3) Desliga todas as câmeras com tag "Cameras"
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("Cameras");
        foreach (GameObject cam in cameras)
        {
            if (cam.activeSelf)
                cam.SetActive(false);
        }

        // 4) Reativa o FPSController (caso tenha sido desativado por algum menu)
        if (fpsController != null && !fpsController.gameObject.activeSelf)
            fpsController.gameObject.SetActive(true);

        // 5) Deixa a crosshair ativa
        if (crosshair != null)
            crosshair.SetActive(true);

        // 6) Inicia coroutine para re-travar o cursor no próximo frame
        ResumeGame();
    }

    public bool IsMenusOpen()
    {
        // Se qualquer objeto com tag "Menu" estiver ativo, retorna true
        GameObject[] taggedMenus = GameObject.FindGameObjectsWithTag("Menu");
        foreach (GameObject m in taggedMenus)
        {
            if (m.activeSelf)
                return true;
        }

        // Também verifica pauseMenu
        if (pauseMenu != null && pauseMenu.activeSelf)
            return true;

        return false;
    }

    private void PlayButtonSound()
    {
        if (buttonSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonSound);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        
        if (fpsController != null)
        {
            fpsController.m_MouseLook.SetCursorLock(false);
            fpsController.m_MouseLook.XSensitivity = 0;
            fpsController.m_MouseLook.YSensitivity = 0;
        }
        LockCursor(false);
    }

    private void ResumeGame()
    {

        Time.timeScale = 1;
        
        if (fpsController != null)
        {
            fpsController.m_MouseLook.SetCursorLock(true);
            fpsController.m_MouseLook.XSensitivity = 2;
            fpsController.m_MouseLook.YSensitivity = 2;
        }
        LockCursor(true);
        currentState = MenuState.Crosshair;
    }

    private void LockCursor(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }
}
