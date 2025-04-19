using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plano_Animação_Drone : MonoBehaviour
{
    public GameObject Botão_Finalizar_Simu_Drone;

    // Start is called before the first frame update

    public void Parar_Tempo()
    {
        Time.timeScale = 0;
        Botão_Finalizar_Simu_Drone.SetActive(true);
    }


    public void Simu_Iniciou()
    {
        Time.timeScale = 1;
        Invoke("Parar_Tempo", 30);
    }

}
