
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Cameras_Switch_Training : MonoBehaviour
{
    //AAAA
    public Transform jogador;
    public KeyCode interacao = KeyCode.E;
    [Range(1, 50)]
    public float distanciaMinima = 1;
    float distancia;

    //Contadores
    public bool youCAN;
    public int youCannotCounter;
    //Objetos de jogo
    public GameObject checkpoint1;
    public GameObject text_youcan;

    public int cameraPositionCounter;

    //Declaração dos textos
    public Text b_ent_linhaText;
    public Text b_medicaofText;
    public Text b_protecao_atText;
    public Text b_barramento_atText;
    public Text b_transformacaoText;
    public Text b_barramento_mtText;
    public Text b_protecao_mtT1Text;
    public Text b_protecao_mtT2Text;
    public Text b_alimentacaoText;
    public Text b_trafo_s_aText;



   


    //Declaração das Mâmeras

    public GameObject cameraOne;
    public GameObject cameraTwo;
    public GameObject cameraThree;
    public GameObject cameraFour;
    public GameObject cameraFive;
    public GameObject cameraSix;
    public GameObject cameraSeven;
    public GameObject cameraEight;
    public GameObject cameraNine;
    public GameObject cameraTen;
    public GameObject cameraEleven;


    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;
    AudioListener cameraThreeAudioLis;
    AudioListener cameraFourAudioLis;
    AudioListener cameraFiveAudioLis;
    AudioListener cameraSixAudioLis;
    AudioListener cameraSevenAudioLis;
    AudioListener cameraEightAudioLis;
    AudioListener cameraNineAudioLis;
    AudioListener cameraTenAudioLis;
    AudioListener cameraElevenAudioLis;
    // Use this for initialization
    void Start()
    {
        youCannotCounter = 0;
        cameraPositionCounter = 0;
        youCAN = false;
        checkpoint1.SetActive(false);
        text_youcan.SetActive(false);

        b_ent_linhaText.text = " ";
        b_medicaofText.text = " ";
        b_protecao_atText.text = " ";
        b_barramento_atText.text = " ";
        b_transformacaoText.text = " ";
        b_barramento_mtText.text = " ";
        b_protecao_mtT1Text.text = " ";
        b_protecao_mtT2Text.text = " ";
        b_alimentacaoText.text = " ";
        b_trafo_s_aText.text = " ";
    //Get Camera Listeners
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();
        cameraThreeAudioLis = cameraThree.GetComponent<AudioListener>();
        cameraFourAudioLis = cameraFour.GetComponent<AudioListener>();
        cameraFiveAudioLis = cameraFive.GetComponent<AudioListener>();
        cameraSixAudioLis = cameraSix.GetComponent<AudioListener>();
        cameraSevenAudioLis = cameraSeven.GetComponent<AudioListener>();
        cameraEightAudioLis = cameraEight.GetComponent<AudioListener>();
        cameraNineAudioLis = cameraNine.GetComponent<AudioListener>();
        cameraTenAudioLis = cameraTen.GetComponent<AudioListener>();
        cameraElevenAudioLis = cameraEleven.GetComponent<AudioListener>();

        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }




    // Update is called once per frame
    void Update()
    {
        //Total de câmeras
        if (youCannotCounter >= 11)
        {
            text_youcan.SetActive(false);
            checkpoint1.SetActive(true);
            youCAN = false;
        }

        if (jogador)
        {
            distancia = Vector3.Distance(transform.position, jogador.transform.position);
            print(distancia);
            if (distancia < distanciaMinima)
            {
                if (Input.GetKeyDown(interacao))
                {
                    youCAN = true;
                    text_youcan.SetActive(true);
                }
            }

        }




        switchCamera();

        //Change Camera Keyboard
    }





    //UI JoyStick Method
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }





    //Change Camera Keyboard
    void switchCamera()
    {


        if (youCAN == true)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
            {
                cameraChangeCounter();
                youCannotCounter++;
            }
        }


    }




    //Camera Counter
    void cameraChangeCounter()
    {

        cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);


    }


    //Camera change Logic

    void cameraPositionChange(int camPosition)
    {
      
        //Voltando para o início - Total de câmeras -1
        if (camPosition > 10)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0)
        {

            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;

            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);

            cameraFourAudioLis.enabled = false;
            cameraFour.SetActive(false);

            cameraFiveAudioLis.enabled = false;
            cameraFive.SetActive(false);

            cameraSixAudioLis.enabled = false;
            cameraSix.SetActive(false);

            cameraSevenAudioLis.enabled = false;
            cameraSeven.SetActive(false);

            cameraEightAudioLis.enabled = false;
            cameraEight.SetActive(false);

            cameraNineAudioLis.enabled = false;
            cameraNine.SetActive(false);

            cameraTenAudioLis.enabled = false;
            cameraTen.SetActive(false);

            cameraElevenAudioLis.enabled = false;
            cameraEleven.SetActive(false);







            b_ent_linhaText.text = " ";
            b_medicaofText.text = " ";
            b_protecao_atText.text = " ";
            b_barramento_atText.text = " ";
            b_transformacaoText.text = " ";
            b_barramento_mtText.text = " ";
            b_protecao_mtT1Text.text = " ";
            b_protecao_mtT2Text.text = " ";
            b_alimentacaoText.text = " ";
            b_trafo_s_aText.text = " ";

        }

        //Set camera position 2
        if (camPosition == 1)
        {


            cameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled = true;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);

            cameraFourAudioLis.enabled = false;
            cameraFour.SetActive(false);

            cameraFiveAudioLis.enabled = false;
            cameraFive.SetActive(false);

            cameraSixAudioLis.enabled = false;
            cameraSix.SetActive(false);

            cameraSevenAudioLis.enabled = false;
            cameraSeven.SetActive(false);

            cameraEightAudioLis.enabled = false;
            cameraEight.SetActive(false);

            cameraNineAudioLis.enabled = false;
            cameraNine.SetActive(false);

            cameraTenAudioLis.enabled = false;
            cameraTen.SetActive(false);

            cameraElevenAudioLis.enabled = false;
            cameraEleven.SetActive(false);


            b_ent_linhaText.text = "Bay Entrada de Linha";
            b_medicaofText.text = " ";
            b_protecao_atText.text = " ";
            b_barramento_atText.text = " ";
            b_transformacaoText.text = " ";
            b_barramento_mtText.text = " ";
            b_protecao_mtT1Text.text = " ";
            b_protecao_mtT2Text.text = " ";
            b_alimentacaoText.text = " ";
            b_trafo_s_aText.text = " ";
        }

        //Set camera position 3
        if (camPosition == 2)
        {
            cameraThreeAudioLis.enabled = true;
            cameraThree.SetActive(true);

            cameraTwo.SetActive(false);
            cameraTwoAudioLis.enabled = false;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraFourAudioLis.enabled = false;
            cameraFour.SetActive(false);

            cameraFiveAudioLis.enabled = false;
            cameraFive.SetActive(false);

            cameraSixAudioLis.enabled = false;
            cameraSix.SetActive(false);

            cameraSevenAudioLis.enabled = false;
            cameraSeven.SetActive(false);

            cameraEightAudioLis.enabled = false;
            cameraEight.SetActive(false);

            cameraNineAudioLis.enabled = false;
            cameraNine.SetActive(false);

            cameraTenAudioLis.enabled = false;
            cameraTen.SetActive(false);

            cameraElevenAudioLis.enabled = false;
            cameraEleven.SetActive(false);


            b_ent_linhaText.text = " ";
            b_medicaofText.text = "Bay de Medição";
            b_protecao_atText.text = " ";
            b_barramento_atText.text = " ";
            b_transformacaoText.text = " ";
            b_barramento_mtText.text = " ";
            b_protecao_mtT1Text.text = " ";
            b_protecao_mtT2Text.text = " ";
            b_alimentacaoText.text = " ";
            b_trafo_s_aText.text = " ";
        }

        //Set camera position 4
        if (camPosition == 3)
        {
            cameraFourAudioLis.enabled = true;
            cameraFour.SetActive(true);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);

            cameraTwo.SetActive(false);
            cameraTwoAudioLis.enabled = false;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraFiveAudioLis.enabled = false;
            cameraFive.SetActive(false);

            cameraSixAudioLis.enabled = false;
            cameraSix.SetActive(false);

            cameraSevenAudioLis.enabled = false;
            cameraSeven.SetActive(false);

            cameraEightAudioLis.enabled = false;
            cameraEight.SetActive(false);

            cameraNineAudioLis.enabled = false;
            cameraNine.SetActive(false);

            cameraTenAudioLis.enabled = false;
            cameraTen.SetActive(false);

            cameraElevenAudioLis.enabled = false;
            cameraEleven.SetActive(false);


            b_ent_linhaText.text = " ";
            b_medicaofText.text = " ";
            b_protecao_atText.text = "Bay de proteção AT";
            b_barramento_atText.text = " ";
            b_transformacaoText.text = " ";
            b_barramento_mtText.text = " ";
            b_protecao_mtT1Text.text = " ";
            b_protecao_mtT2Text.text = " ";
            b_alimentacaoText.text = " ";
            b_trafo_s_aText.text = " ";
        }

        //Set camera position 5
        if (camPosition == 4)
        {
            cameraFiveAudioLis.enabled = true;
            cameraFive.SetActive(true);

            cameraFourAudioLis.enabled = false;
            cameraFour.SetActive(false);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);

            cameraTwo.SetActive(false);
            cameraTwoAudioLis.enabled = false;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraSixAudioLis.enabled = false;
            cameraSix.SetActive(false);

            cameraSevenAudioLis.enabled = false;
            cameraSeven.SetActive(false);

            cameraEightAudioLis.enabled = false;
            cameraEight.SetActive(false);

            cameraNineAudioLis.enabled = false;
            cameraNine.SetActive(false);

            cameraTenAudioLis.enabled = false;
            cameraTen.SetActive(false);

            cameraElevenAudioLis.enabled = false;
            cameraEleven.SetActive(false);


            b_ent_linhaText.text = " ";
            b_medicaofText.text = " ";
            b_protecao_atText.text = " ";
            b_barramento_atText.text = "Bay Barramento AT";
            b_transformacaoText.text = " ";
            b_barramento_mtText.text = " ";
            b_protecao_mtT1Text.text = " ";
            b_protecao_mtT2Text.text = " ";
            b_alimentacaoText.text = " ";
            b_trafo_s_aText.text = " ";

        }


        //Set camera position 6
        if (camPosition == 5)
        {
            cameraSixAudioLis.enabled = true;
            cameraSix.SetActive(true);

            cameraFiveAudioLis.enabled = false;
            cameraFive.SetActive(false);

            cameraFourAudioLis.enabled = false;
            cameraFour.SetActive(false);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);

            cameraTwo.SetActive(false);
            cameraTwoAudioLis.enabled = false;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraSevenAudioLis.enabled = false;
            cameraSeven.SetActive(false);

            cameraEightAudioLis.enabled = false;
            cameraEight.SetActive(false);

            cameraNineAudioLis.enabled = false;
            cameraNine.SetActive(false);

            cameraTenAudioLis.enabled = false;
            cameraTen.SetActive(false);

            cameraElevenAudioLis.enabled = false;
            cameraEleven.SetActive(false);


            b_ent_linhaText.text = " ";
            b_medicaofText.text = " ";
            b_protecao_atText.text = " ";
            b_barramento_atText.text = " ";
            b_transformacaoText.text = "Bay de Transformação";
            b_barramento_mtText.text = " ";
            b_protecao_mtT1Text.text = " ";
            b_protecao_mtT2Text.text = " ";
            b_alimentacaoText.text = " ";
            b_trafo_s_aText.text = " ";


        }



        //Set camera position 7
        if (camPosition == 6)
        {
            cameraSevenAudioLis.enabled = true;
            cameraSeven.SetActive(true);

            cameraSixAudioLis.enabled = false;
            cameraSix.SetActive(false);

            cameraFiveAudioLis.enabled = false;
            cameraFive.SetActive(false);

            cameraFourAudioLis.enabled = false;
            cameraFour.SetActive(false);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);

            cameraTwo.SetActive(false);
            cameraTwoAudioLis.enabled = false;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);


            cameraEightAudioLis.enabled = false;
            cameraEight.SetActive(false);

            cameraNineAudioLis.enabled = false;
            cameraNine.SetActive(false);

            cameraTenAudioLis.enabled = false;
            cameraTen.SetActive(false);

            cameraElevenAudioLis.enabled = false;
            cameraEleven.SetActive(false);


            b_ent_linhaText.text = " ";
            b_medicaofText.text = " ";
            b_protecao_atText.text = " ";
            b_barramento_atText.text = " ";
            b_transformacaoText.text = " ";
            b_barramento_mtText.text = "Bay Barramento de Média Tensão";
            b_protecao_mtT1Text.text = " ";
            b_protecao_mtT2Text.text = " ";
            b_alimentacaoText.text = " ";
            b_trafo_s_aText.text = " ";

        }


        //Set camera position 8 -------------------------------------------------------------------------------
        if (camPosition == 7)
        {

            cameraEightAudioLis.enabled = true;
            cameraEight.SetActive(true);

            cameraSevenAudioLis.enabled = false;
            cameraSeven.SetActive(false);

            cameraSixAudioLis.enabled = false;
            cameraSix.SetActive(false);

            cameraFiveAudioLis.enabled = false;
            cameraFive.SetActive(false);

            cameraFourAudioLis.enabled = false;
            cameraFour.SetActive(false);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);

            cameraTwo.SetActive(false);
            cameraTwoAudioLis.enabled = false;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraNineAudioLis.enabled = false;
            cameraNine.SetActive(false);

            cameraTenAudioLis.enabled = false;
            cameraTen.SetActive(false);

            cameraElevenAudioLis.enabled = false;
            cameraEleven.SetActive(false);


            b_ent_linhaText.text = " ";
            b_medicaofText.text = " ";
            b_protecao_atText.text = " ";
            b_barramento_atText.text = " ";
            b_transformacaoText.text = " ";
            b_barramento_mtText.text = " ";
            b_protecao_mtT1Text.text = "Bay de Proteção MT do primeiro transformador ";
            b_protecao_mtT2Text.text = " ";
            b_alimentacaoText.text = " ";
            b_trafo_s_aText.text = " ";

        }


        //Set camera position 9 -------------------------------------------------------------------------------
        if (camPosition == 8)
        {
            cameraNineAudioLis.enabled = true;
            cameraNine.SetActive(true);

            cameraEightAudioLis.enabled = false;
            cameraEight.SetActive(false);

            cameraSevenAudioLis.enabled = false;
            cameraSeven.SetActive(false);

            cameraSixAudioLis.enabled = false;
            cameraSix.SetActive(false);

            cameraFiveAudioLis.enabled = false;
            cameraFive.SetActive(false);

            cameraFourAudioLis.enabled = false;
            cameraFour.SetActive(false);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);

            cameraTwo.SetActive(false);
            cameraTwoAudioLis.enabled = false;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraTenAudioLis.enabled = false;
            cameraTen.SetActive(false);

            cameraElevenAudioLis.enabled = false;
            cameraEleven.SetActive(false);


            b_ent_linhaText.text = " ";
            b_medicaofText.text = " ";
            b_protecao_atText.text = " ";
            b_barramento_atText.text = " ";
            b_transformacaoText.text = " ";
            b_barramento_mtText.text = " ";
            b_protecao_mtT1Text.text = " ";
            b_protecao_mtT2Text.text = "Bay de Proteção MT do segundo transformador ";
            b_alimentacaoText.text = " ";
            b_trafo_s_aText.text = " ";

        }


        //Set camera position 10 -------------------------------------------------------------------------------
        if (camPosition == 9)
        {
            cameraTenAudioLis.enabled = true;
            cameraTen.SetActive(true);

            cameraNineAudioLis.enabled = false;
            cameraNine.SetActive(false);

            cameraEightAudioLis.enabled = false;
            cameraEight.SetActive(false);

            cameraSevenAudioLis.enabled = false;
            cameraSeven.SetActive(false);

            cameraSixAudioLis.enabled = false;
            cameraSix.SetActive(false);

            cameraFiveAudioLis.enabled = false;
            cameraFive.SetActive(false);

            cameraFourAudioLis.enabled = false;
            cameraFour.SetActive(false);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);

            cameraTwo.SetActive(false);
            cameraTwoAudioLis.enabled = false;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraElevenAudioLis.enabled = false;
            cameraEleven.SetActive(false);


            b_ent_linhaText.text = " ";
            b_medicaofText.text = " ";
            b_protecao_atText.text = " ";
            b_barramento_atText.text = " ";
            b_transformacaoText.text = " ";
            b_barramento_mtText.text = " ";
            b_protecao_mtT1Text.text = " ";
            b_protecao_mtT2Text.text = " ";
            b_alimentacaoText.text = "Bay de alimentação";
            b_trafo_s_aText.text = " ";

        }


        //Set camera position 11 -------------------------------------------------------------------------------
        if (camPosition == 10)
        {
            cameraElevenAudioLis.enabled = true;
            cameraEleven.SetActive(true);

            cameraTenAudioLis.enabled = false;
            cameraTen.SetActive(false);

            cameraNineAudioLis.enabled = false;
            cameraNine.SetActive(false);

            cameraEightAudioLis.enabled = false;
            cameraEight.SetActive(false);

            cameraSevenAudioLis.enabled = false;
            cameraSeven.SetActive(false);

            cameraSixAudioLis.enabled = false;
            cameraSix.SetActive(false);

            cameraFiveAudioLis.enabled = false;
            cameraFive.SetActive(false);

            cameraFourAudioLis.enabled = false;
            cameraFour.SetActive(false);

            cameraThreeAudioLis.enabled = false;
            cameraThree.SetActive(false);

            cameraTwo.SetActive(false);
            cameraTwoAudioLis.enabled = false;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

        

            b_ent_linhaText.text = " ";
            b_medicaofText.text = " ";
            b_protecao_atText.text = " ";
            b_barramento_atText.text = " ";
            b_transformacaoText.text = " ";
            b_barramento_mtText.text = " ";
            b_protecao_mtT1Text.text = " ";
            b_protecao_mtT2Text.text = " ";
            b_alimentacaoText.text = " ";
            b_trafo_s_aText.text = "Bay do Transformador de Serviços Auxiliares";

        }



    }





}

