using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_color_change : MonoBehaviour
{
    public void change_button_enter()
    {
        //GameObject[] Button = GameObject.FindGameObjectsWithTag("Player");



        


            this.GetComponent<Renderer>().material.color = new Color(0.7f, 0.7f, 0.7f, 1.0f);
            Debug.Log("change");
        
    }
    public void change_button2_exit()
    {
        //GameObject[] Button = GameObject.FindGameObjectsWithTag("Player");



            this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
