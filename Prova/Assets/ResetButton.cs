
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(reset);
    }
    private void reset(){
        print("ho premuto sto cazzo di bottone");
        GameManager.getInstance().restart();
    }
}
