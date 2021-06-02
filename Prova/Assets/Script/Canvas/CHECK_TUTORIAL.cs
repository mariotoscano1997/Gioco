using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CHECK_TUTORIAL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.getInstance().tutorialLoadedFromMenu){
            gameObject.SetActive(false);
            GameManager.getInstance().tutorialLoadedFromMenu=false;
        }
        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(
            delegate {
               disactiveTutorial(gameObject.GetComponent<Toggle>());
            });
    }
    void disactiveTutorial(Toggle m){
        if(!m.isOn)
            PlayerPrefs.SetString("tutorial","disactive");
        else    
           PlayerPrefs.SetString("tutorial",""); 
    }
    
}
