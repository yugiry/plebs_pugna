using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFalseManager1 : MonoBehaviour
{
    public GameObject NameButton;

   
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

  
    public void onClick()
    {
        NameButton.SetActive(false);
    }
}