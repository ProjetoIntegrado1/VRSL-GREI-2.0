using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Porta2 : MonoBehaviour
{

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
    void Update()


    {


        if (S_MouseInteragir_2.Habilitar2 == true)
        {

            outline.enabled = true;
        }

        if (S_MouseInteragir_2.Habilitar2 == false)
        {

            outline.enabled = false;
        }

    }
}