using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // posição e rotação pendentes para warp após load
    private Vector3 pendingPosition;
    private Quaternion pendingRotation;
    private bool hasPendingWarp = false;

    void Awake()
    {
        // singleton
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

    public void IrParaNotebook()
    {
        const string targetScene = "Treinamento";
        
        pendingPosition = new Vector3(10.65f, 0.99f, 9.827f);
        pendingRotation = Quaternion.Euler(0f, -155f, 0f);

        if (SceneManager.GetActiveScene().name == targetScene)
        {
            ExecuteWarp();
        }
        else
        {
            hasPendingWarp = true;
            // carregamento assíncrono
            SceneManager.LoadSceneAsync(targetScene);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!hasPendingWarp || scene.name != "Treinamento")
            return;

        ExecuteWarp();
        hasPendingWarp = false;
    }

    private void ExecuteWarp()
    {
        StartCoroutine(DelayedWarp());
    }

    private IEnumerator DelayedWarp()
    {
        // espera um frame para garantir que todos os objetos da cena foram inicializados
        yield return null;

        // busca o FirstPersonController na cena atual
        var fpc = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        if (fpc == null)
        {
            Debug.LogError("FirstPersonController não encontrado após carregar a cena!");
            yield break;
        }

        fpc.Warp(pendingPosition, pendingRotation);
    }
}
