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

    GameObject tcobj;
    Turn_change TC;

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
                    clickedGameObject = hit2d.transform.gameObject;
                    //マウスの位置にあるタイルを探して攻撃できる敵ユニットがいるか確認
                    if (clickedGameObject.CompareTag("Eunit"))
                    {
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 2, 0, attack, clickedGameObject, unit))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    if (clickedGameObject.name == "castle2(Clone)")
                    {
                        if (attack_cnt == 0)
                        {
                            if (Attack_Castle(unit.transform.position, clickedGameObject.transform.position, 2, 0, attack, unit))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //マウスの位置にあるタイルを探して移動できる場所があるか確認
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit);
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
                    clickedGameObject = hit2d.transform.gameObject;
                    //マウスの位置にあるタイルを探して攻撃できる敵ユニットがいるか確認
                    if (clickedGameObject.CompareTag("Eunit"))
                    {
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 4, 1, attack, clickedGameObject, unit))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    if (clickedGameObject.name == "castle2(Clone)")
                    {
                        if (attack_cnt == 0)
                        {
                            if (Attack_Castle(unit.transform.position, clickedGameObject.transform.position, 4, 1, attack, unit))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //マウスの位置にあるタイルを探して移動できる場所があるか確認
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit);
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
                    clickedGameObject = hit2d.transform.gameObject;
                    //マウスの位置にあるタイルを探して攻撃できる敵ユニットがいるか確認
                    if (clickedGameObject.CompareTag("Eunit"))
                    {
                        vec.x = Mathf.Abs(unit.transform.position.x - clickedGameObject.transform.position.x);
                        vec.y = Mathf.Abs(unit.transform.position.y - clickedGameObject.transform.position.y);
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 1, 0, attack, clickedGameObject, unit))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //マウスの位置にあるタイルを探して移動できる場所があるか確認
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit);
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
