using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class backToMain : MonoBehaviour
{
    public void Start(){
        gameObject.GetComponent<Button>().onClick.AddListener(()=>{ 
            SceneManager.LoadScene("Menu");
        });
    }
}
