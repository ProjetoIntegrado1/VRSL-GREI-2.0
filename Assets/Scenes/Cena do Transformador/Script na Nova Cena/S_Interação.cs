using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class S_Interação : MonoBehaviour
{
    public GameObject TelaFans;
    public GameObject TelaBuchasA;
    public GameObject TelaBuchasB;
    public GameObject TelaTanque;
    public GameObject TelaReleDeGas;
    public GameObject TelaValvDeAliviodePressao;
    public GameObject TelaSilicagel;
    

    public Transform jogador;
    // Start is called before the first frame updat

    // Update is called once per frame



    void Update()
    {
        if (S_MouseInteragir.PararTempo == true)
        {

            if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
            {

                if (S_MouseInteragir.Fans == true)
                {
                    TelaFans.SetActive(true);
                }



                if (S_MouseInteragir.BuchasA == true)
                {
                    TelaBuchasA.SetActive(true);
                }

                
                if (S_MouseInteragir.BuchasA == true)
                {
                    TelaBuchasA.SetActive(true);
                }

                if (S_MouseInteragir.BuchasB == true)
                {
                    TelaBuchasB.SetActive(true);
                }


                if (S_MouseInteragir.Tanque == true)
                {
                    TelaTanque.SetActive(true);
                }

                if (S_MouseInteragir.ReleDeGas == true)
                {
                    TelaReleDeGas.SetActive(true);
                }

                if(S_MouseInteragir.Silicagel == true)
                {
                    TelaSilicagel.SetActive(true);
                }

                 if(S_MouseInteragir.ValDeAlivioP == true)
                {
                    TelaValvDeAliviodePressao.SetActive(true);
                }

                



                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    jogador.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                    jogador.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
                    jogador.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
                    jogador.GetComponent<FirstPersonController>().m_MouseLook.UpdateCursorLock();

                }
                else
                {
                    Time.timeScale = 1;
                    jogador.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
                    jogador.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
                    jogador.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);
                    //jogador.GetComponent<FirstPersonController>().m_MouseLook.UpdateCursorLock();
                    //TelaFans.SetActive(false);
                    //TelaBuchasA.SetActive(false);
                    //TelaBuchasB.SetActive(false);
                    //TelaTanque.SetActive(false);
                }
            }
        }

    }
}
   