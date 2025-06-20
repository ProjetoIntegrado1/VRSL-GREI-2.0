using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Vector3 pendingPosition;
    private Quaternion pendingRotation;
    private bool hasPendingWarp = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// Inicia warp na próxima cena "Treinamento", sem afetar spawn inicial.
    /// </summary>
    public void IrParaNotebook()
    {
        const string targetScene = "Treinamento";
        pendingPosition = new Vector3(10.65f, 0.99f, 9.827f);
        pendingRotation = Quaternion.Euler(0f, -155f, 0f);

        if (SceneManager.GetActiveScene().name == targetScene)
        {
            ApplyWarp();
        }
        else
        {
            hasPendingWarp = true;
            SceneManager.LoadScene(targetScene);
        }
    }

    public void IrParaPatio()
    {
        const string targetScene = "Treinamento";
        pendingPosition = new Vector3(40.04f, 0.99f, 24.56f);
        pendingRotation = Quaternion.Euler(0f, -98.043f, 0f);

        if (SceneManager.GetActiveScene().name == targetScene)
        {
            ApplyWarp();
        }
        else
        {
            SceneManager.LoadScene(targetScene);
        }
    }

    public void IrParaTransformador()
    {
        const string targetScene = "Transformador";
        pendingPosition = new Vector3(32.61f, 0.99f, 34.73f);
        pendingRotation = Quaternion.Euler(0f, -5.447f, 0f);

        if (SceneManager.GetActiveScene().name == targetScene)
        {
            ApplyWarp();
        }
        else
        {
            SceneManager.LoadScene(targetScene);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!hasPendingWarp || scene.name != "Treinamento")
            return;

        // Invoca ApplyWarp no próximo frame
        Invoke(nameof(ApplyWarp), 0f);
        hasPendingWarp = false;
    }

    private void ApplyWarp()
    {
        var fpc = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        if (fpc == null)
        {
            Debug.LogError("FirstPersonController não encontrado! Warp cancelado.");
            return;
        }
        else
        {
            fpc.Warp(pendingPosition, pendingRotation);
        }
    }
}
