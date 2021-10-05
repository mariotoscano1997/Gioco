using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      GameManager.getInstance().setPauseMenu(gameObject);
      gameObject.SetActive(false); 
    }

    
}
