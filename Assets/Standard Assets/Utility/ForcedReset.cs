using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI; // Adicione esta linha

public class ForcedReset : MonoBehaviour
{
    // Se precisar de uma referência à UI, você pode declarar uma variável aqui.
    // public Image myImage; // ou public RawImage myImage;

    private void Update()
    {
        // if we have forced a reset ...
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            //... reload the scene
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
