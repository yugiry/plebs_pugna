using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Operation : PlayerUnit_Base
{
    public GameObject unit;
    public GameObject act1;
    public float Unit_X;
    public float Unit_Y;
    private bool pushmouse;

    GameObject ucobj;
    uniteClick UC;

    public int hp;
    public int attack;
    public int spawn_ap;
    public int spawn_resource;
    public int move_ap;
    public int choice_move;
    public int attack_cnt;

    GameObject clickedGameObject;
    GameObject[] action;

    GameObject cmobj;
    CreateMap CMinfo;

    GameObject rcobj;
    Resource_Controll RC;

    GameObject tcobj;
    Turn_change TC;

    GameObject euoobj;
    EUnit_Operation EUO;

    GameObject chobj;
    Ecastlehp ECH;

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
            //弓兵
            if (unit.name == "Parcher(Clone)")
            {
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
                    //マウスの位置にあるタイルを探して攻撃できる敵ユニットがいるか確認
                    clickedGameObject = hit2d.transform.gameObject;
                    if (clickedGameObject.CompareTag("Eunit"))
                    {
                        vec.x = Mathf.Abs(unit.transform.position.x - clickedGameObject.transform.position.x);
                        vec.y = Mathf.Abs(unit.transform.position.y - clickedGameObject.transform.position.y);
                        if (vec.x < 10.5f && vec.y < 10.5f)
                        {
                            if (attack_cnt == 0)
                            {
                                EUO = clickedGameObject.GetComponent<EUnit_Operation>();
                                Debug.Log("ユニット攻撃");
                                EUO.HitAttack(attack);
                                attack_cnt++;
                            }
                        }
                    }
                    if (clickedGameObject.name == "castle2(Clone)")
                    {
                        vec.x = Mathf.Abs(unit.transform.position.x - clickedGameObject.transform.position.x);
                        vec.y = Mathf.Abs(unit.transform.position.y - clickedGameObject.transform.position.y);
                        if (vec.x < 10.5f && vec.y < 10.5f)
                        {
                            if (attack_cnt == 0)
                            {
                                chobj = GameObject.Find("map");
                                ECH = chobj.GetComponent<Ecastlehp>();
                                Debug.Log("城攻撃");
                                ECH.HitAttack(attack);
                                attack_cnt++;
                            }
                        }
                    }
                    //for (float i = tile_y - 2; i <= tile_y + 2; i++)
                    //{
                    //    for (float j = tile_x - 2; j <= tile_x + 2; j++)
                    //    {
                    //        if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                    //        {
                    //            if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                    //            {
                    //                clickedGameObject = hit2d.transform.gameObject;
                    //                if (clickedGameObject.name == "Einfantry(Clone)"
                    //                 || clickedGameObject.name == "Earcher(Clone)"
                    //                 || clickedGameObject.name == "Ecatapalt(Clone)")
                    //                {
                    //                    if (attack_cnt == 0)
                    //                    {
                    //                        EUO = clickedGameObject.GetComponent<EUnit_Operation>();
                    //                        Debug.Log("ユニット攻撃");
                    //                        EUO.HitAttack(attack);
                    //                        attack_cnt++;
                    //                    }
                    //                }
                    //                else if (clickedGameObject.name == "castle2(Clone)")
                    //                {
                    //                    if (attack_cnt == 0)
                    //                    {
                    //                        chobj = GameObject.Find("map");
                    //                        ECH = chobj.GetComponent<Ecastlehp>();
                    //                        Debug.Log("城攻撃");
                    //                        ECH.HitAttack(attack);
                    //                        attack_cnt++;
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    //マウスの位置にあるタイルを探して移動できる場所があるか確認
                    for (int i = 0; i < 4; i++)
                    {
                        float _x = tile_x;
                        float _y = tile_y;

                        switch (i)
                        {
                            case 0:
                                _y--;
                                break;
                            case 1:
                                _x++;
                                break;
                            case 2:
                                _y++;
                                break;
                            case 3:
                                _x--;
                                break;
                        }
                        if (mousepos.x > (_x * 4.5f) - 2 && mousepos.x < (_x * 4.5f) + 2)
                        {
                            if (mousepos.y > (_y * 4.5f) - 2 && mousepos.y < (_y * 4.5f) + 2)
                            {
                                clickedGameObject = hit2d.transform.gameObject;
                                Debug.Log(clickedGameObject.name);
                                if (clickedGameObject.name == "grass(Clone)")//移動する先が草なら
                                {
                                    cmobj = GameObject.Find("map");
                                    CMinfo = cmobj.GetComponent<CreateMap>();
                                    apnum = CMinfo.Now_PAP;
                                    renum = CMinfo.Now_PResource;
                                    //APの量を調べて足りるなら移動
                                    apnum = apnum - move_ap;
                                    if (apnum >= 0)
                                    {
                                        CMinfo.PChange_REAP(apnum, renum);
                                        unit.transform.position = new Vector3(-54 + _x * 4.5f, 54 - _y * 4.5f, 14.0f);
                                    }
                                }
                                else if (clickedGameObject.name == "water(Clone)")//移動する先が水なら
                                {
                                    cmobj = GameObject.Find("map");
                                    CMinfo = cmobj.GetComponent<CreateMap>();
                                    apnum = CMinfo.Now_PAP;
                                    renum = CMinfo.Now_PResource;
                                    //APの量を調べて足りるなら移動
                                    apnum = apnum - (move_ap + 1);
                                    if (apnum >= 0)
                                    {
                                        CMinfo.PChange_REAP(apnum, renum);
                                        unit.transform.position = new Vector3(-54 + _x * 4.5f, 54 - _y * 4.5f, 14.0f);
                                    }
                                }
                            }
                        }
                    }
                    //for (float i = tile_y - 1; i <= tile_y + 1; i++)
                    //{
                    //    for (float j = tile_x - 1; j <= tile_x + 1; j++)
                    //    {
                    //        if (((i == tile_y - 1 || i == tile_y + 1) && j == tile_x) || (i == tile_y && (j == tile_x - 1 || j == tile_x + 1)))
                    //        {
                    //            if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                    //            {
                    //                if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                    //                {
                    //                    clickedGameObject = hit2d.transform.gameObject;
                    //                    Debug.Log(clickedGameObject.name);
                    //                    if (clickedGameObject.name == "grass(Clone)")//移動する先が草なら
                    //                    {
                    //                        cmobj = GameObject.Find("map");
                    //                        CMinfo = cmobj.GetComponent<CreateMap>();
                    //                        apnum = CMinfo.Now_PAP;
                    //                        renum = CMinfo.Now_PResource;
                    //                        //APの量を調べて足りるなら移動
                    //                        apnum = apnum - move_ap;
                    //                        if (apnum >= 0)
                    //                        {
                    //                            CMinfo.PChange_REAP(apnum, renum);
                    //                            unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                    //                        }
                    //                    }
                    //                    else if (clickedGameObject.name == "water(Clone)")//移動する先が水なら
                    //                    {
                    //                        cmobj = GameObject.Find("map");
                    //                        CMinfo = cmobj.GetComponent<CreateMap>();
                    //                        apnum = CMinfo.Now_PAP;
                    //                        renum = CMinfo.Now_PResource;
                    //                        //APの量を調べて足りるなら移動
                    //                        apnum = apnum - (move_ap + 1);
                    //                        if (apnum >= 0)
                    //                        {
                    //                            CMinfo.PChange_REAP(apnum, renum);
                    //                            unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }
                pushmouse = Input.GetMouseButtonDown(0);
                if (Input.GetMouseButtonDown(1))
                {
                    act1.SetActive(false);
                    ucobj = GameObject.Find("map");
                    UC = ucobj.GetComponent<uniteClick>();
                    UC.PDlete();
                }
            }
            //カタパルト
            else if (unit.name == "Pcatapalt(Clone)")
            {
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
                    //マウスの位置にあるタイルを探して攻撃できる敵ユニットがいるか確認
                    clickedGameObject = hit2d.transform.gameObject;
                    if (clickedGameObject.CompareTag("Eunit"))
                    {
                        vec.x = Mathf.Abs(unit.transform.position.x - clickedGameObject.transform.position.x);
                        vec.y = Mathf.Abs(unit.transform.position.y - clickedGameObject.transform.position.y);
                        if (vec.x <= 4 * (4.0f + 0.5f) && vec.y <= 4 * (4.0f + 0.5f))
                        {
                            if (vec.x > (4.0f + 0.5f) || vec.y > (4.0f + 0.5f))
                            {
                                if (attack_cnt == 0)
                                {
                                    EUO = clickedGameObject.GetComponent<EUnit_Operation>();
                                    Debug.Log("ユニット攻撃");
                                    EUO.HitAttack(attack);
                                    attack_cnt++;
                                }
                            }
                        }
                    }
                    if (clickedGameObject.name == "castle2(Clone)")
                    {
                        vec.x = Mathf.Abs(unit.transform.position.x - clickedGameObject.transform.position.x);
                        vec.y = Mathf.Abs(unit.transform.position.y - clickedGameObject.transform.position.y);
                        if (vec.x <= 4 * (4.0f + 0.5f) && vec.y <= 4 * (4.0f + 0.5f))
                        {
                            if (vec.x > (4.0f + 0.5f) || vec.y > (4.0f + 0.5f))
                            {
                                if (attack_cnt == 0)
                                {
                                    chobj = GameObject.Find("map");
                                    ECH = chobj.GetComponent<Ecastlehp>();
                                    Debug.Log("城攻撃");
                                    ECH.HitAttack(attack);
                                    attack_cnt++;
                                }
                            }
                        }
                    }
                    //for (float i = tile_y - 4; i <= tile_y + 4; i++)
                    //{
                    //    for (float j = tile_x - 4; j <= tile_x + 4; j++)
                    //    {
                    //        if ((j >= tile_x - 1 && j <= tile_x + 1) && (i >= tile_y - 1 && i <= tile_y + 1)) ;
                    //        else
                    //        {
                    //            if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                    //            {
                    //                if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                    //                {
                    //                    clickedGameObject = hit2d.transform.gameObject;
                    //                    if (clickedGameObject.name == "Einfantry(Clone)"
                    //                     || clickedGameObject.name == "Earcher(Clone)"
                    //                     || clickedGameObject.name == "Ecatapalt(Clone)")
                    //                    {
                    //                        if (attack_cnt == 0)
                    //                        {
                    //                            EUO = clickedGameObject.GetComponent<EUnit_Operation>();
                    //                            Debug.Log("ユニット攻撃");
                    //                            EUO.HitAttack(attack);
                    //                            attack_cnt++;
                    //                        }
                    //                    }
                    //                    else if (clickedGameObject.name == "castle2(Clone)")
                    //                    {
                    //                        if (attack_cnt == 0)
                    //                        {
                    //                            chobj = GameObject.Find("map");
                    //                            ECH = chobj.GetComponent<Ecastlehp>();
                    //                            Debug.Log("城攻撃");
                    //                            ECH.HitAttack(attack);
                    //                            attack_cnt++;
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    //マウスの位置にあるタイルを探して移動できる場所があるか確認
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
                                        if (clickedGameObject.name == "grass(Clone)")
                                        {
                                            cmobj = GameObject.Find("map");
                                            CMinfo = cmobj.GetComponent<CreateMap>();
                                            apnum = CMinfo.Now_PAP;
                                            renum = CMinfo.Now_PResource;
                                            //APの量を調べて足りるなら移動
                                            apnum = apnum - move_ap;
                                            if (apnum >= 0)
                                            {
                                                CMinfo.PChange_REAP(apnum, renum);
                                                unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                            }
                                        }
                                        else if (clickedGameObject.name == "water(Clone)")
                                        {
                                            cmobj = GameObject.Find("map");
                                            CMinfo = cmobj.GetComponent<CreateMap>();
                                            apnum = CMinfo.Now_PAP;
                                            renum = CMinfo.Now_PResource;
                                            //APの量を調べて足りるなら移動
                                            apnum = apnum - (move_ap + 1);
                                            if (apnum >= 0)
                                            {
                                                CMinfo.PChange_REAP(apnum, renum);
                                                unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                pushmouse = Input.GetMouseButtonDown(0);
                if (Input.GetMouseButtonDown(1))
                {
                    act1.SetActive(false);
                    ucobj = GameObject.Find("map");
                    UC = ucobj.GetComponent<uniteClick>();
                    UC.PDlete();
                }
            }
            //歩兵
            else if (unit.name == "Pinfantry(Clone)")
            {
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
                    //マウスの位置にあるタイルを探して攻撃できる敵ユニットがいるか確認
                    for (float i = tile_y - 1; i <= tile_y + 1; i++)
                    {
                        for (float j = tile_x - 1; j <= tile_x + 1; j++)
                        {
                            if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                            {
                                if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                                {
                                    clickedGameObject = hit2d.transform.gameObject;
                                    if (clickedGameObject.name == "Einfantry(Clone)" ||
                                        clickedGameObject.name == "Earcher(Clone)" ||
                                        clickedGameObject.name == "Ecatapalt(Clone)")
                                    {
                                        if (attack_cnt == 0)
                                        {
                                            EUO = clickedGameObject.GetComponent<EUnit_Operation>();
                                            Debug.Log("攻撃");
                                            EUO.HitAttack(attack);
                                            attack_cnt++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //マウスの位置にあるタイルを探して移動できる場所があるか確認
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
                                        if (clickedGameObject.name == "grass(Clone)")
                                        {
                                            cmobj = GameObject.Find("map");
                                            CMinfo = cmobj.GetComponent<CreateMap>();
                                            apnum = CMinfo.Now_PAP;
                                            renum = CMinfo.Now_PResource;
                                            //APの量を調べて足りるなら移動
                                            apnum = apnum - move_ap;
                                            if (apnum >= 0)
                                            {
                                                CMinfo.PChange_REAP(apnum, renum);
                                                unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                            }
                                        }
                                        else if (clickedGameObject.name == "water(Clone)")
                                        {
                                            cmobj = GameObject.Find("map");
                                            CMinfo = cmobj.GetComponent<CreateMap>();
                                            apnum = CMinfo.Now_PAP;
                                            renum = CMinfo.Now_PResource;
                                            //APの量を調べて足りるなら移動
                                            apnum = apnum - (move_ap + 1);
                                            if (apnum >= 0)
                                            {
                                                CMinfo.PChange_REAP(apnum, renum);
                                                unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                            }
                                        }
                                        else if (clickedGameObject.name == "resource(Clone)")
                                        {
                                            Debug.Log("資源確保");
                                            RC = clickedGameObject.GetComponent<Resource_Controll>();
                                            RC.PGetResource();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                pushmouse = Input.GetMouseButtonDown(0);
                
                if (Input.GetMouseButtonDown(1))
                {
                    act1.SetActive(false);
                    ucobj = GameObject.Find("map");
                    UC = ucobj.GetComponent<uniteClick>();
                    UC.PDlete();
                }
            }
        }
        if (hp <= 0)
        {
            Destroy(unit);
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
    public void Unit_Serect()
    {
        tcobj = GameObject.Find("map");
        TC = tcobj.GetComponent<Turn_change>();
        if (TC.nowturn == 0)
        {
            Destroy_Range();
            action = GameObject.FindGameObjectsWithTag("act");
            foreach (GameObject act in action)
            {
                Debug.Log("actタグを持ったオブジェクト名：" + act.name);
                act.SetActive(false);
            }
            act1.SetActive(true);
            choice_move = 0;
            ucobj = GameObject.Find("map");
            UC = ucobj.GetComponent<uniteClick>();
            UC.Punite_Serect(unit, hp, move_ap);
        }
    }

    public void HitAttack(int hit)
    {
        hp -= hit;
    }

    public void SetAttackCnt()
    {
        attack_cnt = 0;
    }
}
