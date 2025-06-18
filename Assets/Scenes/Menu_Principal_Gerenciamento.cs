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
        GameManager.Instance.IrParaPatio();
    }

    public void IrParaTransformador()
    {
        GameManager.Instance.IrParaTransformador();
    }

}
