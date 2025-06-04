using UnityEngine;

public class NotebookInteragivel : Interagivel
{
    [Header("Configurações do Notebook")]
    public GameObject menuNotebook; // Objeto pai com todas as telas do notebook

    protected override void Interagir()
    {
        if (menuNotebook == null || menuSystem == null)
            return;

        // Se o notebook já estiver aberto, não faz nada ao pressionar E
        if (!menuNotebook.activeSelf)
        {
            // Abre o notebook (pausa o jogo)
            menuSystem.OpenMenu(menuNotebook, true);
        }
    }

    // Método para o botão "Sair" no notebook
    public void FecharNotebook()
    {
        if (menuNotebook != null && menuNotebook.activeSelf)
        {
            menuSystem.CloseAllMenus();
        }
    }
}
