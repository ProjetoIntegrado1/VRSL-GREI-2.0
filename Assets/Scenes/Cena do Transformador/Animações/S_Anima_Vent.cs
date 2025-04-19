using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Anima_Vent : MonoBehaviour
{

    Animator anime;


    void Start()
    {
       anime = this.GetComponent<Animator>();
    }

    public void Ativar()
    {
   
            anime.SetBool("rodar", true);
    }

    public  void Desativar()
    {

        anime.SetBool("rodar", false);
    }
}
