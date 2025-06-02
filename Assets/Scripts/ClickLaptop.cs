using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(AudioSource))]
public class ClickLaptop : MonoBehaviour
{
    [Header("Configurações")]
    public float distanciaMinima = 1f;
    public KeyCode interacao = KeyCode.E;
    public AudioClip somBotao;

    [Header("Referências")]
    public Transform jogador;
    public GameObject laptopMenu; // Objeto pai de todas as telas
    private AudioSource aud;
    private MenuSystem menuSystem;

    void Awake()
    {
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
        aud.loop = false;
        aud.clip = somBotao;

        // Encontra o sistema de menus automaticamente
        menuSystem = FindObjectOfType<MenuSystem>();

        // Garante que o menu comece fechado
        if (laptopMenu != null) laptopMenu.SetActive(false);
    }

    void Update()
    {
        if (jogador == null || menuSystem == null) return;

        float distancia = Vector3.Distance(transform.position, jogador.position);
        if (distancia < distanciaMinima && Input.GetKeyDown(interacao))
        {
            // Toca som se disponível
            if (aud.clip != null) aud.PlayOneShot(aud.clip);

            // Abre ou fecha o menu do laptop
            if (laptopMenu.activeSelf)
            {
                menuSystem.CloseAllMenus();
            }
            else
            {
                menuSystem.OpenMenu(laptopMenu, true);
            }
        }
    }

    // Método para ser chamado pelo botão "Sair"
    public void FecharLaptop()
    {
        if (menuSystem != null && laptopMenu.activeSelf)
        {
            menuSystem.CloseAllMenus();
        }
    }
}