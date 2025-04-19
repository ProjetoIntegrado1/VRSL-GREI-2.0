using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class S_voltar : MonoBehaviour
{

    public Transform jogador;
    public void Update()
    {
        
        jogador.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
        jogador.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
        jogador.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);

    }
}