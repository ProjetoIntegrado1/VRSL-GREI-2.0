using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Disjuntor : MonoBehaviour
{   private bool Sim;
    private Outline outline;

    void Start()
    {
        outline = GetComponent<Outline>();
        if (outline == null)
        {
            outline = gameObject.AddComponent<Outline>();
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 10.0f;
            outline.enabled = false;
        }
    }

    private void OnMouseEnter()
    {
        Sim = true;

    }

    private void OnMouseExit()
    {
        Sim = false;

    }

    void Update()


    {


        if (Sim == true && S_MouseInteragir_2.Disjuntor == true)
        {

            outline.enabled = true;
        }

        else 
        {

            outline.enabled = false;
        }

    }
}