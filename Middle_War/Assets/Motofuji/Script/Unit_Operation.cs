using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Operation : MonoBehaviour
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

    GameObject euoobj;
    EUnit_Operation EUO;

    GameObject chobj;
    Ecastlehp ECH;

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
            //�|��
            if (unit.name == "Parcher(Clone)")
            {
                //�U�����ړ����ύX
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Destroy_Range();
                    choice_move++;
                    if (choice_move > 1)
                    {
                        choice_move = 0;
                    }
                }
                switch (choice_move)
                {
                    case 0://�ړ�
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
                            //�}�E�X�̈ʒu�ɂ���^�C����T��
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
                                                if (clickedGameObject.name != "mountain(Clone)"
                                                 && clickedGameObject.name != "resource(Clone)"
                                                 && clickedGameObject.name != "castle1(Clone)"
                                                 && clickedGameObject.name != "castle2(Clone)"
                                                 && clickedGameObject.name != "area2(Clone)"
                                                 && clickedGameObject.name != "Einfantry(Clone)"
                                                 && clickedGameObject.name != "Earcher(Clone)"
                                                 && clickedGameObject.name != "Ecatapalt(Clone)"
                                                 && clickedGameObject.name != "Pinfantry(Clone)"
                                                 && clickedGameObject.name != "Parcher(Clone)"
                                                 && clickedGameObject.name != "Pcatapalt(Clone)")
                                                {
                                                    cmobj = GameObject.Find("map");
                                                    CMinfo = cmobj.GetComponent<CreateMap>();
                                                    apnum = CMinfo.Now_PAP;
                                                    renum = CMinfo.Now_PResource;
                                                    //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                                    apnum = apnum - move_ap;
                                                    if (apnum >= 0)
                                                    {
                                                        CMinfo.PChange_REAP(apnum, renum);
                                                        unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                                    }
                                                    //clickmove = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        pushmouse = Input.GetMouseButtonDown(0);
                        break;
                    case 1://�U��
                        if (Input.GetMouseButton(0))
                        {
                            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                            mousepos.x = mousepos.x + 54;
                            mousepos.y = -mousepos.y + 54;
                            mousepos.z = unit.transform.position.z;
                            tile_x = (unit.transform.position.x + 54) / (4.0f + 0.5f);
                            tile_y = (-unit.transform.position.y + 54) / (4.0f + 0.5f);
                            //�}�E�X�̈ʒu�ɂ���^�C����T��
                            for (float i = tile_y - 2; i <= tile_y + 2; i++)
                            {
                                for (float j = tile_x - 2; j <= tile_x + 2; j++)
                                {
                                    if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                                    {
                                        if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                                        {
                                            clickedGameObject = hit2d.transform.gameObject;
                                            if (clickedGameObject.name == "Einfantry(Clone)"
                                             || clickedGameObject.name == "Earcher(Clone)"
                                             || clickedGameObject.name == "Ecatapalt(Clone)")
                                            {
                                                if (attack_cnt == 0)
                                                {
                                                    EUO = clickedGameObject.GetComponent<EUnit_Operation>();
                                                    Debug.Log("���j�b�g�U��");
                                                    EUO.HitAttack(attack);
                                                    attack_cnt++;
                                                }
                                            }
                                            else if (clickedGameObject.name == "castle2(Clone)")
                                            {
                                                if (attack_cnt == 0)
                                                {
                                                    chobj = GameObject.Find("map");
                                                    ECH = chobj.GetComponent<Ecastlehp>();
                                                    Debug.Log("��U��");
                                                    ECH.HitAttack(attack);
                                                    attack_cnt++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    act1.SetActive(false);
                    ucobj = GameObject.Find("map");
                    UC = ucobj.GetComponent<uniteClick>();
                    UC.PDlete();
                }
            }
            //�J�^�p���g
            else if (unit.name == "Pcatapalt(Clone)")
            {
                //�U�����ړ����ύX
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Destroy_Range();
                    choice_move++;
                    if (choice_move > 1)
                    {
                        choice_move = 0;
                    }
                }
                switch (choice_move)
                {
                    case 0://�ړ�
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
                            //�}�E�X�̈ʒu�ɂ���^�C����T��
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
                                                if (clickedGameObject.name != "mountain(Clone)"
                                                 && clickedGameObject.name != "resource(Clone)"
                                                 && clickedGameObject.name != "castle1(Clone)"
                                                 && clickedGameObject.name != "castle2(Clone)"
                                                 && clickedGameObject.name != "area2(Clone)"
                                                 && clickedGameObject.name != "Einfantry(Clone)"
                                                 && clickedGameObject.name != "Earcher(Clone)"
                                                 && clickedGameObject.name != "Ecatapalt(Clone)"
                                                 && clickedGameObject.name != "Pinfantry(Clone)"
                                                 && clickedGameObject.name != "Parcher(Clone)"
                                                 && clickedGameObject.name != "Pcatapalt(Clone)")
                                                {
                                                    cmobj = GameObject.Find("map");
                                                    CMinfo = cmobj.GetComponent<CreateMap>();
                                                    apnum = CMinfo.Now_PAP;
                                                    renum = CMinfo.Now_PResource;
                                                    //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                                    apnum = apnum - move_ap;
                                                    if (apnum >= 0)
                                                    {
                                                        CMinfo.PChange_REAP(apnum, renum);
                                                        unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                                    }
                                                    //clickmove = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        pushmouse = Input.GetMouseButtonDown(0);
                        break;
                    case 1://�U��
                        if (Input.GetMouseButton(0))
                        {
                            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                            mousepos.x = mousepos.x + 54;
                            mousepos.y = -mousepos.y + 54;
                            mousepos.z = unit.transform.position.z;
                            tile_x = (unit.transform.position.x + 54) / (4.0f + 0.5f);
                            tile_y = (-unit.transform.position.y + 54) / (4.0f + 0.5f);
                            //�}�E�X�̈ʒu�ɂ���^�C����T��
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
                                                if (clickedGameObject.name == "Einfantry(Clone)"
                                                 || clickedGameObject.name == "Earcher(Clone)"
                                                 || clickedGameObject.name == "Ecatapalt(Clone)")
                                                {
                                                    if (attack_cnt == 0)
                                                    {
                                                        EUO = clickedGameObject.GetComponent<EUnit_Operation>();
                                                        Debug.Log("���j�b�g�U��");
                                                        EUO.HitAttack(attack);
                                                        attack_cnt++;
                                                    }
                                                }
                                                else if (clickedGameObject.name == "castle2(Clone)")
                                                {
                                                    if (attack_cnt == 0)
                                                    {
                                                        chobj = GameObject.Find("map");
                                                        ECH = chobj.GetComponent<Ecastlehp>();
                                                        Debug.Log("��U��");
                                                        ECH.HitAttack(attack);
                                                        attack_cnt++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    act1.SetActive(false);
                    ucobj = GameObject.Find("map");
                    UC = ucobj.GetComponent<uniteClick>();
                    UC.PDlete();
                }
            }
            //����
            else if (unit.name == "Pinfantry(Clone)")
            {
                //�U�����ړ����ύX
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Destroy_Range();
                    choice_move++;
                    if (choice_move > 1)
                    {
                        choice_move = 0;
                    }
                }
                switch (choice_move)
                {
                    case 0://�ړ�
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
                            //�}�E�X�̈ʒu�ɂ���^�C����T��
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
                                                if (clickedGameObject.name != "mountain(Clone)"
                                                 && clickedGameObject.name != "castle1(Clone)"
                                                 && clickedGameObject.name != "castle2(Clone)"
                                                 && clickedGameObject.name != "area2(Clone)"
                                                 && clickedGameObject.name != "Einfantry(Clone)"
                                                 && clickedGameObject.name != "Earcher(Clone)"
                                                 && clickedGameObject.name != "Ecatapalt(Clone)"
                                                 && clickedGameObject.name != "Pinfantry(Clone)"
                                                 && clickedGameObject.name != "Parcher(Clone)"
                                                 && clickedGameObject.name != "Pcatapalt(Clone)")
                                                {
                                                    cmobj = GameObject.Find("map");
                                                    CMinfo = cmobj.GetComponent<CreateMap>();
                                                    apnum = CMinfo.Now_PAP;
                                                    renum = CMinfo.Now_PResource;
                                                    if (clickedGameObject.name == "resource(Clone)")
                                                    {
                                                        Debug.Log("�����m��");
                                                        rcobj = GameObject.Find("resource(Clone)");
                                                        RC = rcobj.GetComponent<Resource_Controll>();
                                                        RC.PGetResource();
                                                    }
                                                    else
                                                    {
                                                        //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                                        if (clickedGameObject.name == "water(Clone)")
                                                        {
                                                            apnum = apnum - (move_ap + 1);
                                                        }
                                                        else
                                                        {
                                                            apnum = apnum - move_ap;
                                                        }
                                                        if (apnum >= 0)
                                                        {
                                                            CMinfo.PChange_REAP(apnum, renum);
                                                            unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 14.0f);
                                                        }
                                                        //clickmove = false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        pushmouse = Input.GetMouseButtonDown(0);
                        break;
                    case 1://�U��
                        if (Input.GetMouseButton(0))
                        {
                            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                            mousepos.x = mousepos.x + 54;
                            mousepos.y = -mousepos.y + 54;
                            mousepos.z = unit.transform.position.z;
                            tile_x = (unit.transform.position.x + 54) / (4.0f + 0.5f);
                            tile_y = (-unit.transform.position.y + 54) / (4.0f + 0.5f);
                            //�}�E�X�̈ʒu�ɂ���^�C����T��
                            for (float i = tile_y - 1; i <= tile_y + 1; i++)
                            {
                                for (float j = tile_x - 1; j <= tile_x + 1; j++)
                                {
                                    if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                                    {
                                        if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                                        {
                                            clickedGameObject = hit2d.transform.gameObject;
                                            if (clickedGameObject.name == "Einfantry(Clone)" ||
                                                clickedGameObject.name == "Earcher(Clone)" ||
                                                clickedGameObject.name == "Ecatapalt(Clone)")
                                            {
                                                if (attack_cnt == 0)
                                                {
                                                    EUO = clickedGameObject.GetComponent<EUnit_Operation>();
                                                    Debug.Log("�U��");
                                                    EUO.HitAttack(attack);
                                                    attack_cnt++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    act1.SetActive(false);
                    ucobj = GameObject.Find("map");
                    UC = ucobj.GetComponent<uniteClick>();
                    UC.PDlete();
                }
            }
        }
        if (hp == 0)
        {
            Destroy(this);
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
                Debug.Log("act�^�O���������I�u�W�F�N�g���F" + act.name);
                act.SetActive(false);
            }
            act1.SetActive(true);
            choice_move = 0;
            ucobj = GameObject.Find("map");
            UC = ucobj.GetComponent<uniteClick>();
            UC.Punite_Serect(unit, hp);
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
