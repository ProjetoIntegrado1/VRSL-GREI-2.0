using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_AnimaPorta : MonoBehaviour
{
    
    Animator anima;
    
    bool cont;
    void Start()
    {
        anima = GetComponent<Animator>();
        anima.SetBool("Abrir", false);
        anima.SetBool("Abrir2", false);
        cont =  false;
    }

    void Update() 
    { 
      
            if (Input.GetKeyDown(KeyCode.E) && S_MouseInteragir_2.Habilitar == true)
            {

                
                if (cont == false)
                {
                
                    anima.SetBool("Abrir", true);
                    cont = true;
                
                }

                else if (cont == true) 
            
                {
                    anima.SetBool("Abrir", false);
                    cont = false;
                    
                }
             
            }


        if (Input.GetKeyDown(KeyCode.E) && S_MouseInteragir_2.Habilitar2 == true)
        {


            if (cont == false)
            {

                anima.SetBool("Abrir2", true);
                cont = true;

            }

            else if (cont == true)

            {
                anima.SetBool("Abrir2", false);
                cont = false;

            }

        }





    }

}