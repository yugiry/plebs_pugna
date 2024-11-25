using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class stageboard : MonoBehaviour
{
    public GameObject mapboard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    void Update()
    {
       
       if (Input.GetMouseButtonDown(1))
       {
            mapboard.SetActive(false);
       }
     
    }
}
