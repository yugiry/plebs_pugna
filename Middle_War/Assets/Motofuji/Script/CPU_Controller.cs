using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class CPU_Controller : PlayerUnit_Base
{
    bool nowturn;
    bool map_complete;
    GameObject canmove;

    int[] research_move;

    [SerializeField] GameObject infantry;
    [SerializeField] GameObject archer;
    [SerializeField] GameObject catapalt;

    [SerializeField] GameObject unitbox;
    GameObject Sunit;

    [SerializeField] GameObject tilebox;
    Transform castle1;
    Transform castle2;

    EUnit_Operation EUO;
    Unit_Operation UO;
    UnitTile UT;

    [SerializeField] GameObject checker_box;
    GameObject area;
    Unit_Check UC;

    [SerializeField] GameObject unit_box;
    GameObject unit;
    GameObject move_checker;
    Move_Check MC;
    GameObject attack_checker;
    Attack_Check AC;

    Resource_Controll CCRC;
    Turn_change TC;

    GameObject[] move_check;
    GameObject moveobj;

    bool holizontal;
    bool vertical;

    public UI_Operate UIO;
    int surd;//ユニットの出す種類のランダム
    int urd;//どのユニットを行動させるかのランダム
    int ard;//エリアのどこに出すかのランダム
    int acrd;//CPUがユニットにする行動のランダム
    int summon_or_action;//ユニットを召喚するか行動させるかのランダム
    int mrd;//ユニットがどこに移動するかのランダム
    int hrd;//頭を良くするかのランダム

    float summon_x, summon_y;
    int unit_move_ap;

    int move_x, move_y;

    // Start is called before the first frame update
    void Start()
    {
        map_complete = false;
        mapobj = GameObject.Find("map");
        CM = mapobj.GetComponent<CreateMap>();
        TC = mapobj.GetComponent<Turn_change>();
        UTC = mapobj.GetComponent<Unit_Tile_Check>();
        research_move = new int[CM.MAPSIZE_X * CM.MAPSIZE_Y];
    }

    // Update is called once per frame
    void Update()
    {
        if (map_complete)
        {
            castle2 = tilebox.transform.Find("castle2(Clone)");
            map_complete = false;
        }

        if (nowturn)
        {
            if (CM.Now_EAP > 1)
            {
                if (UIO.EUnit_Num == 0)
                {
                    Debug.Log("ユニット無し");
                    Unit_Summon();
                }
                else
                {
                    Debug.Log("ユニット在り");
                    if (summon_or_action < 1)
                    {
                        Turn_Over();
                    }
                    else if(summon_or_action < 35)
                    {
                        Unit_Summon();
                    }
                    else if (summon_or_action < 100)
                    {
                        Random_Action();
                    }
                }
            }
            else
            {
                Turn_Over();
            }
        }
    }

    public void Map_Collect()
    {
        map_complete = true;
    }

    public void Turn_Here()
    {
        nowturn = true;
        summon_or_action = RanDom(0, 100);
    }

    //移動、強化、攻撃からランダムで一つ行動する
    void Random_Action()
    {
        urd = RanDom(0, UIO.EUnit_Num);
        unit = unit_box.transform.GetChild(urd).gameObject;
        acrd = RanDom(0, 8);
        if (unit != null)
        {
            if(acrd < 5)//移動
            {
                Unit_Move(unit);
            }
            else if(acrd < 8)//攻撃
            {
                Unit_Attack(unit);
            }
            else if(acrd < 10)//強化
            {
                //実装予定
            }
        }
    }

    //ユニット召喚
    void Unit_Summon()
    {
        surd = RanDom(0, 50);
        ard = RanDom(0, 8);
        switch (ard)
        {
            case 5:
                summon_x = -1;
                summon_y = 1;
                break;
            case 6:
                summon_x = 0;
                summon_y = 1;
                break;
            case 7:
                summon_x = 1;
                summon_y = 1;
                break;
            case 3:
                summon_x = -1;
                summon_y = 0;
                break;
            case 4:
                summon_x = 1;
                summon_y = 0;
                break;
            case 0:
                summon_x = -1;
                summon_y = -1;
                break;
            case 1:
                summon_x = 0;
                summon_y = -1;
                break;
            case 2:
                summon_x = 1;
                summon_y = -1;
                break;
        }

        area = checker_box.transform.GetChild(ard).gameObject;
        UC = area.GetComponent<Unit_Check>();
        if (!UC.OnUnit())
        {
            if (UIO.EUnit_Num < 20)
            {
                apnum = CM.Now_EAP;
                renum = CM.Now_EResource;
                if(surd < 15)
                {
                    apnum = apnum - 2;
                    if (apnum >= 0)
                    {
                        Sunit = Instantiate(infantry, new Vector3(area.transform.position.x, area.transform.position.y, 14.0f), Quaternion.identity);
                        UTC.tile[UC.tilenum] = true;
                        Sunit.GetComponent<UnitTile>().Unit_TileNum = UC.tilenum;
                        CM.EChange_REAP(apnum, renum);
                    }
                }
                else if(surd < 40)
                {
                    apnum = apnum - 6;
                    if (apnum >= 0)
                    {
                        Sunit = Instantiate(archer, new Vector3(area.transform.position.x, area.transform.position.y, 14.0f), Quaternion.identity);
                        UTC.tile[UC.tilenum] = true;
                        Sunit.GetComponent<UnitTile>().Unit_TileNum = UC.tilenum;
                        CM.EChange_REAP(apnum, renum);
                    }
                }
                else if(surd < 50)
                {
                    apnum = apnum - 10;
                    renum = renum - 10;
                    if (apnum >= 0 && renum >= 0)
                    {
                        Sunit = Instantiate(catapalt, new Vector3(area.transform.position.x, area.transform.position.y, 14.0f), Quaternion.identity);
                        UTC.tile[UC.tilenum] = true;
                        Sunit.GetComponent<UnitTile>().Unit_TileNum = UC.tilenum;
                        CM.EChange_REAP(apnum, renum);
                    }
                }
                else
                {
                    Sunit = null;
                }
                if (Sunit != null)
                {
                    Sunit.transform.parent = unitbox.transform;
                }
            }
        }
        summon_or_action = RanDom(0, 100);
    }

    void Unit_Move(GameObject obj)
    {
        int x, y;
        int dx, dy;
        UT = obj.GetComponent<UnitTile>();
        y = UT.Unit_TileNum / 25;
        x = UT.Unit_TileNum % 25;
        if(obj.name == "Cinfantry(Clone)")
        {
            hrd = 1;
        }
        else
        {
            hrd = 0;
        }
        if (hrd == 0)//頭いい
        {
            float dis_x, dis_y;
            castle1 = tilebox.transform.Find("castle1(Clone)");

            dis_x = obj.transform.position.x - castle1.transform.position.x;
            dis_y = obj.transform.position.y - castle1.transform.position.y;

            if (dis_x < 0) { holizontal = true; }//城が右方向にある
            if (dis_x > 0) { holizontal = false; }//城が左方向にある
            if (dis_y < 0) { vertical = true; }//城が下方向にある
            if (dis_y > 0) { vertical = false; }//城が上方向にある

            if (Math.Abs(dis_x) > Math.Abs(dis_y))
            {
                if (holizontal)
                {
                    dx = x + 1;
                }
                else
                {
                    dx = x - 1;
                }
                dy = y;
                if (dx < 0) dx = 0;
                if (dx > 24) dx = 24;
                if (dy < 0) dy = 0;
                if (dy > 24) dy = 24;
                if (UTC.tile[dy * 25 + dx])
                {
                    dx = x;
                    dy = y + 1;
                    if (dx < 0) dx = 0;
                    if (dx > 24) dx = 24;
                    if (dy < 0) dy = 0;
                    if (dy > 24) dy = 24;
                }
                if (!UTC.tile[dy * 25 + dx])
                {
                    switch (CM.map[dy * 25 + dx])
                    {
                        case 0://草
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - EUO.move_ap;
                            if (apnum > 0)
                            {
                                UTC.tile[y * 25 + x] = false;
                                UTC.tile[dy * 25 + dx] = true;
                                UT.Unit_TileNum = dy * 25 + dx;
                                obj.transform.position = new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * dx, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * dy, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                            }
                            break;
                        case 2://水
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - (EUO.move_ap + 1);
                            if (apnum > 0)
                            {
                                UTC.tile[y * 25 + x] = false;
                                UTC.tile[dy * 25 + dx] = true;
                                UT.Unit_TileNum = dy * 25 + dx;
                                obj.transform.position = new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * dx, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * dy, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                            }
                            break;
                    }
                }
            }
            else if (Math.Abs(dis_x) < Math.Abs(dis_y))
            {
                if(vertical)
                {
                    dy = y - 1;
                }
                else
                {
                    dy = y + 1;
                }
                dx = x;
                if (dx < 0) dx = 0;
                if (dx > 24) dx = 24;
                if (dy < 0) dy = 0;
                if (dy > 24) dy = 24;
                if (UTC.tile[dy * 25 + dx])
                {
                    dx = x + 1;
                    dy = y;
                    if (dx < 0) dx = 0;
                    if (dx > 24) dx = 24;
                    if (dy < 0) dy = 0;
                    if (dy > 24) dy = 24;
                }
                if (!UTC.tile[dy * 25 + dx])
                {
                    switch (CM.map[dy * 25 + dx])
                    {
                        case 0://草
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - EUO.move_ap;
                            if (apnum > 0)
                            {
                                UTC.tile[y * 25 + x] = false;
                                UTC.tile[dy * 25 + dx] = true;
                                UT.Unit_TileNum = dy * 25 + dx;
                                obj.transform.position = new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * dx, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * dy, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                            }
                            break;
                        case 2://水
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - (EUO.move_ap + 1);
                            if (apnum > 0)
                            {
                                UTC.tile[y * 25 + x] = false;
                                UTC.tile[dy * 25 + dx] = true;
                                UT.Unit_TileNum = dy * 25 + dx;
                                obj.transform.position = new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * dx, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * dy, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                            }
                            break;
                    }
                }
            }
            else
            {
                dy = y;
                dx = x;
                switch (RanDom(0, 2))
                {
                    case 0:
                        dy += 1;
                        break;
                    case 1:
                        dx += 1;
                        break;
                }
                if (dx < 0) dx = 0;
                if (dx > 24) dx = 24;
                if (dy < 0) dy = 0;
                if (dy > 24) dy = 24;
                if (!UTC.tile[dy * 25 + dx])
                {
                    switch (CM.map[dy * 25 + dx])
                    {
                        case 0://草
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - EUO.move_ap;
                            if (apnum > 0)
                            {
                                UTC.tile[y * 25 + x] = false;
                                UTC.tile[dy * 25 + dx] = true;
                                UT.Unit_TileNum = dy * 25 + dx;
                                obj.transform.position = new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * dx, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * dy, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                            }
                            break;
                        case 2://水
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - (EUO.move_ap + 1);
                            if (apnum > 0)
                            {
                                UTC.tile[y * 25 + x] = false;
                                UTC.tile[dy * 25 + dx] = true;
                                UT.Unit_TileNum = dy * 25 + dx;
                                obj.transform.position = new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * dx, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * dy, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                            }
                            break;
                    }
                }
            }
        }
        else if (hrd == 1)//頭悪い
        {
            mrd = RanDom(0, 4);
            switch (mrd)
            {
                case 0:
                    move_x = 0;
                    move_y = 1;
                    break;
                case 1:
                    move_x = -1;
                    move_y = 0;
                    break;
                case 2:
                    move_x = 1;
                    move_y = 0;
                    break;
                case 3:
                    move_x = 0;
                    move_y = -1;
                    break;
                default:
                    break;
            }
            dx = x + move_x;
            dy = y + move_y;
            if (dx < 0) dx = 0;
            if (dx > 24) dx = 24;
            if (dy < 0) dy = 0;
            if (dy > 24) dy = 24;
            Debug.Log("移動1");
            if (obj.name == "Cinfantry(Clone)")
            {
                if (!UTC.tile[dy * 25 + dx])
                {
                    switch (CM.map[dy * 25 + dx])
                    {
                        case 0://草
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - EUO.move_ap;
                            if (apnum > 0)
                            {
                                UTC.tile[y * 25 + x] = false;
                                UTC.tile[dy * 25 + dx] = true;
                                UT.Unit_TileNum = dy * 25 + dx;
                                obj.transform.position = new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * dx, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * dy, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                                Debug.Log("移動完了1");
                            }
                            break;
                        case 2://水
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - (EUO.move_ap + 1);
                            if (apnum > 0)
                            {
                                UTC.tile[y * 25 + x] = false;
                                UTC.tile[dy * 25 + dx] = true;
                                UT.Unit_TileNum = dy * 25 + dx;
                                obj.transform.position = new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * dx, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * dy, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                                Debug.Log("移動完了2");
                            }
                            break;
                        case 3:
                            resource = GameObject.FindGameObjectsWithTag("resource");
                            foreach (GameObject RE in resource)
                            {
                                TI = RE.GetComponent<TileInfo>();
                                if (TI.TileNum == (dy * 25 + dx))
                                {
                                    RC = RE.GetComponent<Resource_Controll>();
                                    RC.EGetResource();
                                    Debug.Log("資源回収");
                                }
                            }
                            break;
                    }
                }
            }
            else if (obj.name == "Carcher(Clone)" || obj.name == "Ccatapalt(Clone)")
            {
                if (!UTC.tile[dy * 25 + dx])
                {
                    switch (CM.map[dy * 25 + dx])
                    {
                        case 0://草
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - EUO.move_ap;
                            if (apnum > 0)
                            {
                                UTC.tile[y * 25 + x] = false;
                                UTC.tile[dy * 25 + dx] = true;
                                UT.Unit_TileNum = dy * 25 + dx;
                                obj.transform.position = new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * dx, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * dy, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                                Debug.Log("移動完了3");
                            }
                            break;
                        case 2://水
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - (EUO.move_ap + 1);
                            if (apnum > 0)
                            {
                                UTC.tile[y * 25 + x] = false;
                                UTC.tile[dy * 25 + dx] = true;
                                UT.Unit_TileNum = dy * 25 + dx;
                                obj.transform.position = new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * dx, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * dy, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                                Debug.Log("移動完了4");
                            }
                            break;
                    }
                }
            }
        }
    }

    int Unit_Attack(GameObject obj)
    {
        attack_checker = obj.transform.GetChild(1).gameObject;
        EUO = obj.GetComponent<EUnit_Operation>();
        UT = obj.GetComponent<UnitTile>();
        //ユニットへの攻撃
        if (EUO != null)
        {
            Debug.Log("攻撃1");
            if (EUO.attack_cnt == 0)
            {
                Debug.Log("攻撃2");
                AC = attack_checker.GetComponent<Attack_Check>();
                if (AC != null)
                {
                    Debug.Log("攻撃3");
                    if (AC.Can_Attack() != null)
                    {
                        Debug.Log("攻撃4");
                        switch (obj.name)
                        {
                            case "Cinfantry(Clone)":
                                if (AC.Can_Attack().tag == "unit")
                                {
                                    UO = AC.Can_Attack().GetComponent<Unit_Operation>();
                                    UO.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("攻撃4.1");
                                    summon_or_action = RanDom(0, 100);
                                    return 0;
                                }
                                break;
                            case "Carcher(Clone)":
                            case "Ccatapalt(Clone)":
                                if (AC.Can_Attack().tag == "unit")
                                {
                                    UO = AC.Can_Attack().GetComponent<Unit_Operation>();
                                    UO.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("攻撃4.4");
                                    summon_or_action = RanDom(0, 100);
                                    return 0;
                                }
                                break;
                            default:
                                int x, y;
                                y = UT.Unit_TileNum / 25;
                                x = UT.Unit_TileNum % 25;
                                PCH = mapobj.GetComponent<Pcastlehp>();
                                switch (obj.name)
                                {
                                    case "Carcher(Clone)":
                                        for (int i = y - 2; i < y + 2; i++)
                                        {
                                            for (int j = x - 2; j < x + 2; j++)
                                            {
                                                if (i >= 0 && i < 25 && j >= 0 && j < 25 && (i != y && j != x))
                                                {
                                                    if (CM.map[i * 25 + j] == 4)
                                                    {
                                                        PCH.HitAttack(EUO.attack);
                                                        EUO.attack_cnt++;
                                                        Debug.Log("攻撃4.5");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "Ccatapalt(Clone)":
                                        for (int i = y - 4; i < y + 4; i++)
                                        {
                                            for (int j = x - 4; j < x + 4; j++)
                                            {
                                                if (i >= 0 && i < 25 && j >= 0 && j < 25 && (i < y - 1 || i > y + 1 || j < x - 1 || j > x + 1))
                                                {
                                                    if (CM.map[i * 25 + j] == 4)
                                                    {
                                                        PCH.HitAttack(EUO.attack);
                                                        EUO.attack_cnt++;
                                                        Debug.Log("攻撃4.5");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                }
                                summon_or_action = RanDom(0, 100);
                                return 0;
                        }
                    }
                }
            }
        }
        return 0;
    }

    int RanDom(int min, int max)
    {
        int num = UnityEngine.Random.Range(min, max);

        return num;
    }

    public void Turn_Over()
    {
        nowturn = false;
        TC.ChangeTurn_Enemy();
        move_check = GameObject.FindGameObjectsWithTag("Eunit");
        foreach (GameObject move in move_check)
        {
            moveobj = move.transform.GetChild(0).gameObject;
            moveobj.transform.position = new Vector3(move.transform.position.x,move.transform.position.y,moveobj.transform.position.z);
        }
    }
}
