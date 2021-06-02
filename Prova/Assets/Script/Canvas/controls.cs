using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<TMPro.TMP_Dropdown>().onValueChanged.AddListener(
            delegate{
                 changeControls(gameObject.GetComponent<TMPro.TMP_Dropdown>());
                 
        });
    }

    private void changeControls(TMPro.TMP_Dropdown d){
        print("sto cambiando i controlli");
        string controls=d.captionText.text;
        if(controls=="AD")
            PlayerPrefs.SetString("controls","AD");
        else 
            PlayerPrefs.SetString("controls","LR");
    }
}
