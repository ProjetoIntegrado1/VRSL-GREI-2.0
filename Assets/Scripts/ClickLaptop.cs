using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
//using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class ClickLaptop : MonoBehaviour
{
    public Transform jogador;
    public AudioClip somBotao;
    public KeyCode interacao = KeyCode.E;
    public GameObject tela1;
    public GameObject telas_n_principais;
    public GameObject telas_simu;
    public GameObject mira;

    [Range(1, 50)]
    public float distanciaMinima = 1;
    float distancia;
    AudioSource aud;

    void Awake()
    {
        telas_n_principais.SetActive(false);
        telas_simu.SetActive(false);
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
        if (jogador)
        {
            distancia = Vector3.Distance(transform.position, jogador.transform.position);
            // to test       print(distancia);
            if (distancia < distanciaMinima)
            {
                if (Input.GetKeyDown(interacao) && telas_n_principais.activeInHierarchy==false && telas_simu.activeInHierarchy==false)
                {
                    if (aud.clip != null)
                    {
                        aud.PlayOneShot(aud.clip);
                    }

                    if (Time.timeScale == 1)
                    {
                        Time.timeScale = 0;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
                        //jogador.GetComponent<FirstPersonController>().m_MouseLook.UpdateCursorLock();
                        telas_n_principais.SetActive(true);
                        telas_simu.SetActive(true);
                        mira.SetActive(false);

                    }
                    else
                    {
                        Time.timeScale = 1;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
                        jogador.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);
                        telas_n_principais.SetActive(false);
                        telas_simu.SetActive(false);
                        mira.SetActive(true);
                    }

                    if (tela1 != null)
                    {
                        bool isActive = tela1.activeSelf;
                        tela1.SetActive(!isActive);
                    }



                }
            }
        }
    }


    public void Out()
    {
        tela1.SetActive(false);
        Time.timeScale = 1;
        jogador.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
        jogador.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
        jogador.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);
        telas_n_principais.SetActive(false);
        telas_simu.SetActive(false);
    }
}