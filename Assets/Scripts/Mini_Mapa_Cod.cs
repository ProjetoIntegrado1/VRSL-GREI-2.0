using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Mapa_Cod : MonoBehaviour
{

private bool mini_mapa_bool;
public GameObject Mapa;
// Start is called before the first frame update
void Start()
{
    mini_mapa_bool = false;
    Mapa.SetActive(true);
}

// Update is called once per frame
void Update()
{

    if (Time.timeScale == 0)
    {
        Mapa.SetActive(false);
        mini_mapa_bool = true;

    }



    if (mini_mapa_bool == false && Input.GetKeyDown(KeyCode.H))
    {
        Mapa.SetActive(false);
        mini_mapa_bool = true;
    }
    else if (mini_mapa_bool == true && Input.GetKeyDown(KeyCode.H))
    {
        Mapa.SetActive(true);
        mini_mapa_bool = false;
    }
}
}