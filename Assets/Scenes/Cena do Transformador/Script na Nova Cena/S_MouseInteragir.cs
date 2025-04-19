using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class S_MouseInteragir : MonoBehaviour
{


    public static bool PararTempo;
    public static bool Fans;
    public static bool BuchasA;
    public static bool BuchasB;
    public static bool Tanque;
    public static bool TrocarACena;
    public static bool ReleDeGas;
    public static bool ValDeAlivioP;
    public static bool Silicagel;
    public static bool PlacaDeInformacao;
    // Start is called before the first frame update


    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        PararTempo = false;
        Fans = false;
        BuchasA = false;
        BuchasB = false;
        Tanque = false;
        TrocarACena = false;
        ReleDeGas = false;
        ValDeAlivioP = false;
        Silicagel = false;
        PlacaDeInformacao = false;

        if (Physics.Raycast(ray, out hit, 100.0f))
        {

            if (hit.transform != null && hit.transform.gameObject.CompareTag("ObjetosEspeciais"))
            {
                TrocarACena = true;


            }


            


            if (hit.transform != null && hit.transform.gameObject.CompareTag("Fans"))
            {
                Fans = true;
                PararTempo = Fans;

            }

            if (hit.transform != null && hit.transform.gameObject.CompareTag("Silicagel")) 
            {
                Silicagel = true;
                PararTempo = Silicagel;
            }

         
            
            if(hit.transform != null && hit.transform.gameObject.CompareTag("BuchasB"))
                {
                    BuchasB = true;
                    PararTempo = BuchasB;
                }


            if(hit.transform != null && hit.transform.gameObject.CompareTag("BuchasA"))
                {
                    BuchasA = true;
                    PararTempo = BuchasA;
                }



            if (hit.transform != null && hit.transform.gameObject.CompareTag("Tanque"))
                {
                    Tanque = true;
                    PararTempo = Tanque;

                }

            if(hit.transform != null && hit.transform.gameObject.CompareTag("ReleDeGas"))
            {
                ReleDeGas = true;
                PararTempo = ReleDeGas;
        
        
            }

            if(hit.transform != null && hit.transform.gameObject.CompareTag("ValDeAlivioP"))
            {
                ValDeAlivioP = true;
                PararTempo = ValDeAlivioP;
            }

        }   


     }
}
