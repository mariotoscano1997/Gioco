using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishCanvas : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        GameManager.getInstance().setFinishUI(gameObject);
        gameObject.SetActive(false);
    }
 
    
}
