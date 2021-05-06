using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AddNick : MonoBehaviour
{
    public GameObject inputField;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(inviaDati);
    }

    public void inviaDati(){
        print("invio questi dati "+ inputField.GetComponent<TMP_InputField>().text);
        
        rank.addEntry(GameManager.getInstance().getScore(), inputField.GetComponent<TMP_InputField>().text);
        //rank.addEntry(4000, inputField.GetComponent<TMP_InputField>().text);
    }
}
