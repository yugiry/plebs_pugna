using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class stageboard : MonoBehaviour
{
    public GameObject mapboard;
   
    void Update()
    {
       
       if (Input.GetMouseButtonDown(1))
       {
            mapboard.SetActive(false);
       }
     
    }

    public void Cancel()
    {
        mapboard.SetActive(false);
    }
}
