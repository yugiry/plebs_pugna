using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Operation : MonoBehaviour
{
    public GameObject unit;
    public float Unit_X;
    public float Unit_Y;
    private bool pushmouse;

    private bool followmouse;
    private int tilenum;

    private float tile_x;
    private float tile_y;

    Vector3 mousepos;

    // Start is called before the first frame update
    void Start()
    {
        Unit_X = unit.transform.position.x;
        Unit_Y = unit.transform.position.y;
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = unit.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (followmouse && !pushmouse)
        {
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = unit.transform.position.z;
            if (Input.GetMouseButtonDown(0))
            {
                unit.transform.position = mousepos;
                followmouse = false;
            }
        }
        pushmouse = Input.GetMouseButtonDown(0);
    }

    public void Unit_Move()
    {
        followmouse = true;
        pushmouse = Input.GetMouseButtonDown(0);
    }
}
