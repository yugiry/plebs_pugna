using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EUnit_Operation : MonoBehaviour
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

    GameObject uoobj;
    Unit_Operation UO;

    GameObject chobj;
    Pcastlehp PCH;

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
            //�|���ƃJ�^�p���g�͏���U���ł���
            if (unit.name == "Earcher(Clone)")
            {
                //���j�b�g���}�E�X�̈ʒu�̃^�C���Ɉړ�������
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
                    //�}�E�X�̈ʒu�ɂ���^�C����T���čU���ł���G���j�b�g�����邩�m�F
                    for (float i = tile_y - 2; i <= tile_y + 2; i++)
                    {
                        for (float j = tile_x - 2; j <= tile_x + 2; j++)
                        {
                            if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                            {
                                if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                                {
                                    clickedGameObject = hit2d.transform.gameObject;
                                    if (clickedGameObject.name == "Pinfantry(Clone)" ||
                                        clickedGameObject.name == "Parcher(Clone)" ||
                                        clickedGameObject.name == "Pcatapalt(Clone)")
                                    {
                                        if (attack_cnt == 0)
                                        {
                                            UO = clickedGameObject.GetComponent<Unit_Operation>();
                                            Debug.Log("�U��");
                                            UO.HitAttack(attack);
                                            attack_cnt++;
                                        }
                                    }
                                    if (clickedGameObject.name == "castle1(Clone)")
                                    {
                                        if (attack_cnt == 0)
                                        {
                                            chobj = GameObject.Find("map");
                                            PCH = chobj.GetComponent<Pcastlehp>();
                                            Debug.Log("�U��");
                                            PCH.HitAttack(attack);
                                            attack_cnt++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //�}�E�X�̈ʒu�ɂ���^�C����T���Ĉړ��ł���ꏊ�����邩�m�F
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
                                            apnum = CMinfo.Now_EAP;
                                            renum = CMinfo.Now_EResource;
                                            //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                            apnum = apnum - move_ap;
                                            if (apnum >= 0)
                                            {
                                                CMinfo.EChange_REAP(apnum, renum);
                                                unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                            }
                                        }
                                        else if (clickedGameObject.name == "water(Clone)")
                                        {
                                            cmobj = GameObject.Find("map");
                                            CMinfo = cmobj.GetComponent<CreateMap>();
                                            apnum = CMinfo.Now_EAP;
                                            renum = CMinfo.Now_EResource;
                                            //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                            apnum = apnum - (move_ap + 1);
                                            if (apnum >= 0)
                                            {
                                                CMinfo.EChange_REAP(apnum, renum);
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
                    UC.EDlete();
                }
            }
            else if (unit.name == "Ecatapalt(Clone)")
            {
                //���j�b�g���}�E�X�̈ʒu�̃^�C���Ɉړ�������
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
                    //�}�E�X�̈ʒu�ɂ���^�C����T���čU���ł���G���j�b�g�����邩�m�F
                    for (float i = tile_y - 4; i <= tile_y + 4; i++)
                    {
                        for (float j = tile_x - 4; j <= tile_x + 4; j++)
                        {
                            if ((j >= tile_x - 1 && j <= tile_x + 1) && (i >= tile_y - 1 && i <= tile_y + 1)) ;
                            else
                            {
                                if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                                {
                                    if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                                    {
                                        clickedGameObject = hit2d.transform.gameObject;
                                        if (clickedGameObject.name == "Pinfantry(Clone)" ||
                                            clickedGameObject.name == "Parcher(Clone)" ||
                                            clickedGameObject.name == "Pcatapalt(Clone)")
                                        {
                                            if (attack_cnt == 0)
                                            {
                                                UO = clickedGameObject.GetComponent<Unit_Operation>();
                                                Debug.Log("�U��");
                                                UO.HitAttack(attack);
                                                attack_cnt++;
                                            }
                                        }
                                        if (clickedGameObject.name == "castle1(Clone)")
                                        {
                                            if (attack_cnt == 0)
                                            {
                                                chobj = GameObject.Find("map");
                                                PCH = chobj.GetComponent<Pcastlehp>();
                                                Debug.Log("�U��");
                                                PCH.HitAttack(attack);
                                                attack_cnt++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //�}�E�X�̈ʒu�ɂ���^�C����T���Ĉړ��ł���ꏊ�����邩�m�F
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
                                            apnum = CMinfo.Now_EAP;
                                            renum = CMinfo.Now_EResource;
                                            //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                            apnum = apnum - move_ap;
                                            if (apnum >= 0)
                                            {
                                                CMinfo.EChange_REAP(apnum, renum);
                                                unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                            }
                                        }
                                        else if (clickedGameObject.name == "water(Clone)")
                                        {
                                            cmobj = GameObject.Find("map");
                                            CMinfo = cmobj.GetComponent<CreateMap>();
                                            apnum = CMinfo.Now_EAP;
                                            renum = CMinfo.Now_EResource;
                                            //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                            apnum = apnum - (move_ap + 1);
                                            if (apnum >= 0)
                                            {
                                                CMinfo.EChange_REAP(apnum, renum);
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
                    UC.EDlete();
                }
            }
            else if (unit.name == "Einfantry(Clone)")
            {
                //���j�b�g���}�E�X�̈ʒu�̃^�C���Ɉړ�������
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
                    //�}�E�X�̈ʒu�ɂ���^�C����T���čU���ł���G���j�b�g�����邩�m�F
                    for (float i = tile_y - 1; i <= tile_y + 1; i++)
                    {
                        for (float j = tile_x - 1; j <= tile_x + 1; j++)
                        {
                            if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                            {
                                if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                                {
                                    clickedGameObject = hit2d.transform.gameObject;
                                    if (clickedGameObject.name == "Pinfantry(Clone)" ||
                                        clickedGameObject.name == "Parcher(Clone)" ||
                                        clickedGameObject.name == "Pcatapalt(Clone)")
                                    {
                                        if (attack_cnt == 0)
                                        {
                                            UO = clickedGameObject.GetComponent<Unit_Operation>();
                                            Debug.Log("�U��");
                                            UO.HitAttack(attack);
                                            attack_cnt++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //�}�E�X�̈ʒu�ɂ���^�C����T���Ĉړ��ł���ꏊ�����邩�m�F
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
                                            apnum = CMinfo.Now_EAP;
                                            renum = CMinfo.Now_EResource;
                                            //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                            apnum = apnum - move_ap;
                                            if (apnum >= 0)
                                            {
                                                CMinfo.EChange_REAP(apnum, renum);
                                                unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                            }
                                        }
                                        else if (clickedGameObject.name == "water(Clone)")
                                        {
                                            cmobj = GameObject.Find("map");
                                            CMinfo = cmobj.GetComponent<CreateMap>();
                                            apnum = CMinfo.Now_EAP;
                                            renum = CMinfo.Now_EResource;
                                            //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                            apnum = apnum - (move_ap + 1);
                                            if (apnum >= 0)
                                            {
                                                CMinfo.EChange_REAP(apnum, renum);
                                                unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                            }
                                        }
                                        else if (clickedGameObject.name == "resource(Clone)")
                                        {
                                            Debug.Log("�����m��");
                                            RC = clickedGameObject.GetComponent<Resource_Controll>();
                                            RC.EGetResource();
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
                    UC.EDlete();
                }
            }
        }
        if(hp == 0)
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

    //���j�b�g��I������
    public void EUnit_Serect()
    {
        tcobj = GameObject.Find("map");
        TC = tcobj.GetComponent<Turn_change>();
        if (TC.nowturn == 1)
        {
            Destroy_Range();
            action = GameObject.FindGameObjectsWithTag("Eact");
            foreach (GameObject act in action)
            {
                Debug.Log("act�^�O���������I�u�W�F�N�g���F" + act.name);
                act.SetActive(false);
            }
            act1.SetActive(true);
            choice_move = 0;
            ucobj = GameObject.Find("map");
            UC = ucobj.GetComponent<uniteClick>();
            UC.Eunite_Serect(unit, hp, move_ap);
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
