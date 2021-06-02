using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake(){
        string value = PlayerPrefs.GetString("Sound");
        if(value=="True")
            gameObject.GetComponent<Toggle>().isOn=true;
        else 
            gameObject.GetComponent<Toggle>().isOn=false;
    }
    void Start()
    {
        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(delegate {
            Mute(gameObject.GetComponent<Toggle>());
        });
    }

    private void Mute(Toggle m ){
        print("il valore è Cambiato");
        print(m.isOn);
        PlayerPrefs.SetString("Sound",""+m.isOn);
        if(m.isOn)
            FindObjectOfType<AudioManager>().PlayAllSound();
        else
            FindObjectOfType<AudioManager>().MuteAllSound();
    }
}
