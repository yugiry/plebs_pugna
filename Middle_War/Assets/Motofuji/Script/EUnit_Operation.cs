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
            //���j�b�g���}�E�X�̈ʒu�̃^�C���Ɉړ�������
            if (Input.GetMouseButtonDown(0))
            {
                //�}�E�X�̈ʒu���擾
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //�}�E�X�̈ʒu�ɂ���I�u�W�F�N�g���擾
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                //�}�E�X�̍��W���}�b�v���W�ɂ��낦��
                mousepos.x = mousepos.x + 54;
                mousepos.y = -mousepos.y + 54;
                mousepos.z = unit.transform.position.z;
                //�擾�����I�u�W�F�N�g�̃}�b�v�ʒu���擾
                tile_x = (unit.transform.position.x + 54) / (4.0f + 0.5f);
                tile_y = (-unit.transform.position.y + 54) / (4.0f + 0.5f);
                //�|���ƃJ�^�p���g�͏���U���ł���
                if (unit.name == "Earcher(Clone)")
                {
                    //�}�E�X�̍��W��"unit"�̃^�O�����I�u�W�F�N�g������ꍇ
                    if (clickedGameObject.CompareTag("unit"))
                    {
                        //attack_cnt��0�Ȃ�U������
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 2, 0, attack, clickedGameObject, unit))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //�}�E�X�̍��W�ɏ邪����ꍇ
                    if (clickedGameObject.name == "castle1(Clone)")
                    {
                        //attack_cnt��0�Ȃ�U������
                        if (attack_cnt == 0)
                        {
                            if (Attack_Castle(unit.transform.position, clickedGameObject.transform.position, 2, 0, attack, unit, ECH, PCH))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //�}�E�X�̍��W�Ɉړ��\�ȏꏊ������Ȃ�ړ�����
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit, CM);
                }
                else if (unit.name == "Ecatapalt(Clone)")
                {
                    //�}�E�X�̍��W��"unit"�̃^�O�����I�u�W�F�N�g������ꍇ
                    if (clickedGameObject.CompareTag("unit"))
                    {
                        //attack_cnt��0�Ȃ�U������
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 4, 2, attack, clickedGameObject, unit))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //�}�E�X�̍��W�ɏ邪����ꍇ
                    if (clickedGameObject.name == "castle1(Clone)")
                    {
                        //attack_cnt��0�Ȃ�U������
                        if (attack_cnt == 0)
                        {
                            if (Attack_Castle(unit.transform.position, clickedGameObject.transform.position, 4, 2, attack, unit, ECH, PCH))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //�}�E�X�̍��W�Ɉړ��\�ȏꏊ������Ȃ�ړ�����
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit, CM);
                }
                else if (unit.name == "Einfantry(Clone)")
                {
                    //�}�E�X�̍��W��"unit"�̃^�O�����I�u�W�F�N�g������ꍇ
                    if (clickedGameObject.CompareTag("unit"))
                    {
                        //attack_cnt��0�Ȃ�U������
                        if (attack_cnt == 0)
                        {
                            if (Attack_Unit(unit.transform.position, clickedGameObject.transform.position, 1, 0, attack, clickedGameObject, unit))
                            {
                                attack_cnt++;
                            }
                        }
                    }
                    //�}�E�X�̍��W�Ɉړ��\�ȏꏊ������Ȃ�ړ�����
                    Move_Unit(tile_x, tile_y, mousepos, move_ap, clickedGameObject, unit, CM);
                }
            }
        }
        pushmouse = Input.GetMouseButtonDown(0);
        //�E�N���b�N�Ń��j�b�g�̑I��������
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

    //���j�b�g���N���b�N���ꂽ��
    public void EUnit_Serect()
    {
        //�Q�[�����̃^�[���������̏ꍇ
        if (TC.nowturn == 1)
        {
            Destroy_Range();
            //"Eact"��Tag���t���Ă���I�u�W�F�N�g�̃A�N�e�B�u��S��false�ɂ���
            action = GameObject.FindGameObjectsWithTag("Eact");
            foreach (GameObject act in action)
            {
                Debug.Log("act�^�O���������I�u�W�F�N�g���F" + act.name);
                act.SetActive(false);
            }
            //�N���b�N���ꂽ���j�b�g�����A�N�e�B�u��true�ɂ���
            act1.SetActive(true);
            //�N���b�N���ꂽ���j�b�g��HP�ƈړ��ɂ�����AP����ʂ̏���UI�ɕ\��������
            UC.Eunite_Serect(unit, hp, move_ap);
        }
    }

    public void HitAttack(int hit)
    {
        //�U�����ꂽ�U���͕�HP�����炷
        hit_anim.SetBool("hit", true);
        hp -= hit;
    }

    public void hit_anim_stop()
    {
        hit_anim.SetBool("hit", false);
        //HP��0��菬�����Ȃ烆�j�b�g��j�󂷂�
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
