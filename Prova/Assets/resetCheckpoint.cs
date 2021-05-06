using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class resetCheckpoint : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(resetCheck);
    }
    void Update(){
        gameObject.GetComponent<Button>().interactable= GameManager.getInstance().isCheckPointReached();
    }
    private void resetCheck(){
        print("ho premuto sto cazzo di bottone");
         GameManager.getInstance().reloadFromCheck();
    }
}
