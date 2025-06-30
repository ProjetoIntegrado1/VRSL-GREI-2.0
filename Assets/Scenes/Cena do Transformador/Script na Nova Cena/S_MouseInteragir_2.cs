using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static MenuSystem;

public class S_MouseInteragir_2 : MonoBehaviour
{
    
    public static bool Habilitar;
    public static bool Habilitar2;
    public static bool Disjuntor;
    // Update is called once per frame

    private MenuSystem menuSystem;

    private void Awake()
    {
        // pegar o menuSystem
        menuSystem = FindObjectOfType<MenuSystem>();
        if (menuSystem == null)
            Debug.LogError("Não encontrei nenhum MenuSystem na cena!");
    }
    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        Habilitar = false;
        Habilitar2 = false; 
        Disjuntor = false;

        if (menuSystem.currentState != MenuState.Crosshair)
        {
            return;
        }

        if (Physics.Raycast(ray, out hit, 1f))
        {
            if (hit.transform != null && hit.transform.gameObject.CompareTag("ObjetosEspeciais"))
            {
                Disjuntor = true;
            }
        }

        if (Physics.Raycast(ray, out hit, 20f))
        {    
            if (hit.transform != null && hit.transform.gameObject.CompareTag("Porta"))
            {
                Habilitar = true;
            }
            else if(hit.transform != null && hit.transform.gameObject.CompareTag("Porta2"))
            {
                Habilitar2 = true;
            }
        }
     }
}
