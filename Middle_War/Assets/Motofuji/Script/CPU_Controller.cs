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
        //���ʂŎg���X�N���v�g�̃R���|�[�l���g�Ȃǂ������ł��Ă���
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
        //�}�b�v�������I��������castle2�̈ʒu���擾����
        if (map_complete)
        {
            //��̏������ꂼ��擾����
            castle1 = tilebox.transform.Find("castle1(Clone)");
            castle2 = tilebox.transform.Find("castle2(Clone)");
            TI = castle1.GetComponent<TileInfo>();
            research_move[(int)TI.TileNum] = 0;
            int dx = 0, dy = 0;//���ׂ�ʒu���c���Ă������߂̕ϐ�
            int summon_x, summon_y;//���l������}�X�̃}�b�v���W
            //�}�b�v�̒[����[�܂Œ��ׂ鎞�̍ő吔
            for (int c = 0; c < 50; c++)
            {
                //�}�b�v�S�Ă𒲂ׂ�
                for (int y = 0; y < CM.MapSize_Y; y++)
                {
                    for (int x = 0; x < CM.MapSize_X; x++)
                    {
                        //�����ׂĂ�}�X�̐��l��c�Ɠ����Ȃ炻�̃}�X�̏㉺���E�𒲂ׂ�
                        if (research_move[y * CM.MapSize_Y + x] == c)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                switch (k)
                                {
                                    case 0://��
                                        dx = 0;
                                        dy = -1;
                                        break;
                                    case 1://��
                                        dx = 0;
                                        dy = 1;
                                        break;
                                    case 2://�E
                                        dx = 1;
                                        dy = 0;
                                        break;
                                    case 3://��
                                        dx = -1;
                                        dy = 0;
                                        break;
                                }
                                move_x = x + dx;
                                move_y = y + dy;
                                //�}�b�v�̊O�ɏo�Ȃ��悤�ɂ���
                                if (move_x < 0) move_x = 0;
                                if (move_x > 24) move_x = 24;
                                if (move_y < 0) move_y = 0;
                                if (move_y > 24) move_y = 24;
                                //�^�C�������������͐��ł��肩���j�b�g�����Ȃ��ꍇ���l��u��
                                if (research_move[move_x + move_y * 25] == -1 && (CM.map[move_x + move_y * 25] == 0 || CM.map[move_x + move_y * 25] == 2))
                                    research_move[move_x + move_y * 25] = c + 1;
                            }
                        }
                    }
                }
            }
            map_complete = false;
        }

        //�^�[���J�n
        if (nowturn)
        {
            if (CM.Now_EAP > 1)
            {
                //�X�e�[�W��̃��j�b�g�̐��ɉ����čs����ύX
                if (UIO.EUnit_Num == 0)
                {
                    //���j�b�g���X�e�[�W��ɂ��Ȃ��̂Ń��j�b�g������
                    Unit_Summon();
                }
                else
                {
                    if (summon_or_action < 1)//AP�𒙂߂�
                    {
                        Turn_Over();
                    }
                    else if (summon_or_action < 10)//�X�e�[�W��̃��j�b�g�𑝂₷
                    {
                        Unit_Summon();
                    }
                    else if (summon_or_action < 100)//���j�b�g���s��������
                    {
                        Unit_Action();
                    }
                }
            }
            else
            {
                //AP���Ȃ��Ȃ�����^�[����Ԃ�
                Turn_Over();
            }
        }
    }

    //�}�b�v�������I���������Ƃ�m�点��֐�
    public void Map_Collect()
    {
        map_complete = true;
    }

    //�^�[��������Ă��Ă��邱�Ƃ�m�点��֐�
    public void Turn_Here()
    {
        nowturn = true;
        summon_or_action = RanDom(0, 100);
    }

    //���j�b�g�̍s��
    void Unit_Action()
    {
        urd = RanDom(0, UIO.EUnit_Num);
        unit = unit_box.transform.GetChild(urd).gameObject;
        //�U���������邩���ׂ�(������Ȃ�U��)
        if (Unit_Attack(unit))
        {
            //�U���o���Ȃ��ꍇ�͈ړ�������
            Unit_Move(unit);
            summon_or_action = RanDom(0, 100);
        }
    }

    //���j�b�g����
    void Unit_Summon()
    {
        //�ǂ̃��j�b�g���������邩�������_���Ō��߂�
        surd = RanDom(0, 50);
        //�ǂ̃}�X�ɏ������邩�������_���Ō��߂�
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

        //�����_���Ō��肵���G���A���擾����
        area = checker_box.transform.GetChild(ard).gameObject;
        UC = area.GetComponent<Unit_Check>();
        //�G���A�Ƀ��j�b�g�����邩�m�F
        if (!UC.OnUnit())
        {
            //�}�b�v��ɂ��郆�j�b�g�̐����ő吔�ɂȂ��Ă��Ȃ����m�F
            if (UIO.EUnit_Num < 20)
            {
                apnum = CM.Now_EAP;
                renum = CM.Now_EResource;
                if (surd < 15)//��������
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
                else if (surd < 40)//�|������
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
                else if (surd < 50)//�J�^�p���g����
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
                    //surd��50�ȏ�Ȃ�Sunit��null������
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

    //���j�b�g�̈ړ�
    void Unit_Move(GameObject obj)
    {
        int x, y;
        int dx = 0, dy = 0;
        UT = obj.GetComponent<UnitTile>();
        y = UT.Unit_TileNum / 25;
        x = UT.Unit_TileNum % 25;
        hrd = RanDom(0,12);
        if (hrd < 8)//������(��Ɍ������Đi�R���Ă���)
        {
            //���j�b�g�̈ʒu�̏㉺���E�𒲂ׂ�
            for (int k = 0; k < 4; k++)
            {
                switch (k)
                {
                    case 0://��
                        dx = 0;
                        dy = -1;
                        break;
                    case 1://��
                        dx = 0;
                        dy = 1;
                        break;
                    case 2://�E
                        dx = 1;
                        dy = 0;
                        break;
                    case 3://��
                        dx = -1;
                        dy = 0;
                        break;
                }
                move_x = x + dx;
                move_y = y + dy;
                //�ړ���Ƀ��j�b�g�����邩�m�F
                if (!UTC.tile[move_y * CM.MapSize_Y + move_x])
                {
                    //�����j�b�g������ꏊ���i�ސ�̐��l�̂ق���������������i��
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
                        //AP��0�ȉ��Ŗ�����Έړ�����
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
        else if (hrd < 12)//������
        {
            //�ړ��������l�������烉���_���Ɍ��߂�
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
                                CM.Character(apnum, renum, 1);
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
                                CM.Character(apnum, renum, 1);
                                Debug.Log("�ړ�����2");
                            }
                            break;
                        case 3://����
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
                                CM.Character(apnum, renum, 1);
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
                                CM.Character(apnum, renum, 1);
                                Debug.Log("�ړ�����4");
                            }
                            break;
                    }
                }
            }
        }
    }

    //���j�b�g�̍U��
    bool Unit_Attack(GameObject obj)
    {
        attack_checker = obj.transform.GetChild(1).gameObject;
        EUO = obj.GetComponent<EUnit_Operation>();
        UT = obj.GetComponent<UnitTile>();
        //���j�b�g�ւ̍U��
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
                        Debug.Log("�U��4");
                        int x, y;
                        switch (obj.name)
                        {
                            case "Cinfantry(Clone)":
                                if (AC.Can_Attack().tag == "unit")
                                {
                                    UO = AC.Can_Attack().GetComponent<Unit_Operation>();
                                    UO.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("�U��4.1");
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
                                    Debug.Log("�U��4.4");
                                    summon_or_action = RanDom(0, 100);
                                    return false;
                                }
                                else if(AC.Can_Attack().tag == "castle")
                                {
                                    PCH.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("�U��4.5");
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
                                    Debug.Log("�U��4.4");
                                    summon_or_action = RanDom(0, 100);
                                    return false;
                                }
                                else if (AC.Can_Attack().tag == "castle")
                                {
                                    PCH.HitAttack(EUO.attack);
                                    EUO.attack_cnt++;
                                    Debug.Log("�U��4.5");
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
