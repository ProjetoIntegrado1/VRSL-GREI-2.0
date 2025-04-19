using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class S_AbrirMenu : MonoBehaviour
{
    public GameObject TelaDoMenu;
    public GameObject jogador;
    // Update is called once per frame
    void Update()
    {   

        if (Input.GetKey(KeyCode.E) && S_MouseInteragir.TrocarACena == true)
        {
            TelaDoMenu.SetActive(true);

            if (Time.timeScale == 1 )
            {
                Time.timeScale = 0;
                jogador.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                jogador.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
                jogador.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
                
            };

        }
    }
}
