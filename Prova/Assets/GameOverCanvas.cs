using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        GameManager.getInstance().setEndUI(gameObject);
        gameObject.SetActive(false);

    }
 
    
}

