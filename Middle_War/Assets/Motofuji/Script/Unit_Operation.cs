using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Operation : MonoBehaviour
{
    //public static Unit_Operation instance;
    public GameObject unit;
    public float Unit_X;
    public float Unit_Y;
    private bool pushmouse;

    GameObject clickedGameObject;

    private bool followmouse;
    private int tilenum;

    private float tile_x;
    private float tile_y;

    Vector3 mousepos;

    //public void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //}

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
            if (Input.GetKeyDown(KeyCode.B))
            {
                Destroy(unit);
            }
            if (Input.GetMouseButtonDown(0))
            {
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                mousepos.x = mousepos.x + 54;
                mousepos.y = -mousepos.y + 54;
                mousepos.z = unit.transform.position.z;
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                        {
                            if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                            {
                                clickedGameObject = hit2d.transform.gameObject;
                                if (clickedGameObject.name != "mountain(Clone)" && clickedGameObject.name != "resource(Clone)" && clickedGameObject.name != "castle1(Clone)" && clickedGameObject.name != "castle2(Clone)")
                                {
                                    Debug.Log(clickedGameObject.name);
                                    unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 7.0f);
                                }
                            }
                        }
                    }
                }
                followmouse = false;
            }
        }
        pushmouse = Input.GetMouseButtonDown(0);

        if(Input.GetMouseButtonDown(1))
        {
            followmouse = false;
        }
    }

    public void Unit_Serect()
    {
        if (!followmouse)
        {
            followmouse = true;
            pushmouse = Input.GetMouseButtonDown(0);
        }
    }

    public void Unit_Move()
    {
        if (followmouse && !pushmouse)
        {

        }
    }
}
