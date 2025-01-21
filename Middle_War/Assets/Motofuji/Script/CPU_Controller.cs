using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        //共通で使うスクリプトのコンポーネントなどを初期でしておく
        map_complete = false;
        mapobj = GameObject.Find("map");
        CM = mapobj.GetComponent<CreateMap>();
        TC = mapobj.GetComponent<Turn_change>();
        UTC = mapobj.GetComponent<Unit_Tile_Check>();
        PCH = mapobj.GetComponent<Pcastlehp>();
        research_move = new int[CM.MapSize_X * CM.MapSize_Y];
        for (int i = 0; i < CM.MapSize_X * CM.MapSize_Y; i++)
        {
            research_move[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //マップ生成が終了したらcastle2の位置を取得する
        if (map_complete)
        {
            //城の情報をそれぞれ取得する
            castle1 = tilebox.transform.Find("castle1(Clone)");
            castle2 = tilebox.transform.Find("castle2(Clone)");
            TI = castle1.GetComponent<TileInfo>();
            research_move[(int)TI.TileNum] = 0;
            int dx = 0, dy = 0;//調べる位置を残しておくための変数
            int summon_x, summon_y;//数値を入れるマスのマップ座標
            //マップの端から端まで調べる時の最大数
            for (int c = 0; c < 50; c++)
            {
                //マップ全てを調べる
                for (int y = 0; y < CM.MapSize_Y; y++)
                {
                    for (int x = 0; x < CM.MapSize_X; x++)
                    {
                        //今調べてるマスの数値がcと同じならそのマスの上下左右を調べる
                        if (research_move[y * CM.MapSize_Y + x] == c)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                switch (k)
                                {
                                    case 0://上
                                        dx = 0;
                                        dy = -1;
                                        break;
                                    case 1://下
                                        dx = 0;
                                        dy = 1;
                                        break;
                                    case 2://右
                                        dx = 1;
                                        dy = 0;
                                        break;
                                    case 3://左
                                        dx = -1;
                                        dy = 0;
                                        break;
                                }
                                move_x = x + dx;
                                move_y = y + dy;
                                //マップの外に出ないようにする
                                if (move_x < 0) move_x = 0;
                                if (move_x > 24) move_x = 24;
                                if (move_y < 0) move_y = 0;
                                if (move_y > 24) move_y = 24;
                                //タイルが草もしくは水でありかつユニットが居ない場合数値を置く
                                if (research_move[move_x + move_y * 25] == -1 && (CM.map[move_x + move_y * 25] == 0 || CM.map[move_x + move_y * 25] == 2))
                                    research_move[move_x + move_y * 25] = c + 1;
                            }
                        }
                    }
                }
            }
            map_complete = false;
        }

        //ターン開始
        if (nowturn)
        {
            if (CM.Now_EAP > 1)
            {
                //ステージ上のユニットの数に応じて行動を変更
                if (UIO.EUnit_Num == 0)
                {
                    //ユニットがステージ上にいないのでユニットを召喚
                    Unit_Summon();
                }
                else
                {
                    if (summon_or_action < 1)//APを貯める
                    {
                        Turn_Over();
                    }
                    else if (summon_or_action < 10)//ステージ上のユニットを増やす
                    {
                        Unit_Summon();
                    }
                    else if (summon_or_action < 100)//ユニットを行動させる
                    {
                        Unit_Action();
                    }
                }
            }
            else
            {
                //APがなくなったらターンを返す
                Turn_Over();
            }
        }
    }

    //マップ生成が終了したことを知らせる関数
    public void Map_Collect()
    {
        map_complete = true;
    }

    //ターンが回ってきていることを知らせる関数
    public void Turn_Here()
    {
        nowturn = true;
        summon_or_action = RanDom(0, 100);
    }

    //ユニットの行動
    void Unit_Action()
    {
        urd = RanDom(0, UIO.EUnit_Num);
        unit = unit_box.transform.GetChild(urd).gameObject;
        //攻撃が当たるか調べる(当たるなら攻撃)
        if (Unit_Attack(unit))
        {
            //攻撃出来ない場合は移動させる
            Unit_Move(unit);
            summon_or_action = RanDom(0, 100);
        }
    }

    //ユニット召喚
    void Unit_Summon()
    {
        //どのユニットを召喚するかをランダムで決める
        surd = RanDom(0, 50);
        //どのマスに召喚するかをランダムで決める
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

        //ランダムで決定したエリアを取得する
        area = checker_box.transform.GetChild(ard).gameObject;
        UC = area.GetComponent<Unit_Check>();
        //エリアにユニットが居るか確認
        if (!UC.OnUnit())
        {
            //マップ上にいるユニットの数が最大数になっていないか確認
            if (UIO.EUnit_Num < 20)
            {
                apnum = CM.Now_EAP;
                renum = CM.Now_EResource;
                if (surd < 15)//歩兵召喚
                {
                    apnum = apnum - 2;
                    if (apnum >= 0)
                    {
                        Sunit = Instantiate(infantry, new Vector3(area.transform.position.x, area.transform.position.y, 14.0f), Quaternion.identity);
                        UTC.tile[UC.tilenum] = true;
                        Sunit.GetComponent<UnitTile>().Unit_TileNum = UC.tilenum;
                        CM.Character(apnum, renum, 1);
                    }
                }
                else if (surd < 40)//弓兵召喚
                {
                    apnum = apnum - 6;
                    if (apnum >= 0)
                    {
                        Sunit = Instantiate(archer, new Vector3(area.transform.position.x, area.transform.position.y, 14.0f), Quaternion.identity);
                        UTC.tile[UC.tilenum] = true;
                        Sunit.GetComponent<UnitTile>().Unit_TileNum = UC.tilenum;
                        CM.Character(apnum, renum, 1);
                    }
                }
                else if (surd < 50)//カタパルト召喚
                {
                    apnum = apnum - 10;
                    renum = renum - 10;
                    if (apnum >= 0 && renum >= 0)
                    {
                        Sunit = Instantiate(catapalt, new Vector3(area.transform.position.x, area.transform.position.y, 14.0f), Quaternion.identity);
                        UTC.tile[UC.tilenum] = true;
                        Sunit.GetComponent<UnitTile>().Unit_TileNum = UC.tilenum;
                        CM.Character(apnum, renum, 1);
                    }
                }
                else
                {
                    //surdが50以上ならSunitにnullを入れる
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

    //ユニットの移動
    void Unit_Move(GameObject obj)
    {
        int x, y;
        int dx = 0, dy = 0;
        UT = obj.GetComponent<UnitTile>();
        y = UT.Unit_TileNum / 25;
        x = UT.Unit_TileNum % 25;
        hrd = RanDom(0,12);
        if (hrd < 8)//頭いい(城に向かって進軍していく)
        {
            //ユニットの位置の上下左右を調べる
            for (int k = 0; k < 4; k++)
            {
                switch (k)
                {
                    case 0://上
                        dx = 0;
                        dy = -1;
                        break;
                    case 1://下
                        dx = 0;
                        dy = 1;
                        break;
                    case 2://右
                        dx = 1;
                        dy = 0;
                        break;
                    case 3://左
                        dx = -1;
                        dy = 0;
                        break;
                }
                move_x = x + dx;
                move_y = y + dy;
                //移動先にユニットがいるか確認
                if (!UTC.tile[move_y * CM.MapSize_Y + move_x])
                {
                    //今ユニットがいる場所より進む先の数値のほうが小さかったら進む
                    if (research_move[y * CM.MapSize_Y + x] > research_move[move_y * CM.MapSize_Y + move_x] && research_move[move_y * CM.MapSize_Y + move_x] >= 0)
                    {
                        EUO = obj.GetComponent<EUnit_Operation>();
                        apnum = CM.Now_EAP;
                        renum = CM.Now_EResource;
                        switch (CM.map[move_y * CM.MapSize_Y + move_x])
                        {
                            case 0:
                                apnum = apnum - EUO.move_ap;
                                break;
                            case 2:
                                apnum = apnum - (EUO.move_ap + 1);
                                break;
                        }
                        //APが0以下で無ければ移動する
                        if (apnum > 0)
                        {
                            UTC.tile[y * 25 + x] = false;
                            UTC.tile[move_y * 25 + move_x] = true;
                            UT.Unit_TileNum = move_y * 25 + move_x;
                            obj.transform.position = new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * move_x, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * move_y, obj.transform.position.z);
                            CM.Character(apnum, renum, 1);
                            break;
                        }
                    }
                }
            }
        }
        else if (hrd < 12)//頭悪い
        {
            //移動方向を四方向からランダムに決める
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
                                CM.Character(apnum, renum, 1);
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
                                CM.Character(apnum, renum, 1);
                                Debug.Log("移動完了2");
                            }
                            break;
                        case 3://資源
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
                                CM.Character(apnum, renum, 1);
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
                                CM.Character(apnum, renum, 1);
                                Debug.Log("移動完了4");
                            }
                            break;
                    }
                }
            }
        }
    }

    //ユニットの攻撃
    bool Unit_Attack(GameObject obj)
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
                        int x, y;
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
                                    return false;
                                }
                                break;
                            case "Carcher(Clone)":
                                if (AC.Can_Attack().tag == "unit")
                                {
                                    UO = AC.Can_Attack().GetComponent<Unit_Operation>();
                                    UO.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("攻撃4.4");
                                    summon_or_action = RanDom(0, 100);
                                    return false;
                                }
                                else if(AC.Can_Attack().tag == "castle")
                                {
                                    PCH.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("攻撃4.5");
                                    summon_or_action= RanDom(0, 100);
                                    return false;
                                }
                                break;
                            case "Ccatapalt(Clone)":
                                if (AC.Can_Attack().tag == "unit")
                                {
                                    UO = AC.Can_Attack().GetComponent<Unit_Operation>();
                                    UO.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("攻撃4.4");
                                    summon_or_action = RanDom(0, 100);
                                    return false;
                                }
                                else if (AC.Can_Attack().tag == "castle")
                                {
                                    PCH.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("攻撃4.5");
                                    summon_or_action = RanDom(0, 100);
                                    return false;
                                }
                                break;                 
                        }
                    }
                }
            }
        }
        return true;
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
