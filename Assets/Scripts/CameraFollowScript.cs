using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    private Transform ourDrone;
    public bool YouAreAbleToFly;
    public DroneMovimentScript dm;
    public GameObject fpsPlayer;
    private void Awake()
    {
        //Pegando a variável do DroneMoviment Script
        YouAreAbleToFly = dm.youCanFly;
        ourDrone = GameObject.FindGameObjectWithTag("Drone").transform;

    }
    private Vector3 velocityCameraFollow;
    public Vector3 behindPosition = new Vector3(0, 3, -4);
    public float angle;
    private void FixedUpdate()
    {
        //Pegando a variável do DroneMoviment Script
        YouAreAbleToFly = dm.youCanFly;


        if (YouAreAbleToFly == true)
        {;
            fpsPlayer.SetActive(false);
            
            transform.position = Vector3.SmoothDamp(transform.position, ourDrone.transform.TransformPoint(behindPosition) + Vector3.up * Input.GetAxis("Vertical"), ref velocityCameraFollow, 0.1f);
            transform.rotation = Quaternion.Euler(new Vector3(angle, ourDrone.GetComponent<DroneMovimentScript>().currentYRotation, 0));

        }
        else
        {
            
            fpsPlayer.SetActive(true);
        }
      

    }

}
