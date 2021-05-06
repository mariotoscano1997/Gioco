using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("moneyLabel").GetComponent<TMPro.TextMeshProUGUI>().text=""+PlayerPrefs.GetInt("money");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
