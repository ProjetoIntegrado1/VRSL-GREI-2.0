using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AnimaVent2 : MonoBehaviour
{
    Animator anima;

    
    void Start()
    {
        anima = GetComponent<Animator>();
        anima.SetBool("rodar", false);
       
    }

    void Update()
    {

   


            if (S_AnimaDisjuntor.Aux == true)
            {

                anima.SetBool("rodar", true);
                

            }

            else 

            {
                anima.SetBool("rodar", false);
                

            }

        







    }
}
