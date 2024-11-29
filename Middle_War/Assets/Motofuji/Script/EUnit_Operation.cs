using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EUnit_Operation : PlayerUnit_Base
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

    //public GameObject unit_click;
    //public Transform parent;
    //public GameObject base_point_unit;
    private GameObject unitclick;
    float masume_size = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        Unit_X = unit.transform.position.x;
        Unit_Y = unit.transform.position.y;
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = unit.transform.position.z;
        SR = unit.GetComponent<SpriteRenderer>();
        component_Start();
        UC = mapobj.GetComponent<uniteClick>();
        TC = mapobj.GetComponent<Turn_change>();
    }

    // Update is called once per frame
    void Update()
    {
        if (act1.activeSelf)
        {
            //ユニットをマウスの位置のタイルに移動させる
            if (Input.GetMouseButtonDown(0))
            {
                //マウスの位置を取得
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //マウスの位置にあるオブジェクトを取得
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                //マウスの座標をマップ座標にそろえる
                mousepos.x = mousepos.x + 54;
                mousepos.y = -mousepos.y + 54;
                mousepos.z = unit.transform.position.z;
                //取得したオブジェクトのマップ位置を取得
                tile_x = (unit.transform.position.x + 54) / (4.0f + 0.5f);
                tile_y = (-unit.transform.position.y + 54) / (4.0f + 0.5f);
                //弓兵とカタパルトは城を攻撃できる
                if (unit.name == "Earcher(Clone)")
                {
                    //マウスの座標に"unit"のタグを持つオブジェクトがいる場合
                    if (clickedGameObject.CompareTag("unit"))
                    {
                        //attack_cntが0なら攻撃する
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 2, 0, attack, clickedGameObject, unit))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //マウスの座標に城がいる場合
                    if (clickedGameObject.name == "castle1(Clone)")
                    {
                        //attack_cntが0なら攻撃する
                        if (attack_cnt == 0)
                        {
                            if (Attack_Castle(unit.transform.position, clickedGameObject.transform.position, 2, 0, attack, unit, ECH, PCH))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //マウスの座標に移動可能な場所があるなら移動する
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit, CM);
                }
                else if (unit.name == "Ecatapalt(Clone)")
                {
                    //マウスの座標に"unit"のタグを持つオブジェクトがいる場合
                    if (clickedGameObject.CompareTag("unit"))
                    {
                        //attack_cntが0なら攻撃する
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 4, 2, attack, clickedGameObject, unit))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //マウスの座標に城がいる場合
                    if (clickedGameObject.name == "castle1(Clone)")
                    {
                        //attack_cntが0なら攻撃する
                        if (attack_cnt == 0)
                        {
                            if (Attack_Castle(unit.transform.position, clickedGameObject.transform.position, 4, 2, attack, unit, ECH, PCH))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //マウスの座標に移動可能な場所があるなら移動する
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit, CM);
                }
                else if (unit.name == "Einfantry(Clone)")
                {
                    //マウスの座標に"unit"のタグを持つオブジェクトがいる場合
                    if (clickedGameObject.CompareTag("unit"))
                    {
                        //attack_cntが0なら攻撃する
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 1, 0, attack, clickedGameObject, unit))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //マウスの座標に移動可能な場所があるなら移動する
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit, CM);
                }
            }
        }
        pushmouse = Input.GetMouseButtonDown(0);
        //右クリックでユニットの選択を解除
        if (Input.GetMouseButtonDown(1))
        {
            act1.SetActive(false);
            UC.EDlete();
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

    //ユニットがクリックされた時
    public void EUnit_Serect()
    {
        //ゲーム内のターンが自分の場合
        if (TC.nowturn == 1)
        {
            Destroy_Range();
            //"Eact"のTagが付いているオブジェクトのアクティブを全てfalseにする
            action = GameObject.FindGameObjectsWithTag("Eact");
            foreach (GameObject act in action)
            {
                Debug.Log("actタグを持ったオブジェクト名：" + act.name);
                act.SetActive(false);
            }
            //クリックされたユニットだけアクティブをtrueにする
            act1.SetActive(true);
            //クリックされたユニットのHPと移動にかかるAP消費量の情報をUIに表示させる
            UC.Eunite_Serect(unit, hp, move_ap);
        }
    }

    public void HitAttack(int hit)
    {
        //攻撃された攻撃力分HPを減らす
        hit_anim.SetBool("hit", true);
        hp -= hit;
    }

    public void hit_anim_stop()
    {
        hit_anim.SetBool("hit", false);
        //HPが0より小さいならユニットを破壊する
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
