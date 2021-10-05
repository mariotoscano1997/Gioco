using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinuafromPause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>{
            GameManager.getInstance().resumeFromPause();
        });   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
