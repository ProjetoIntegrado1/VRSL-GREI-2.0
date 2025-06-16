using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_Principal_Gerenciamento : MonoBehaviour
{
    [SerializeField]   private string nomeDoLevelDeJogo = "Treinamento";
    public GameObject jogador;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void SairDoJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();

    }

    public void IrParaNotebook()
    {
        GameManager.Instance.IrParaNotebook();
    }

    public void IrParaPatio()
    {
        if (SceneManager.GetActiveScene().name == "Treinamento")
        {
            var fpc = jogador.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            fpc.Warp(
                new Vector3(40.04f, 0.99f, 24.56f),
                Quaternion.Euler(0f, -98.043f, 0f)
            );
        }
        else
        {
            SceneManager.LoadScene("Treinamento");
        }
    }

    public void IrParaTransformador()
    {
        if (SceneManager.GetActiveScene().name == "Transformador")
        {
            var fpc = jogador.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            fpc.Warp(
                new Vector3(32.61f, 0.99f, 34.73f),
                Quaternion.Euler(0f, -5.447f, 0f)
            );
        }
        else
        {
            SceneManager.LoadScene("Transformador");
        }
    }

}
