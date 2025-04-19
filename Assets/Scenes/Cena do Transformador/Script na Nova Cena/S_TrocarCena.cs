using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_TrocarCena : MonoBehaviour
{

    [SerializeField] private string NomeCena;


    // Start is called before the first frame update
    public void Jogar()
    {
        SceneManager.LoadScene(NomeCena);
        

    }
}