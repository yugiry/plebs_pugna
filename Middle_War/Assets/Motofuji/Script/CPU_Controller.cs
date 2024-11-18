using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CPU_Controller : PlayerUnit_Base
{
    bool nowturn;
    bool map_complete;

    [SerializeField] GameObject infantry;
    [SerializeField] GameObject archer;
    [SerializeField] GameObject catapalt;

    [SerializeField] GameObject unitbox;
    GameObject Sunit;

    [SerializeField] GameObject tilebox;
    Transform castle;

    [NonSerialized] EUnit_Operation IEUO;
    [NonSerialized] EUnit_Operation AEUO;
    [NonSerialized] EUnit_Operation CEUO;
    EUnit_Operation EUO;
    Unit_Operation UO;

    [SerializeField] GameObject checker_box;
    GameObject unit_checker;
    Unit_Check UC;

    [SerializeField] GameObject unit_box;
    GameObject unit;
    GameObject move_checker;
    Move_Check MC;
    GameObject attack_checker;
    Attack_Check AC;

    public UI_Operate UIO;
    int surd;//���j�b�g�̏o����ނ̃����_��
    int urd;//�ǂ̃��j�b�g���s�������邩�̃����_��
    int ard;//�G���A�̂ǂ��ɏo�����̃����_��
    int acrd;//CPU�����j�b�g�ɂ���s���̃����_��
    int summon_or_action;//���j�b�g���������邩�s�������邩�̃����_��
    int mrd;//���j�b�g���ǂ��Ɉړ����邩�̃����_��

    float summon_x, summon_y;
    int unit_move_ap;

    float move_x, move_y;

    // Start is called before the first frame update
    void Start()
    {
        map_complete = false;
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
            if (UIO.EUnit_Num == 0)
            {
                Debug.Log("���j�b�g����");
                Unit_Summon();
            }
            else
            {
                Debug.Log("���j�b�g�݂�");
                summon_or_action = RanDom(0, 4);
                switch (summon_or_action)
                {
                    case 0:
                        Unit_Summon();
                        break;
                    case 1:
                    case 2:
                    case 3:
                        Random_Action();
                        break;
                }
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
        IEUO = infantry.GetComponent<EUnit_Operation>();
        AEUO = archer.GetComponent<EUnit_Operation>();
        CEUO = catapalt.GetComponent<EUnit_Operation>();
    }

    //�ړ��A�����A�U�����烉���_���ň�s������
    void Random_Action()
    {
        urd = RanDom(0, UIO.EUnit_Num);
        unit = unit_box.transform.GetChild(urd).gameObject;
        acrd = RanDom(0, 3);
        if (unit != null)
        {
            switch (acrd)
            {
                case 0://�ړ�
                    Unit_Move(unit);
                    break;
                case 1:
                    break;
                case 2://�U��
                    Unit_Attack(unit);
                    break;
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

        unit_checker = checker_box.transform.GetChild(ard).gameObject;
        UC = unit_checker.GetComponent<Unit_Check>();
        if (!UC.OnUnit())
        {
            if (UIO.EUnit_Num < 20)
            {
                cmobj = GameObject.Find("map");
                CM = cmobj.GetComponent<CreateMap>();
                apnum = CM.Now_EAP;
                renum = CM.Now_EResource;
                switch (surd)
                {
                    case 0://��������
                        apnum = apnum - IEUO.spawn_ap;
                        if (apnum >= 0)
                        {
                            Sunit = Instantiate(infantry, new Vector3(castle.position.x + (summon_x * (TILESIZE_X + TILESPACE)), castle.position.y + (summon_y * (TILESIZE_Y + TILESPACE)), 14.0f), Quaternion.identity);
                            CM.EChange_REAP(apnum, renum);
                        }
                        break;
                    case 1://�|������
                        apnum = apnum - AEUO.spawn_ap;
                        if (apnum >= 0)
                        {
                            Sunit = Instantiate(archer, new Vector3(castle.position.x + (summon_x * (TILESIZE_X + TILESPACE)), castle.position.y + (summon_y * (TILESIZE_Y + TILESPACE)), 14.0f), Quaternion.identity);
                            CM.EChange_REAP(apnum, renum);
                        }
                        break;
                    case 2://�J�^�p���g����
                        apnum = apnum - CEUO.spawn_ap;
                        if (apnum >= 0)
                        {
                            Sunit = Instantiate(catapalt, new Vector3(castle.position.x + (summon_x * (TILESIZE_X + TILESPACE)), castle.position.y + (summon_y * (TILESIZE_Y + TILESPACE)), 14.0f), Quaternion.identity);
                            CM.EChange_REAP(apnum, renum);
                        }
                        break;
                }
                Sunit.transform.parent = unitbox.transform;
            }
        }
    }

    void Unit_Move(GameObject obj)
    {
        move_checker = obj.transform.GetChild(0).gameObject;
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
        }

        MC = move_checker.GetComponent<Move_Check>();
        if (MC.Can_Move() == 1)
        {
            cmobj = GameObject.Find("map");
            CM = cmobj.GetComponent<CreateMap>();
            EUO = obj.GetComponent<EUnit_Operation>();
            apnum = CM.Now_EAP;
            renum = CM.Now_EResource;
            apnum = apnum - EUO.move_ap;
            if (apnum > 0)
            {
                obj.transform.position = new Vector3(move_checker.transform.position.x, move_checker.transform.position.y, obj.transform.position.z);
                CM.EChange_REAP(apnum, renum);
            }
        }
        else if(MC.Can_Move() == 2)
        {
            cmobj = GameObject.Find("map");
            CM = cmobj.GetComponent<CreateMap>();
            EUO = obj.GetComponent<EUnit_Operation>();
            apnum = CM.Now_EAP;
            renum = CM.Now_EResource;
            apnum = apnum - (EUO.move_ap + 1);
            if (apnum > 0)
            {
                obj.transform.position = new Vector3(move_checker.transform.position.x, move_checker.transform.position.y, obj.transform.position.z);
                CM.EChange_REAP(apnum, renum);
            }
        }
        move_checker.transform.position = new Vector3(obj.transform.position.x + move_x * (TILESIZE_X + TILESPACE), obj.transform.position.y + move_y * (TILESIZE_Y + TILESPACE), obj.transform.position.z);
    }

    void Unit_Attack(GameObject obj)
    {
        attack_checker = obj.transform.GetChild(1).gameObject;
        EUO = obj.GetComponent<EUnit_Operation>();
        if (EUO.attack_cnt == 0)
        {
            AC = attack_checker.GetComponent<Attack_Check>();
            switch (obj.name)
            {
                case "Cinfantry(Clone)":
                    if (AC.Can_Attack() != null)
                    {
                        UO = AC.Can_Attack().GetComponent<Unit_Operation>();
                        UO.HitAttack(EUO.attack);
                        EUO.attack_cnt++;
                    }
                    break;
                case "Carcher(Clone)":
                case "Ccatapalt(Clone)":
                    if (AC.Can_AllAttack() != null)
                    {
                        if(AC.Can_AllAttack().tag == "unit")
                        {
                            UO = AC.Can_Attack().GetComponent<Unit_Operation>();
                            UO.HitAttack(EUO.attack);
                            EUO.attack_cnt++;
                        }
                        if(AC.Can_AllAttack().name == "castle1(Clone)")
                        {
                            chobj = GameObject.Find("map");
                            PCH = chobj.GetComponent<Pcastlehp>();
                            PCH.HitAttack(EUO.attack);
                            EUO.attack_cnt++;
                        }
                    }
                    break;
            }
        }
    }

    int RanDom(int min, int max)
    {
        int num = UnityEngine.Random.Range(min, max);

        return num;
    }
}
