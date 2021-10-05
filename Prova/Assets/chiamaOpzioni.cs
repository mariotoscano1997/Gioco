using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chiamaOpzioni : MonoBehaviour
{
    public GameObject opzioni;
    public Button opzButton;
    // Start is called before the first frame update
    void Start()
    {
        opzButton.onClick.AddListener(()=>{
            opzioni.SetActive(true);
            Instantiate(opzioni);  
        });          
    }

    
}
