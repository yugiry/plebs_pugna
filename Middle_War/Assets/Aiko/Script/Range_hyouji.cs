using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_hyouji : MonoBehaviour
{
    public GameObject range_child;
   
    // Start is called before the first frame update
    void Start()
    {
        range_child = GameObject.Find("ranges");
       
    }

    public void range_hyouji()
    {
        if (range_child.activeSelf)
        {
            range_child.SetActive(false);
        }
        else
        {
            range_child.SetActive(true);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            range_hyouji();
        }
    }
}
