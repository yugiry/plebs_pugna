using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EUnit_Operation : MonoBehaviour
{
    public GameObject unit;
    public GameObject act1;
    public float Unit_X;
    public float Unit_Y;
    private bool pushmouse;

    public int hp;
    public int attack;
    public int spawn_ap;
    public int spawn_resource;
    public int move_ap;
    public int choice_move;

    GameObject clickedGameObject;
    GameObject[] action;

    GameObject cmobj;
    CreateMap CMinfo;

    int apnum;
    int renum;

    private bool followmouse;
    private int tilenum;

    private float tile_x;
    private float tile_y;

    Vector3 mousepos;
    Vector3 vec;


    public GameObject unit_click;
    public Transform parent;
    public GameObject base_point_unit;
    private GameObject unitclick;
    float masume_size = 4.5f;

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
        if (act1.activeSelf)
        {
            //弓兵とカタパルトは城を攻撃できる
            if (unit.name == "Earcher(Clone)" || unit.name == "Ecatapalt(Clone)")
            {
                //攻撃か移動か変更
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Destroy_Range();
                    choice_move++;
                    if (choice_move > 1)
                    {
                        choice_move = 0;
                    }
                }
                switch (choice_move)
                {
                    case 0://移動
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
                                        if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                                        {
                                            if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                                            {
                                                clickedGameObject = hit2d.transform.gameObject;
                                                Debug.Log(clickedGameObject.name);
                                                if (clickedGameObject.name != "mountain(Clone)"
                                                 && clickedGameObject.name != "resource(Clone)"
                                                 && clickedGameObject.name != "castle1(Clone)"
                                                 && clickedGameObject.name != "castle2(Clone)"
                                                 && clickedGameObject.name != "area2(Clone)"
                                                 && clickedGameObject.name != "Einfantry(Clone)"
                                                 && clickedGameObject.name != "Earcher(Clone)"
                                                 && clickedGameObject.name != "Ecatapalt(Clone)"
                                                 && clickedGameObject.name != "Pinfantry(Clone)"
                                                 && clickedGameObject.name != "Parcher(Clone)"
                                                 && clickedGameObject.name != "Pcatapalt(Clone)")
                                                {
                                                    cmobj = GameObject.Find("map");
                                                    CMinfo = cmobj.GetComponent<CreateMap>();
                                                    apnum = CMinfo.Now_EAP;
                                                    renum = CMinfo.Now_EResource;
                                                    //APの量を調べて足りるなら移動
                                                    apnum = apnum - move_ap;
                                                    if (apnum >= 0)
                                                    {
                                                        CMinfo.EChange_REAP(apnum, renum);
                                                        unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                                    }
                                                    //clickmove = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        pushmouse = Input.GetMouseButtonDown(0);
                        break;
                    case 1://攻撃
                        //Vector3 pos = parent.transform.localPosition;
                        ////弓兵処理
                        //if (this.gameObject.name == "Earcher(Clone)")
                        //{
                        //    Destroy_Range();
                        //    Destroy_Range();
                        //    for (float x = -masume_size * 2; x <= +masume_size * 2; x += masume_size)
                        //    {
                        //        for (float y = -masume_size * 2; y <= +masume_size * 2; y += masume_size)
                        //        {
                        //            unitclick = Instantiate(unit_click, new Vector3(pos.x + x, pos.y + y, 14.0f), Quaternion.identity, parent) as GameObject;
                        //        }

                        //    }
                        //}
                        ////カタパルト処理
                        //else if (this.gameObject.name == "Ecatapalt(Clone)")
                        //{
                        //    Destroy_Range();
                        //    Destroy_Range();
                        //    for (float x = -masume_size * 4; x <= +masume_size * 4; x += masume_size)
                        //    {
                        //        for (float y = -masume_size * 4; y <= +masume_size * 4; y += masume_size)
                        //        {
                        //            if (x >= -masume_size * 1 && x <= masume_size * 1 && y >= -masume_size * 1 && y <= masume_size * 1)
                        //            {

                        //            }
                        //            else
                        //            {
                        //                unitclick = Instantiate(unit_click, new Vector3(pos.x + x, pos.y + y, 14.0f), Quaternion.identity, parent) as GameObject;
                        //            }
                        //        }
                        //    }
                        //}
                        if (Input.GetMouseButton(0))
                        {
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                            clickedGameObject = hit2d.transform.gameObject;
                            Debug.Log(clickedGameObject.name);
                            if (clickedGameObject.name == "Pinfantry(Clone)"
                             || clickedGameObject.name == "Parcher(Clone)"
                             || clickedGameObject.name == "Pcatapalt(Clone)")
                            {
                                Debug.Log("ユニット攻撃");
                            }
                            else if (clickedGameObject.name == "castle2(Clone)")
                            {
                                Debug.Log("城攻撃");
                            }
                        }
                        break;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    act1.SetActive(false);
                }
            }
            else if (unit.name == "Einfantry(Clone)")
            {
                //攻撃か移動か変更
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Destroy_Range();
                    choice_move++;
                    if (choice_move > 1)
                    {
                        choice_move = 0;
                    }
                }
                switch (choice_move)
                {
                    case 0://移動
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
                                        if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                                        {
                                            if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                                            {
                                                clickedGameObject = hit2d.transform.gameObject;
                                                Debug.Log(clickedGameObject.name);
                                                if (clickedGameObject.name != "mountain(Clone)"
                                                 && clickedGameObject.name != "castle1(Clone)"
                                                 && clickedGameObject.name != "castle2(Clone)"
                                                 && clickedGameObject.name != "area2(Clone)"
                                                 && clickedGameObject.name != "Einfantry(Clone)"
                                                 && clickedGameObject.name != "Earcher(Clone)"
                                                 && clickedGameObject.name != "Ecatapalt(Clone)"
                                                 && clickedGameObject.name != "Pinfantry(Clone)"
                                                 && clickedGameObject.name != "Parcher(Clone)"
                                                 && clickedGameObject.name != "Pcatapalt(Clone)")
                                                {
                                                    cmobj = GameObject.Find("map");
                                                    CMinfo = cmobj.GetComponent<CreateMap>();
                                                    apnum = CMinfo.Now_EAP;
                                                    renum = CMinfo.Now_EResource;
                                                    if (clickedGameObject.name == "resource(Clone)")
                                                    {
                                                        Debug.Log("資源確保");
                                                        renum += 5;
                                                        CMinfo.EChange_REAP(apnum, renum);
                                                    }
                                                    else
                                                    {
                                                        //APの量を調べて足りるなら移動
                                                        apnum = apnum - move_ap;
                                                        if (apnum >= 0)
                                                        {
                                                            CMinfo.EChange_REAP(apnum, renum);
                                                            unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                                        }
                                                        //clickmove = false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        pushmouse = Input.GetMouseButtonDown(0);
                        break;
                    case 1://攻撃
                        //Vector3 pos = parent.transform.localPosition;
                        //if (this.gameObject.name == "Einfantry(Clone)")
                        //{
                        //    Destroy_Range();
                        //    Destroy_Range();
                        //    for (float x = -masume_size; x <= +masume_size; x += masume_size)
                        //    {
                        //        for (float y = -masume_size; y <= +masume_size; y += masume_size)
                        //        {
                        //            unitclick = Instantiate(unit_click, new Vector3(pos.x + x, pos.y + y, 14.0f), Quaternion.identity, parent) as GameObject;

                        //        }
                        //    }

                        //    Debug.Log("クリックされたぞい。");

                        //    // Destroy(unitclick, 1);
                        //}
                        if (Input.GetMouseButton(0))
                        {
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                            clickedGameObject = hit2d.transform.gameObject;
                            Debug.Log(clickedGameObject.name);
                            if (clickedGameObject.name == "Pinfantry(Clone)"
                             || clickedGameObject.name == "Parcher(Clone)"
                             || clickedGameObject.name == "Pcatapalt(Clone)")
                            {
                                Debug.Log("攻撃");
                            }
                        }
                        break;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    act1.SetActive(false);
                }
            }
        }
    }

    private void Destroy_Range()
    {
        GameObject[] unitclick = GameObject.FindGameObjectsWithTag("Respawn");

        //if (unit_click.activeSelf)
        //{
        //    //var unitclick = Instantiate(unit_click) as GameObject;
        //    foreach (GameObject range_child in unitclick)
        //    {
        //        Destroy(range_child);
        //    }
        //}
    }

    //ユニットを選択する
    public void EUnit_Serect()
    {
        Destroy_Range();
        action = GameObject.FindGameObjectsWithTag("Eact");
        foreach (GameObject act in action)
        {
            Debug.Log("actタグを持ったオブジェクト名：" + act.name);
            act.SetActive(false);
        }
        act1.SetActive(true);
        if (act1.activeSelf)
        {
            choice_move = 0;
        }
    }
}
