using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rbody;
    
    public float speed = 1.0f;
    float distance = 8.0f;
    private Vector2 inputAxis;
    private Vector3 Destination;
    int renzoku_kinshi=0;


    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        Destination = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.RightArrow))
        //{
        //    inputAxis.x += speed;
        //}

        inputAxis.x = Input.GetAxisRaw("Horizontal");
        inputAxis.y = Input.GetAxisRaw("Vertical");

        if(inputAxis!=Vector2.zero&&transform.position==Destination&&renzoku_kinshi==0)
        {
            Destination += new Vector3(inputAxis.x, inputAxis.y, 0)*distance;
            
        }
        Movement(Destination);
    }
    private void Movement(Vector3 TargetPosition)
    {
        //rbody.velocity = inputAxis.normalized * speed;
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);
        

    }


}
