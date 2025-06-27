using UnityEngine;

public class S_AnimaPorta : MonoBehaviour
{
    Animator anima;

    // um bool para cada animação
    bool cont1 = false;
    bool cont2 = false;

    void Start()
    {
        anima = GetComponent<Animator>();
        anima.SetBool("Abrir", false);
        anima.SetBool("Abrir2", false);
    }

    void Update()
    {
        // unifica E ou clique do mouse
        bool abrirInput = Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0);

        // Porta 1
        if (abrirInput && S_MouseInteragir_2.Habilitar)
        {
            cont1 = !cont1;                      // alterna true/false
            anima.SetBool("Abrir", cont1);       // seta parâmetro Abrir
        }

        // Porta 2
        if (abrirInput && S_MouseInteragir_2.Habilitar2)
        {
            cont2 = !cont2;                      // alterna true/false
            anima.SetBool("Abrir2", cont2);      // seta parâmetro Abrir2
        }
    }
}