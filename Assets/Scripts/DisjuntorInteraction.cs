using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DisjuntorInteraction : MonoBehaviour
{
    [Header("Animators to toggle")]
    public List<Animator> disjuntorAnimators = new List<Animator>();
    public List<Animator> transformadorAnimators = new List<Animator>();
    public string parameterName = "Liberar";
    public string transformadorName = "rodar";

    [Header("Interaction Settings")]
    public KeyCode interactionKey = KeyCode.E;
    public bool useMouseButton = true;

    private bool isOpen = false;
    private HoverOutline myOutline;
    public GameObject tela;
    public GameObject jogador;
    public MenuSystem menuSystem;

    private void Awake()
    {
        myOutline = GetComponent<HoverOutline>();
    }

    private void Update()
    {
        if (HoverOutline.CurrentHovered != myOutline)
            return;

        if (tela.activeSelf)
            return;

        if (Input.GetKeyDown(interactionKey) || (useMouseButton && Input.GetMouseButtonDown(0)))
        {
            isOpen = !isOpen;
            foreach (var animator in disjuntorAnimators)
                animator?.SetBool(parameterName, isOpen);

            foreach (var animator in transformadorAnimators)
            {
                Debug.Log(isOpen);
                animator?.SetBool(transformadorName, isOpen);
            }

            if (isOpen)
            {
                jogador.GetComponent<FirstPersonController>().enabled = false;
                StartCoroutine(Routine());
            }
        }
    }

    private IEnumerator Routine()
    {
        yield return new WaitForSeconds(1f);
        menuSystem.SetStateOtherMenu(tela);
        jogador.GetComponent<FirstPersonController>().enabled = true;
    }
}