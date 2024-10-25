using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Operation : MonoBehaviour
{
    public GameObject unit;
    public float Unit_X;
    public float Unit_Y;
    private bool pushmouse;

    GameObject clickedGameObject;

    public bool followmouse;
    private int tilenum;

    private float tile_x;
    private float tile_y;

    Vector3 mousepos;
    Vector3 vec;

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
        //ユニットを動かす処理
        if (followmouse && !pushmouse)
        {
            //選択したユニットを消す
            if (Input.GetKeyDown(KeyCode.B))
            {
                Destroy(unit);
            }
            //ユニットをマウスの位置のタイルに移動させる
            if (Input.GetMouseButtonDown(0))
            {
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                mousepos.x = mousepos.x + 54;
                mousepos.y = -mousepos.y + 54;
                mousepos.z = unit.transform.position.z;
                tile_x = (unit.transform.position.x + 54) / (4.0f + 0.5f);
                tile_y = (-unit.transform.position.y + 54) / (4.0f + 0.5f);
                //マウスの位置にあるタイルを探す
                for (float i = tile_y - 1; i <= tile_y + 1; i++)
                {
                    for (float j = tile_x - 1; j <= tile_x + 1; j++)
                    {
                        if (((i == tile_y - 1 || i == tile_y + 1) && j == tile_x) || (i == tile_y && (j == tile_x - 1 || j == tile_x + 1)))
                        {
                            Debug.Log("通過");
                            if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                            {
                                Debug.Log("通過");
                                if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                                {
                                    clickedGameObject = hit2d.transform.gameObject;
                                    if (clickedGameObject.name != "mountain(Clone)" && clickedGameObject.name != "resource(Clone)" && clickedGameObject.name != "castle1(Clone)" && clickedGameObject.name != "castle2(Clone)" && clickedGameObject.name != "area2(Clone)")
                                    {
                                        Debug.Log(clickedGameObject.name);
                                        unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 7.0f);
                                        LineRenderer renderer = gameObject.GetComponent<LineRenderer>();
                                        renderer.SetWidth(1.0f, 1.0f);
                                        renderer.SetVertexCount(2);
                                        renderer.SetPosition(0, new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z));
                                        renderer.SetPosition(1, new Vector3(-54 + (j * 4.5f), 54 - (i * 4.5f), 7.0f));
                                        followmouse = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        pushmouse = Input.GetMouseButtonDown(0);
        //右クリックしたら選択をキャンセルする
        if(Input.GetMouseButtonDown(1))
        {
            followmouse = false;
        }
    }

    //ユニットを選択する
    public void Unit_Serect()
    {
        if (!followmouse)
        {
            followmouse = true;
            pushmouse = Input.GetMouseButtonDown(0);
        }
    }
}
