using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 


public class DroneMovimentScript : MonoBehaviour
{

    //Declaração de variáveis
            //Permissões
    public bool youCanFly;
    public Transform jogador;
    public KeyCode interacao = KeyCode.E;
    [Range(1, 50)]
    public float distanciaMinima = 1;
    float distancia;
    public GameObject cameradrone;
    //public CameraFollowScript cfs;
    public float movimentFowardSpeed = 10.0f;
    public float tiltAmoutFoward = 0;
    public float tiltVelocityFoward;
    private float sideMovimentAmount = 6.0f;
    private float tiltAmountSideways;
    private float tiltAmountVelocity;
    public GameObject Player;
    public GameObject Goal;



    //Movimentação do Drone
    public float upForce;
    Rigidbody ourDrone;

    void Awake()
    {
        cameradrone.SetActive(false);
        youCanFly = false;
        ourDrone = GetComponent<Rigidbody>();
        tiltAmoutFoward = 0;
        sideMovimentAmount = 0;
        Goal.SetActive(false);
    }

    private void AbleToFly()
    {
        if (jogador)
        {
            distancia = Vector3.Distance(transform.position, jogador.transform.position);
            //print(distancia); to test
            if (distancia < distanciaMinima)
            {
                if (Input.GetKeyDown(interacao))
                {
                    cameradrone.SetActive(true);
                    youCanFly = true;
                    Player.SetActive(false);
                    Goal.SetActive(true);
                }
            }

        }
    }


    private void FixedUpdate()
    {
        AbleToFly();

        if (Input.GetKey(KeyCode.O))
        {
            youCanFly = false;
           //cfs.fpsPlayer.SetActive(true);
            cameradrone.SetActive(false);
            Player.SetActive(true);

        }

        if (youCanFly == true)
        {

            //Movimentação
            MovimentUpDown();
            MovimentFoward();
            Rotation();
            ClampingSpeedValues();
            Swerwe();

            ourDrone.AddRelativeForce(Vector3.up * upForce);
            ourDrone.rotation = Quaternion.Euler(
                new Vector3(tiltAmoutFoward, currentYRotation, tiltAmountSideways)
                );
        }
        
    }

    
    //Pra cima e pra baixo
    void MovimentUpDown()
    {

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K))
            {
                ourDrone.velocity = ourDrone.velocity;
            }
            if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L))
            {
                ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
                upForce = 114;
            }
            if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
            {
                ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
                upForce = 101;
            }

            if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
            {
                upForce = 116; 
            }

        }


        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            upForce = 105;
        }



        if (Input.GetKey(KeyCode.I))
        {
            upForce = 118.1f;
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
            {
                upForce = 120;
            }
        }
        else if (Input.GetKey(KeyCode.K))
        {
            upForce = 78.1f;
        }
        else if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K))
        {
            upForce = 98.1f;
        }
    }

    //Movimentação pra frente
    private void MovimentFoward()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            ourDrone.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * movimentFowardSpeed);
            tiltAmoutFoward = Mathf.SmoothDamp(tiltAmoutFoward, 10 * Input.GetAxis("Vertical"), ref tiltVelocityFoward, 0.1f);

            
        }

        if (Input.GetKey(KeyCode.T))
        {
            tiltAmoutFoward = 0;
            //ourDrone.velocity = Vector3.SmoothDamp(0,0,0);
            tiltVelocityFoward = 0;
            sideMovimentAmount = 0;
        }   

    }




    //Variáveis de Rotação
    private float wantedYRotation;
    public float currentYRotation;
    private float rotateAmoutByKey = 2.5f;
    private float rotationYVelocity;
    private void Rotation()
    {
        if (Input.GetKey(KeyCode.J))
        {
            wantedYRotation -= rotateAmoutByKey;
        }

        if (Input.GetKey(KeyCode.L))
        {
            wantedYRotation += rotateAmoutByKey;
        }
        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
    }

    //Variáveis para controle de velocidade
    public Vector3 velocityToSmoothDampToZero;
    private void ClampingSpeedValues()
    {
        //1
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 3.0f, Time.deltaTime * 5f));
        }
        //2
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 3.0f, Time.deltaTime * 5f));
        }
        //3
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 1.5f, Time.deltaTime * 5f));
        }
        //4
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            ourDrone.velocity = Vector3.SmoothDamp(ourDrone.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
        }
    }

    //Variáveis para o Swerwe

    private void Swerwe()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovimentAmount);
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -1 * 20 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
        }
    }





}


