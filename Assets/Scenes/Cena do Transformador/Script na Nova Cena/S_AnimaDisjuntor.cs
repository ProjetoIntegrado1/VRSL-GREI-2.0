using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class S_AnimaDisjuntor : MonoBehaviour
{
    

    Animator animaa;

    bool cont;
    public static bool Aux;
    public static bool Aux1; //Chamado no scrip S_TravarPersonagem para interação com o tempo  


    void Start()
    {
        animaa = GetComponent<Animator>();
        animaa.SetBool("LIberar", false);
        Aux = false;
        cont = false;

    }

  


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E) && S_MouseInteragir_2.Disjuntor == true)
        {
            


            if (cont == false)
            {

                Aux = true;
                Aux1 = true;
                animaa.SetBool("LIberar", true);
                cont = true;
             
                
            }
            else if (cont == true)

            {
             
                Aux = false;
                animaa.SetBool("LIberar", false);

                cont = false;

            }


        }

    }
}