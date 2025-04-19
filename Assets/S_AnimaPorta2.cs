using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_AnimaPorta2 : MonoBehaviour
{

    public static Animator anima2;
    void Start()
    {
        anima2 = this.GetComponent<Animator>();
        anima2.SetBool("Abrir2", false);
    }

    public void Ativar2()
    {

        anima2.SetBool("Abrir2", true);
    }

    public void Desativar2()
    {

        anima2.SetBool("Abrir2", false);
    }
}