using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class PlayerUnit_Base : MonoBehaviour
{
    //タイル設置の最初の位置
    [NonSerialized] public float SetTileStart_X = -54;
    [NonSerialized] public float SetTileStart_Y = 54;
    [NonSerialized] public float SetTile_Z = 20;
    //タイルの大きさ
    [NonSerialized] public float TILESIZE_X = 4;
    [NonSerialized] public float TILESIZE_Y = 4;
    //マップサイズ
    [NonSerialized] public int MAPSIZE_X = 25;
    [NonSerialized] public int MAPSIZE_Y = 25;
    //タイル間の長さ
    [NonSerialized] public float TILESPACE = 0.5f;

    [NonSerialized] public Pcastlehp PCH;
    [NonSerialized] public Ecastlehp ECH;

    [NonSerialized] public GameObject mapobj;
    [NonSerialized] public CreateMap CM;

    GameObject rcobj;
    [NonSerialized] public Resource_Controll RC;

    [NonSerialized] public int apnum;
    [NonSerialized] public int renum;

    [NonSerialized] public Vector3 move_pos;
    [NonSerialized] public Vector3 unit_pos;

    [NonSerialized] public float MOVE_SPEED = 0.5f;

    [NonSerialized] public float vec_x;
    [NonSerialized] public float vec_y;

    [NonSerialized] public Unit_Tile_Check UTC;
    [NonSerialized] public TileInfo TI;
    [NonSerialized] public UnitTile UT;
    [NonSerialized] public GameObject[] resource;

    [NonSerialized] public Show_Move_Range SMR;

    public void component_Start()
    {
        mapobj = GameObject.Find("map");
        CM = mapobj.GetComponent<CreateMap>();
        PCH = mapobj.GetComponent<Pcastlehp>();
        ECH = mapobj.GetComponent<Ecastlehp>();
    }

    //敵ユニットへの攻撃行動(座標１、座標２、攻撃の最大範囲、攻撃の最小範囲、攻撃力、クリックしたオブジェクト、今選択しているオブジェクト)
    public bool Attack_Unit(Vector3 p1, Vector3 p2, float max, float min, int attack, GameObject Cobj, GameObject Uobj)
    {
        Vector3 v;
        //攻撃したいオブジェクトまでのベクトル距離を計算
        v.x = p1.x - p2.x;
        v.y = p1.y - p2.y;
        //ベクトル距離を絶対値でそろえる
        v.x = Mathf.Abs(v.x);
        v.y = Mathf.Abs(v.y);
        //攻撃範囲に攻撃したいオブジェクトがいるか確認
        if (v.x <= max * (TILESIZE_X + TILESPACE) && v.y <= max * (TILESIZE_Y + TILESPACE))
        {
            if (v.x >= min * (TILESIZE_X + TILESPACE) || v.y >= min * (TILESIZE_Y + TILESPACE))
            {
                switch (Uobj.tag)
                {
                    case "unit":
                        Cobj.GetComponent<EUnit_Operation>().HitAttack(attack);
                        break;
                    case "Eunit":
                        Cobj.GetComponent<Unit_Operation>().HitAttack(attack);
                        break;
                }
                return true;
            }
        }
        return false;
    }

    //城への攻撃行動(座標１、座標２、攻撃の最大範囲、攻撃の最小範囲、攻撃力、今選択しているオブジェクト)
    public bool Attack_Castle(Vector3 p1, Vector3 p2, float max, float min, int attack, GameObject Uobj, Ecastlehp ech, Pcastlehp pch)
    {
        ECH = ech;
        PCH = pch;
        Vector3 v;
        //攻撃したいオブジェクトまでのベクトル距離を計算
        v.x = p1.x - p2.x;
        v.y = p1.y - p2.y;
        //ベクトル距離を絶対値でそろえる
        v.x = Mathf.Abs(v.x);
        v.y = Mathf.Abs(v.y);
        //攻撃範囲に攻撃したいオブジェクトがいるか確認
        if (v.x <= max * (TILESIZE_X + TILESPACE) && v.y <= max * (TILESIZE_Y + TILESPACE))
        {
            if (v.x >= min * (TILESIZE_X + TILESPACE) || v.y >= min * (TILESIZE_Y + TILESPACE))
            {
                switch (Uobj.tag)
                {
                    case "unit":
                        ECH.HitAttack(attack);
                        break;
                    case "Eunit":
                        PCH.HitAttack(attack);
                        break;
                }
                return true;
            }
        }
        return false;
    }

    //ユニットの移動(ユニットの座標x、ユニットの座標y、マウスの座標、 移動に使うAP、クリックしたオブジェクト、今選択しているオブジェクト、マップオブジェクト、オーディオソース)
    public void Move_Unit(float tx, float ty, Vector3 mousepos, int m_AP, GameObject Cobj, GameObject Uobj, GameObject MO, AudioSource audios)
    {
        CM = MO.GetComponent<CreateMap>();
        int _x = (int)tx, _y = (int)ty;
        int move_x, move_y;
        UTC = MO.GetComponent<Unit_Tile_Check>();
        UT = Uobj.GetComponent<UnitTile>();
        SMR = Uobj.GetComponent<Show_Move_Range>();
        Debug.Log("移動スタート");
        for (int i = 0; i < 4; i++)
        {
            int _dx = 0, _dy = 0;
            switch (i)
            {
                case 0:
                    _dy = -1;
                    break;
                case 1:
                    _dx = -1;
                    break;
                case 2:
                    _dx = 1;
                    break;
                case 3:
                    _dy = 1;
                    break;
            }
            move_x = _x + _dx;
            move_y = _y + _dy;
            if (mousepos.x > (move_x * 4.5f) - 3.35f && mousepos.x < (move_x * 4.5f) + 3.35f)
            {
                if (mousepos.y > (move_y * 4.5f) - 3.35f && mousepos.y < (move_y * 4.5f) + 3.35f)
                {
                    Debug.Log(Cobj.name);
                    switch (Uobj.name)
                    {
                        case "Pinfantry(Clone)":
                            if (Cobj.name == "grass(Clone)" || Cobj.name == "area1(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //APの量を調べて足りるなら移動
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    SMR.Destroy_Move_Range();
                                    UTC.tile[_x + _y * 25] = false;
                                    UTC.tile[move_x + move_y * 25] = true;
                                    UT.Unit_TileNum = move_x + move_y * 25;
                                    CM.PChange_REAP(apnum, renum);
                                    Now_Move_Anim(move_x, move_y, Uobj);
                                    audios.Play();
                                    SMR.Summon_Move_Range(move_x, move_y);
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                Debug.Log("移動2");
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //APの量を調べて足りるなら移動
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    SMR.Destroy_Move_Range();
                                    UTC.tile[_x + _y * 25] = false;
                                    UTC.tile[move_x + move_y * 25] = true;
                                    UT.Unit_TileNum = move_x + move_y * 25;
                                    CM.PChange_REAP(apnum, renum);
                                    Now_Move_Anim(move_x, move_y, Uobj);
                                    audios.Play();
                                    SMR.Summon_Move_Range(move_x, move_y);
                                }
                            }
                            else if (Cobj.name == "resource(Clone)")
                            {
                                Debug.Log("移動3");
                                Debug.Log("資源確保");
                                RC = Cobj.GetComponent<Resource_Controll>();
                                RC.PGetResource();
                            }
                            break;
                        case "Einfantry(Clone)":
                            if (Cobj.name == "grass(Clone)" || Cobj.name == "area2(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //APの量を調べて足りるなら移動
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    SMR.Destroy_Move_Range();
                                    UTC.tile[_x + _y * 25] = false;
                                    UTC.tile[move_x + move_y * 25] = true;
                                    UT.Unit_TileNum = move_x + move_y * 25;
                                    CM.EChange_REAP(apnum, renum);
                                    Now_Move_Anim(move_x, move_y, Uobj);
                                    audios.Play();
                                    SMR.Summon_Move_Range(move_x, move_y);
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //APの量を調べて足りるなら移動
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    SMR.Destroy_Move_Range();
                                    UTC.tile[_x + _y * 25] = false;
                                    UTC.tile[move_x + move_y * 25] = true;
                                    UT.Unit_TileNum = move_x + move_y * 25;
                                    CM.EChange_REAP(apnum, renum);
                                    Now_Move_Anim(move_x, move_y, Uobj);
                                    audios.Play();
                                    SMR.Summon_Move_Range(move_x, move_y);
                                }
                            }
                            else if (Cobj.name == "resource(Clone)")
                            {
                                Debug.Log("資源確保");
                                RC = Cobj.GetComponent<Resource_Controll>();
                                RC.EGetResource();
                            }
                            break;
                        case "Parcher(Clone)":
                        case "Pcatapalt(Clone)":
                            if (Cobj.name == "grass(Clone)" || Cobj.name == "area1(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //APの量を調べて足りるなら移動
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    SMR.Destroy_Move_Range();
                                    UTC.tile[_x + _y * 25] = false;
                                    UTC.tile[move_x + move_y * 25] = true;
                                    UT.Unit_TileNum = move_x + move_y * 25;
                                    CM.PChange_REAP(apnum, renum);
                                    Now_Move_Anim(move_x, move_y, Uobj);
                                    audios.Play();
                                    SMR.Summon_Move_Range(move_x, move_y);
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //APの量を調べて足りるなら移動
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    SMR.Destroy_Move_Range();
                                    UTC.tile[_x + _y * 25] = false;
                                    UTC.tile[move_x + move_y * 25] = true;
                                    UT.Unit_TileNum = move_x + move_y * 25;
                                    CM.PChange_REAP(apnum, renum);
                                    Now_Move_Anim(move_x, move_y, Uobj);
                                    audios.Play();
                                    SMR.Summon_Move_Range(move_x, move_y);
                                }
                            }
                            break;
                        case "Earcher(Clone)":
                        case "Ecatapalt(Clone)":
                            if (Cobj.name == "grass(Clone)" || Cobj.name == "area2(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //APの量を調べて足りるなら移動
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    SMR.Destroy_Move_Range();
                                    UTC.tile[_x + _y * 25] = false;
                                    UTC.tile[move_x + move_y * 25] = true;
                                    UT.Unit_TileNum = move_x + move_y * 25;
                                    CM.EChange_REAP(apnum, renum);
                                    Now_Move_Anim(move_x, move_y, Uobj);
                                    audios.Play();
                                    SMR.Summon_Move_Range(move_x, move_y);
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //APの量を調べて足りるなら移動
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    SMR.Destroy_Move_Range();
                                    UTC.tile[_x + _y * 25] = false;
                                    UTC.tile[move_x + move_y * 25] = true;
                                    UT.Unit_TileNum = move_x + move_y * 25;
                                    CM.EChange_REAP(apnum, renum);
                                    Now_Move_Anim(move_x, move_y, Uobj);
                                    audios.Play();
                                    SMR.Summon_Move_Range(move_x, move_y);
                                }
                            }
                            break;
                    }
                }
            }
        }
    }

    void Now_Move_Anim(float x, float y, GameObject obj)
    {
        move_pos = new Vector3(-54 + x * 4.5f, 54 - y * 4.5f, 14.0f);
        unit_pos = obj.transform.position;
        vec_x = move_pos.x - unit_pos.x;
        vec_y = move_pos.y - unit_pos.y;

        //移動する方向を調べる
        if (vec_y >= 2.5f)//上
        {
            StartCoroutine("MoveUp");
        }
        else if (vec_y <= -2.5f)//下
        {
            StartCoroutine("MoveDown");
        }
        else if (vec_x >= 2.5f)//右
        {
            StartCoroutine("MoveRight");
        }
        else if (vec_x <= -2.5f)//左
        {
            StartCoroutine("MoveLeft");
        }
    }

    IEnumerator MoveUp()
    {
        while (transform.position.y < move_pos.y)
        {
            transform.Translate(0, MOVE_SPEED, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator MoveDown()
    {
        while (transform.position.y > move_pos.y)
        {
            transform.Translate(0, -MOVE_SPEED, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator MoveRight()
    {
        while (transform.position.x < move_pos.x)
        {
            transform.Translate(MOVE_SPEED, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator MoveLeft()
    {
        while (transform.position.x > move_pos.x)
        {
            transform.Translate(-MOVE_SPEED, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
