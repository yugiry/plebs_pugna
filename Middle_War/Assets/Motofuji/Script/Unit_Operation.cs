using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Operation : PlayerUnit_Base
{
    private SpriteRenderer SR { get; set; }
    int colorchange_time;

    public Animator hit_anim;

    public GameObject unit;
    public GameObject act1;
    public float Unit_X;
    public float Unit_Y;
    private bool pushmouse;

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

    Turn_change TC;

    private bool followmouse;
    private int tilenum;

    private float tile_x;
    private float tile_y;

    Vector3 mousepos;
    Vector3 vec;

    GameObject IMS;
    AudioSource imsAS;

    GameObject IAS;//INFANTRY_AUDIO_SOUND
    GameObject AAS;//ARCHER_AUDIO_SOUND
    GameObject CAS;//CATAPALT_AUDIO_SOUND
    AudioSource iasAS;
    AudioSource aasAS;
    AudioSource casAS;

    public GameObject attack_range;
    public GameObject move_range;
    public Transform parent;
    public GameObject base_point_unit;
    private GameObject unitclick;
    float masume_size = 4.5f;
    New_range_hyouji NR;
    public int choice_range = 0;

    // Start is called before the first frame update
    void Start()
    {
        Unit_X = unit.transform.position.x;
        Unit_Y = unit.transform.position.y;
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = unit.transform.position.z;
        mapobj = GameObject.Find("map");
        UC = mapobj.GetComponent<uniteClick>();
        TC = mapobj.GetComponent<Turn_change>();
        SR = unit.GetComponent<SpriteRenderer>();
        component_Start();
        IMS = GameObject.Find("INFANTRY_MOVE_SE");
        imsAS = IMS.GetComponent<AudioSource>();
        IAS = GameObject.Find("INFANTRY_ATTACK_SE");
        AAS = GameObject.Find("ARCHER_ATTACK_SE");
        CAS = GameObject.Find("CATAPALT_ATTACK_SE");
        iasAS = IAS.GetComponent<AudioSource>();
        aasAS = AAS.GetComponent<AudioSource>();
        casAS = CAS.GetComponent<AudioSource>();
        NR = GetComponent<New_range_hyouji>();
        SMR = GetComponent<Show_Move_Range>();
    }

    // Update is called once per frame
    void Update()
    {
        if (act1.activeSelf)
        {
            //ユニットをマウスの位置のタイルに移動させる
            if (Input.GetMouseButtonDown(0))
            {
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("移動1");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.Log("移動2");
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                Debug.Log("移動3");
                clickedGameObject = hit2d.transform.gameObject;
                Debug.Log("移動4");
                mousepos.x = mousepos.x + 54;
                mousepos.y = -mousepos.y + 54;
                mousepos.z = unit.transform.position.z;
                tile_x = (unit.transform.position.x + 54) / (4.0f + 0.5f);
                tile_y = (-unit.transform.position.y + 54) / (4.0f + 0.5f);
                tile_x = (float)Math.Round(tile_x, MidpointRounding.AwayFromZero);
                tile_y = (float)Math.Round(tile_y, MidpointRounding.AwayFromZero);
                //弓兵
                if (unit.name == "Parcher(Clone)")
                {
                    //マウスの位置にあるタイルを探して攻撃できる敵ユニットがいるか確認
                    if (clickedGameObject.tag == "Eunit")
                    {
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 2, 0, attack, clickedGameObject, unit))
                            {
                                aasAS.Play();
                                attack_cnt++;
                            }
                        }
                    }
                    if (clickedGameObject.name == "castle2(Clone)")
                    {
                        if (attack_cnt == 0)
                        {
                            if (Attack_Castle(unit.transform.position, clickedGameObject.transform.position, 2, 0, attack, unit, ECH, PCH))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //マウスの位置にあるタイルを探して移動できる場所があるか確認
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit, mapobj, imsAS);
                }
                //カタパルト
                else if (unit.name == "Pcatapalt(Clone)")
                {
                    //マウスの位置にあるタイルを探して攻撃できる敵ユニットがいるか確認
                    if (clickedGameObject.tag == "Eunit")
                    {
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 4, 1, attack, clickedGameObject, unit))
                            {
                                casAS.Play();
                                attack_cnt++;
                            }
                        }
                    }
                    if (clickedGameObject.name == "castle2(Clone)")
                    {
                        if (attack_cnt == 0)
                        {
                            if (Attack_Castle(unit.transform.position, clickedGameObject.transform.position, 4, 1, attack, unit, ECH, PCH))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //マウスの位置にあるタイルを探して移動できる場所があるか確認
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit, mapobj, imsAS);
                }
                //歩兵
                else if (unit.name == "Pinfantry(Clone)")
                {
                    //マウスの位置にあるタイルを探して攻撃できる敵ユニットがいるか確認
                    if (clickedGameObject.tag == "Eunit")
                    {
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 1, 0, attack, clickedGameObject, unit))
                            {
                                iasAS.Play();
                                attack_cnt++;
                            }
                        }
                    }
                    Debug.Log("移動");
                    //マウスの位置にあるタイルを探して移動できる場所があるか確認
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit, mapobj, imsAS);
                }
            }
            pushmouse = Input.GetMouseButtonDown(0);
            if (Input.GetMouseButtonDown(1))
            {
                act1.SetActive(false);
                UC.PDlete();
                NR.Destroy_Range();
                SMR.Destroy_Move_Range();
            }
        }
    }

    //ユニットを選択する
    public void Unit_Serect()
    {
        if (TC.nowturn == 0)
        {
            action = GameObject.FindGameObjectsWithTag("act");
            foreach (GameObject act in action)
            {
                Debug.Log("actタグを持ったオブジェクト名：" + act.name);
                act.SetActive(false);
            }
            act1.SetActive(true);
            choice_move = 0;
            NR.Click_unit();
            tile_x = (unit.transform.position.x + 54) / (4.0f + 0.5f);
            tile_y = (-unit.transform.position.y + 54) / (4.0f + 0.5f);
            tile_x = (float)Math.Round(tile_x, MidpointRounding.AwayFromZero);
            tile_y = (float)Math.Round(tile_y, MidpointRounding.AwayFromZero);
            SMR.Summon_Move_Range((int)tile_x, (int)tile_y);
            UC.Punite_Serect(unit, hp, move_ap);
        }
    }

    

    public void HitAttack(int hit)
    {
        hit_anim.SetBool("hit", true);
        hp -= hit;
    }

    public void hit_anim_stop()
    {
        hit_anim.SetBool("hit", false);
        if (hp <= 0)
        {
            Destroy(unit);
        }
    }

    public void SetAttackCnt()
    {
        attack_cnt = 0;
    }
}
