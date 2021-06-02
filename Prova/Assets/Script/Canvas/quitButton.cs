using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class quitButton : MonoBehaviour
{  void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(quit);
    }
    private void quit(){
        print("ho premuto sto cazzo di bottone");
        Application.Quit();
    }
}
