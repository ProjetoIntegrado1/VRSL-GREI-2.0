using UnityEngine;

public abstract class Interagivel : MonoBehaviour
{
    [Header("Configurações Base")]
    public float distanciaInteracao = 2f;
    public KeyCode teclaInteracao = KeyCode.E;
    public AudioClip somInteracao;

    protected AudioSource audioSource;
    protected MenuSystem menuSystem;
    protected Transform jogador;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        menuSystem = FindObjectOfType<MenuSystem>();
        jogador = GameObject.FindGameObjectWithTag("Player").transform;

        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            audioSource.loop = false;
        }
    }

    void Update()
    {
        if (jogador == null || menuSystem == null) return;

        if (Vector3.Distance(transform.position, jogador.position) <= distanciaInteracao &&
            Input.GetKeyDown(teclaInteracao))
        {
            TocarSom();
            Interagir();
        }
    }

    protected void TocarSom()
    {
        if (audioSource != null && somInteracao != null)
        {
            audioSource.PlayOneShot(somInteracao);
        }
    }

    protected abstract void Interagir();
}