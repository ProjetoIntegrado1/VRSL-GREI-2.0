﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name); //carrega uma cena
    }

    public void QuitGame()
    {
        Application.Quit(); //fecha uma cena
    }
    

}
