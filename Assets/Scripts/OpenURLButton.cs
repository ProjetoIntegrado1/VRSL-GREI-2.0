using UnityEngine;

public class OpenURLButton : MonoBehaviour
{
    [Header("Endereço completo do site que vai abrir")]
    public string url = "https://grei-ufc.github.io/";

    public void OpenURL()
    {
        if (!string.IsNullOrEmpty(url))
            Application.OpenURL(url);
        else
            Debug.LogWarning("OpenURLButton: URL não foi definida!");
    }
}
