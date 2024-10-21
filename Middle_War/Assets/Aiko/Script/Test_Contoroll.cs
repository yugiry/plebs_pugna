using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Contoroll : MonoBehaviour
{
    Rigidbody2D rbody;
    int AP = 0;
    int AP_syouhi = 1;
    float move = 4.5f;
    //public int Penalty = 2; 

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.transform.Translate(0, move, 0);
            AP -= AP_syouhi;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.transform.Translate(0, -move, 0);
            AP -= AP_syouhi;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Translate(move, 0, 0);
            AP -= AP_syouhi;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.Translate(-move, 0, 0);
            AP -= AP_syouhi;
        }
    }
}
