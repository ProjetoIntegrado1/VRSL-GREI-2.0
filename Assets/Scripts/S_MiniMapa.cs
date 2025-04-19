using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MiniMapa : MonoBehaviour
{
    public Transform target; // Referência ao FPS Controller (ou outro objeto que você queira seguir)
    //private bool RotacaoPlayer = false;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position;
        desiredPosition.y = transform.position.y;
        transform.position = desiredPosition;

        //if (Input.GetKeyDown(KeyCode.R))
        //{
            // Inverter o estado de rotação quando a tecla "R" for pressionada
          //  RotacaoPlayer = !RotacaoPlayer;
        //}


       // if (RotacaoPlayer)
        //{
          //  transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f);
        //}
    }

}