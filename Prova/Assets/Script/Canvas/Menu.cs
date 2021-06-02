﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(){
        string tutorial=PlayerPrefs.GetString("tutorial","");
        if(tutorial=="")
            SceneManager.LoadScene("Tutorial");
        else 
            SceneManager.LoadScene("GAME");
    }
    public void showTutorial(){
        GameManager.getInstance().tutorialLoadedFromMenu=true;
        SceneManager.LoadScene("Tutorial");
    }
    public void Shop(){
        SceneManager.LoadScene("Shop");
    }
    public void Quit(){
        Application.Quit();
    }
}
