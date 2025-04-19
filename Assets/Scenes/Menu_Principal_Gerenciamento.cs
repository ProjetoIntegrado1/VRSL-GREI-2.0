using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_Principal_Gerenciamento : MonoBehaviour
{
    // Start is called before the first frame update

     [SerializeField]   private string nomeDoLevelDeJogo = "Treinamento";

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void SairDoJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();

    }
}
