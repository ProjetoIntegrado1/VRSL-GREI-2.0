using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MenuSystem : MonoBehaviour
{
    public enum MenuState { Crosshair, TabletMenu, OtherMenu, Interaction }

    [Header("Configurações Principais")]
    public KeyCode pauseKey = KeyCode.Escape;
    public AudioClip buttonSound;
    public GameObject pauseMenu;
    public GameObject diagramaMenu;
    public GameObject crosshair;

    [Header("Referências")]
    public FirstPersonController fpsController;

    private AudioSource audioSource;
    public MenuState currentState = MenuState.Crosshair;

    public bool allOutlinesEnabled = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;

        foreach (var m in GameObject.FindGameObjectsWithTag("Menu"))
            m.SetActive(false);
        foreach (var mi in GameObject.FindGameObjectsWithTag("MenuInteraction"))
            mi.SetActive(false);

        if (pauseMenu != null) pauseMenu.SetActive(false);
        if (diagramaMenu != null) diagramaMenu.SetActive(false);

        foreach (var cam in GameObject.FindGameObjectsWithTag("Cameras")) cam.SetActive(false);

        if (fpsController != null)
            fpsController.gameObject.SetActive(true);
        if (crosshair != null)
            crosshair.SetActive(true);

        LockCursor(true);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(pauseKey))
        {
            PlayButtonSound();

            if (pauseMenu != null && pauseMenu.activeSelf)
            {
                CloseMenu(pauseMenu);
                return;
            }

            if (IsMenusOpen())
            {
                CloseAllMenus();
                return;
            }

            OpenMenu(pauseMenu, true);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PlayButtonSound();
            if (diagramaMenu != null && diagramaMenu.activeSelf)
            {
                CloseMenu(diagramaMenu);
            }
            else if (IsMenusOpen())
            {
                CloseAllMenus();
                OpenMenu(diagramaMenu, false);
            }
            else
            {
                OpenMenu(diagramaMenu, false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
            ToggleAllOutlines();

        HandleAltRightToggle();

        if (crosshair != null)
        {
            //Debug.Log(currentState);
            bool anyOpen = IsMenusOpen();
            crosshair.SetActive(!anyOpen || currentState == MenuState.TabletMenu);
        }
    }

    public void OpenMenu(GameObject menu, bool isTablet)
    {
        if (menu == null) return;
        menu.SetActive(true);
        PauseGame();

        if (menu.CompareTag("MenuInteraction"))
            currentState = MenuState.Interaction;
        else
            currentState = isTablet ? MenuState.TabletMenu : MenuState.OtherMenu;
    }

    private void CloseMenu(GameObject menu)
    {
        if (menu == null) return;
        menu.SetActive(false);
        ResumeGame();
    }

    private void HandleAltRightToggle()
    {
        if (currentState != MenuState.Crosshair)
            return;

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftAlt))
        {
            PlayButtonSound();
            if (Time.timeScale == 0f)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void CloseAllMenus()
    {
        foreach (var m in GameObject.FindGameObjectsWithTag("Menu"))
            m.SetActive(false);

        foreach (var mi in GameObject.FindGameObjectsWithTag("MenuInteraction"))
            mi.SetActive(false);

        if (pauseMenu != null) pauseMenu.SetActive(false);
        if (diagramaMenu != null) diagramaMenu.SetActive(false);

        foreach (var cam in GameObject.FindGameObjectsWithTag("Cameras"))
            cam.SetActive(false);

        if (fpsController != null)
            fpsController.gameObject.SetActive(true);

        ResumeGame();
    }

    public bool IsMenusOpen()
    {
        foreach (var m in GameObject.FindGameObjectsWithTag("Menu"))
            if (m.activeSelf) return true;

        foreach (var mi in GameObject.FindGameObjectsWithTag("MenuInteraction"))
        {
            if (mi.activeSelf)
            {
                currentState = MenuState.Interaction;
                return true;  
            }
        }


        if (pauseMenu != null && pauseMenu.activeSelf) return true;
        if (diagramaMenu != null && diagramaMenu.activeSelf) return true;
        return false;
    }

    private void PlayButtonSound()
    {
        if (buttonSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonSound);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        if (fpsController != null)
        {
            fpsController.m_MouseLook.SetCursorLock(false);
            fpsController.m_MouseLook.XSensitivity = 0f;
            fpsController.m_MouseLook.YSensitivity = 0f;
        }
        LockCursor(false);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        if (fpsController != null)
        {
            fpsController.m_MouseLook.SetCursorLock(true);
            fpsController.m_MouseLook.XSensitivity = 2f;
            fpsController.m_MouseLook.YSensitivity = 2f;
        }
        LockCursor(true);
        currentState = MenuState.Crosshair;
    }

    private void LockCursor(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }

    public void ToggleAllOutlines()
    {
        var outlines = FindObjectsOfType<Outline>();
        allOutlinesEnabled = !allOutlinesEnabled;
        foreach (var o in outlines) o.enabled = allOutlinesEnabled;
    }

    // funções publicas para botões
    public void SetStateCrosshair()
    {
        CloseAllMenus();
    }

    public void SetStateTabletMenu()
    {
        PlayButtonSound();
        if (pauseMenu != null)
        {
            CloseAllMenus();
            OpenMenu(pauseMenu, true);
        }
    }

    public void SetStateOtherMenu(GameObject menu)
    {
        PlayButtonSound();
        if (menu != null)
        {
            CloseAllMenus();
            OpenMenu(menu, false);
        }
    }

    public void ButtonCloseOrAllClose(GameObject objToClose)
    {
        var cams = GameObject.FindGameObjectsWithTag("Cameras");
        int activeCount = 0;
        foreach (var cam in cams)
            if (cam.activeSelf) activeCount++;

        Debug.Log(activeCount);

        if (activeCount > 0)
        {
            objToClose?.SetActive(false);
        }
        else
        {
            CloseAllMenus();
        }
    }

    public void OnBtnIrParaPatio() => GameManager.Instance.IrParaPatio();
    public void OnBtnIrParaNotebook() => GameManager.Instance.IrParaNotebook();
    public void OnBtnIrParaTransformador() => GameManager.Instance.IrParaTransformador();
}
