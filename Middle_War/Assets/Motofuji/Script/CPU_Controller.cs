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

    [SerializeField] GameObject infantry;
    [SerializeField] GameObject archer;
    [SerializeField] GameObject catapalt;

    [SerializeField] GameObject unitbox;
    GameObject Sunit;

    [SerializeField] GameObject tilebox;
    Transform castle;
    Transform castle2;

    EUnit_Operation EUO;
    Unit_Operation UO;

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

    public UI_Operate UIO;
    int surd;//���j�b�g�̏o����ނ̃����_��
    int urd;//�ǂ̃��j�b�g���s�������邩�̃����_��
    int ard;//�G���A�̂ǂ��ɏo�����̃����_��
    int acrd;//CPU�����j�b�g�ɂ���s���̃����_��
    int summon_or_action;//���j�b�g���������邩�s�������邩�̃����_��
    int mrd;//���j�b�g���ǂ��Ɉړ����邩�̃����_��
    int hrd;//����ǂ����邩�̃����_��

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
    }

    // Update is called once per frame
    void Update()
    {
        if (map_complete)
        {
            castle = tilebox.transform.Find("castle2(Clone)");
            map_complete = false;
        }

        if (nowturn)
        {
            if (CM.Now_EAP > 1)
            {
                if (UIO.EUnit_Num == 0)
                {
                    Debug.Log("���j�b�g����");
                    Unit_Summon();
                }
                else
                {
                    Debug.Log("���j�b�g�݂�");
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

    //�ړ��A�����A�U�����烉���_���ň�s������
    void Random_Action()
    {
        urd = RanDom(0, UIO.EUnit_Num);
        unit = unit_box.transform.GetChild(urd).gameObject;
        acrd = RanDom(0, 8);
        if (unit != null)
        {
            if(acrd < 5)//�ړ�
            {
                Unit_Move(unit);
            }
            else if(acrd < 8)//�U��
            {
                Unit_Attack(unit);
            }
            else if(acrd < 10)//����
            {
                //�����\��
            }
        }
    }

    //���j�b�g����
    void Unit_Summon()
    {
        surd = RanDom(0, 3);
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
                switch (surd)
                {
                    case 0://��������
                        apnum = apnum - 2;
                        if (apnum >= 0)
                        {
                            Sunit = Instantiate(infantry, new Vector3(area.transform.position.x, area.transform.position.y, 14.0f), Quaternion.identity);
                            UTC.tile[UC.tilenum] = true;
                            Sunit.GetComponent<UnitTile>().Unit_TileNum = UC.tilenum;
                            CM.EChange_REAP(apnum, renum);
                        }
                        break;
                    case 1://�|������
                        apnum = apnum - 6;
                        if (apnum >= 0)
                        {
                            Sunit = Instantiate(archer, new Vector3(area.transform.position.x, area.transform.position.y, 14.0f), Quaternion.identity);
                            UTC.tile[UC.tilenum] = true;
                            Sunit.GetComponent<UnitTile>().Unit_TileNum = UC.tilenum;
                            CM.EChange_REAP(apnum, renum);
                        }
                        break;
                    case 2://�J�^�p���g����
                        apnum = apnum - 10;
                        renum = renum - 10;
                        if (apnum >= 0 && renum >= 0)
                        {
                            Sunit = Instantiate(catapalt, new Vector3(area.transform.position.x, area.transform.position.y, 14.0f), Quaternion.identity);
                            UTC.tile[UC.tilenum] = true;
                            Sunit.GetComponent<UnitTile>().Unit_TileNum = UC.tilenum;
                            CM.EChange_REAP(apnum, renum);
                        }
                        break;
                    default:
                        Sunit = null;
                        break;
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
        hrd = RanDom(0, 2);
        hrd = 1;
        if (hrd == 0)//������
        {
            castle2 = tilebox.transform.Find("castle1(Clone)");

            Debug.Log("�ړ�1");
            if (move_checker != null)
            {
                Debug.Log("�ړ�2");
                MC = move_checker.GetComponent<Move_Check>();
                if (MC != null)
                {
                    Debug.Log("�ړ�3");
                    if (MC.Can_Move() != null)
                    {
                        Debug.Log("�ړ�4");
                        if (MC.Can_Move().name == "grass(Clone)" || MC.Can_Move().name == "area2(Clone)")
                        {
                            Debug.Log("�ړ�5.1");
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - EUO.move_ap;
                            if (apnum > 0)
                            {
                                obj.transform.position = new Vector3(move_checker.transform.position.x, move_checker.transform.position.y, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                                MC.Null_CanMove();
                            }
                        }
                        else if (MC.Can_Move().name == "water(Clone)")
                        {
                            Debug.Log("�ړ�5.2");
                            EUO = obj.GetComponent<EUnit_Operation>();
                            apnum = CM.Now_EAP;
                            renum = CM.Now_EResource;
                            apnum = apnum - (EUO.move_ap + 1);
                            if (apnum > 0)
                            {
                                obj.transform.position = new Vector3(move_checker.transform.position.x, move_checker.transform.position.y, obj.transform.position.z);
                                CM.EChange_REAP(apnum, renum);
                                MC.Null_CanMove();
                            }
                        }
                        else if (MC.Can_Move().name == "resource(Clone)")
                        {
                            Debug.Log("�ړ�5.3");
                            RC = MC.Can_Move().GetComponent<Resource_Controll>();
                            RC.EGetResource();
                            Debug.Log("�������");
                            MC.Null_CanMove();
                        }

                    }
                    else
                    {
                        Debug.Log(MC.Can_Move());
                    }
                }
            }
            move_checker.transform.position = new Vector3(obj.transform.position.x + move_x * (TILESIZE_X + TILESPACE), obj.transform.position.y + move_y * (TILESIZE_Y + TILESPACE), move_checker.transform.position.z);
        }
        else if (hrd == 1)//������
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
            Debug.Log("�ړ�1");
            if (obj.name == "Cinfantry(Clone)")
            {
                if (!UTC.tile[dy * 25 + dx])
                {
                    switch (CM.map[dy * 25 + dx])
                    {
                        case 0://��
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
                                Debug.Log("�ړ�����1");
                            }
                            break;
                        case 2://��
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
                                Debug.Log("�ړ�����2");
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
                                    Debug.Log("�������");
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
                        case 0://��
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
                                Debug.Log("�ړ�����3");
                            }
                            break;
                        case 2://��
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
                                Debug.Log("�ړ�����4");
                            }
                            break;
                    }
                }
            }
        }
    }

    void Unit_Attack(GameObject obj)
    {
        attack_checker = obj.transform.GetChild(1).gameObject;
        EUO = obj.GetComponent<EUnit_Operation>();
        if (EUO != null)
        {
            Debug.Log("�U��1");
            if (EUO.attack_cnt == 0)
            {
                Debug.Log("�U��2");
                AC = attack_checker.GetComponent<Attack_Check>();
                if (AC != null)
                {
                    Debug.Log("�U��3");
                    if (AC.Can_Attack() != null)
                    {
                        switch (obj.name)
                        {
                            case "Cinfantry(Clone)":
                                if (AC.Can_Attack().tag == "unit")
                                {
                                    UO = AC.Can_Attack().GetComponent<Unit_Operation>();
                                    UO.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("�U��4.1");
                                }
                                break;
                            case "Carcher(Clone)":
                            case "Ccatapalt(Clone)":
                                if (AC.Can_AllAttack().tag == "unit")
                                {
                                    UO = AC.Can_Attack().GetComponent<Unit_Operation>();
                                    UO.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("�U��4.4");
                                }
                                if (AC.Can_AllAttack().name == "castle1(Clone)")
                                {
                                    PCH.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("�U��4.5");
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        summon_or_action = RanDom(0, 100);
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
