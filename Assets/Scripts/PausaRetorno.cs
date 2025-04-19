using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(AudioSource))]


public class PausaRetorno : MonoBehaviour
{
    //public int youcannot2;
    public Transform jogador;
    public AudioClip somBotao;
    public KeyCode interacao = KeyCode.Escape;
    public GameObject tela;
    //public GameObject checkpoint1;
    AudioSource aud;
    //public GameObject troca_camera;

    void Awake()
    {
       // youcannot2 = 0;
        aud = GetComponent<AudioSource>();
        if (somBotao)
        {
            aud.clip = somBotao;
        }
        aud.playOnAwake = false;
        aud.loop = false;
        

    }

    void Update()
    {
        //youcannot2 = troca_camera.GetComponent<Cameras_Switch_Training>().youCannotCounter;

        if (jogador)
        {
                if (Input.GetKeyDown(interacao))
                {
                //Sinal Sonoro   
                     if (aud.clip != null)
                    {
                        aud.PlayOneShot(aud.clip);
                    }
                //Estando rodando
                    if (Time.timeScale == 1)
                    {
                        Time.timeScale = 0;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
                        //jogador.GetComponent<FirstPersonController>().m_MouseLook.UpdateCursorLock();

                    }
                    else
                    {
                        Time.timeScale = 1;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);
                    }

                    if (tela != null)
                    {
                        bool isActive = tela.activeSelf;
                        tela.SetActive(!isActive);
                    }

               // if (youcannot2 == 11)
                //{
                  //  bool joao = checkpoint1.activeSelf;
                    //checkpoint1.SetActive(!joao);
                //}

                }
            
        }
    }


}
