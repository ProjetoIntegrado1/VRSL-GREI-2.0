using UnityEngine;

public class NotebookInteragivel : Interagivel
{
    [Header("Configurações do Notebook")]
    public GameObject menuNotebook; // Objeto pai com todas as telas

    protected override void Interagir()
    {
        menuSystem.AlternarMenuPorObjeto(menuNotebook);
    }

    // Método para o botão "Sair" no notebook
    public void FecharNotebook()
    {
        if (menuSystem.MenuEspecificoEstaAberto(menuNotebook))
        {
            menuSystem.CloseAllMenus();
        }
    }
}