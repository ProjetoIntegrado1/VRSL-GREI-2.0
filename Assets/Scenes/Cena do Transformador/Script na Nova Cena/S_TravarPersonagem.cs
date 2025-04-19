using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting;

using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class S_TravarPersonagem : MonoBehaviour
{
    public GameObject Tela;
    public GameObject jogador; 
    public GameObject Tp;
     bool Teleporte1; // Uma gambiarra para o teleporte para o transformador na subestação funcionar
    // Start is called before the first frame update
    void Start()
    {
      
        S_AnimaDisjuntor.Aux1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( S_AnimaDisjuntor.Aux1 == true)
        {
            jogador.GetComponent<FirstPersonController>().enabled = false;    
            Invoke("Aa", 1.5f);
            

            S_AnimaDisjuntor.Aux1 = false;
        }

        

    }

    public void Aaab() {

        jogador.GetComponent<FirstPersonController>().enabled = true;
    }
  

    public void Aab()
    {
        jogador.gameObject.transform.position = new Vector3(Tp.transform.position.x, jogador.transform.position.y, Tp.transform.position.z);

        Invoke("Aaab", 0.1f);

    }

    public void Aa()
    {
        Tela.SetActive(true);
        if (Time.timeScale == 1 && Tela.activeSelf == true )
        {
            Time.timeScale = 0;
            jogador.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
            jogador.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
            jogador.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);

        };
    }



}
