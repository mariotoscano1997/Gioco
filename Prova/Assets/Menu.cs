using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene("GAME");
    }
    public void Shop(){
        SceneManager.LoadScene("Shop");
    }
    public void Quit(){
        Application.Quit();
    }
}
