using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class PlayerUnit_Base : MonoBehaviour
{
    //�^�C���ݒu�̍ŏ��̈ʒu
    [NonSerialized] public float SetTileStart_X = -54;
    [NonSerialized] public float SetTileStart_Y = 54;
    [NonSerialized] public float SetTile_Z = 20;
    //�^�C���̑傫��
    [NonSerialized] public float TILESIZE_X = 4;
    [NonSerialized] public float TILESIZE_Y = 4;
    //�}�b�v�T�C�Y
    [NonSerialized] public int MAPSIZE_X = 25;
    [NonSerialized] public int MAPSIZE_Y = 25;
    //�^�C���Ԃ̒���
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

    public void component_Start()
    {
        mapobj = GameObject.Find("map");
        CM = mapobj.GetComponent<CreateMap>();
        PCH = mapobj.GetComponent<Pcastlehp>();
        ECH = mapobj.GetComponent<Ecastlehp>();
    }

    //�G���j�b�g�ւ̍U���s��(���W�P�A���W�Q�A�U���̍ő�͈́A�U���̍ŏ��͈́A�U���́A�N���b�N�����I�u�W�F�N�g�A���I�����Ă���I�u�W�F�N�g)
    public bool Attack_Unit(Vector3 p1, Vector3 p2, float max, float min, int attack, GameObject Cobj, GameObject Uobj)
    {
        Vector3 v;
        //�U���������I�u�W�F�N�g�܂ł̃x�N�g���������v�Z
        v.x = p1.x - p2.x;
        v.y = p1.y - p2.y;
        //�x�N�g���������Βl�ł��낦��
        v.x = Mathf.Abs(v.x);
        v.y = Mathf.Abs(v.y);
        //�U���͈͂ɍU���������I�u�W�F�N�g�����邩�m�F
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

    //��ւ̍U���s��(���W�P�A���W�Q�A�U���̍ő�͈́A�U���̍ŏ��͈́A�U���́A���I�����Ă���I�u�W�F�N�g)
    public bool Attack_Castle(Vector3 p1, Vector3 p2, float max, float min, int attack, GameObject Uobj, Ecastlehp ech, Pcastlehp pch)
    {
        ECH = ech;
        PCH = pch;
        Vector3 v;
        //�U���������I�u�W�F�N�g�܂ł̃x�N�g���������v�Z
        v.x = p1.x - p2.x;
        v.y = p1.y - p2.y;
        //�x�N�g���������Βl�ł��낦��
        v.x = Mathf.Abs(v.x);
        v.y = Mathf.Abs(v.y);
        //�U���͈͂ɍU���������I�u�W�F�N�g�����邩�m�F
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

    //���j�b�g�̈ړ�(���j�b�g�̍��Wx�A���j�b�g�̍��Wy�A�}�E�X�̍��W�A �ړ��Ɏg��AP�A�N���b�N�����I�u�W�F�N�g�A���I�����Ă���I�u�W�F�N�g)
    public void Move_Unit(float tx, float ty, Vector3 mousepos, int m_AP, GameObject Cobj, GameObject Uobj, CreateMap cm, AudioSource audios)
    {
        CM = cm;
        Debug.Log("�ړ��X�^�[�g");
        for (int i = 0; i < 4; i++)
        {
            float _x = tx;
            float _y = ty;
            switch (i)
            {
                case 0:
                    _y--;
                    break;
                case 1:
                    _x--;
                    break;
                case 2:
                    _x++;
                    break;
                case 3:
                    _y++;
                    break;
            }
            if (mousepos.x > (_x * 4.5f) - 2 && mousepos.x < (_x * 4.5f) + 2)
            {
                if (mousepos.y > (_y * 4.5f) - 2 && mousepos.y < (_y * 4.5f) + 2)
                {
                    Debug.Log(Cobj.name);
                    switch (Uobj.name)
                    {
                        case "Pinfantry(Clone)":
                            if (Cobj.name == "grass(Clone)" || Cobj.name == "area1(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    CM.PChange_REAP(apnum, renum);
                                    switch (Now_Move_Anim(_x, _y, Uobj))
                                    {
                                        case 0:
                                            StartCoroutine("MoveUp");
                                            break;
                                        case 1:
                                            StartCoroutine("MoveDown");
                                            break;
                                        case 2:
                                            StartCoroutine("MoveRight");
                                            break;
                                        case 3:
                                            StartCoroutine("MoveLeft");
                                            break;
                                    }
                                    audios.Play();
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                Debug.Log("�ړ�2");
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    CM.PChange_REAP(apnum, renum);
                                    switch (Now_Move_Anim(_x, _y, Uobj))
                                    {
                                        case 0:
                                            StartCoroutine("MoveUp");
                                            break;
                                        case 1:
                                            StartCoroutine("MoveDown");
                                            break;
                                        case 2:
                                            StartCoroutine("MoveRight");
                                            break;
                                        case 3:
                                            StartCoroutine("MoveLeft");
                                            break;
                                    }
                                    audios.Play();
                                }
                            }
                            else if (Cobj.name == "resource(Clone)")
                            {
                                Debug.Log("�ړ�3");
                                Debug.Log("�����m��");
                                RC = Cobj.GetComponent<Resource_Controll>();
                                RC.PGetResource();
                            }
                            break;
                        case "Einfantry(Clone)":
                            if (Cobj.name == "grass(Clone)" || Cobj.name == "area2(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    CM.EChange_REAP(apnum, renum);
                                    switch (Now_Move_Anim(_x, _y, Uobj))
                                    {
                                        case 0:
                                            StartCoroutine("MoveUp");
                                            break;
                                        case 1:
                                            StartCoroutine("MoveDown");
                                            break;
                                        case 2:
                                            StartCoroutine("MoveRight");
                                            break;
                                        case 3:
                                            StartCoroutine("MoveLeft");
                                            break;
                                    }
                                    audios.Play();
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    CM.EChange_REAP(apnum, renum);
                                    switch (Now_Move_Anim(_x, _y, Uobj))
                                    {
                                        case 0:
                                            StartCoroutine("MoveUp");
                                            break;
                                        case 1:
                                            StartCoroutine("MoveDown");
                                            break;
                                        case 2:
                                            StartCoroutine("MoveRight");
                                            break;
                                        case 3:
                                            StartCoroutine("MoveLeft");
                                            break;
                                    }
                                    audios.Play();
                                }
                            }
                            else if (Cobj.name == "resource(Clone)")
                            {
                                Debug.Log("�����m��");
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
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    CM.PChange_REAP(apnum, renum);
                                    switch (Now_Move_Anim(_x, _y, Uobj))
                                    {
                                        case 0:
                                            StartCoroutine("MoveUp");
                                            break;
                                        case 1:
                                            StartCoroutine("MoveDown");
                                            break;
                                        case 2:
                                            StartCoroutine("MoveRight");
                                            break;
                                        case 3:
                                            StartCoroutine("MoveLeft");
                                            break;
                                    }
                                    audios.Play();
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    CM.PChange_REAP(apnum, renum);
                                    switch (Now_Move_Anim(_x, _y, Uobj))
                                    {
                                        case 0:
                                            StartCoroutine("MoveUp");
                                            break;
                                        case 1:
                                            StartCoroutine("MoveDown");
                                            break;
                                        case 2:
                                            StartCoroutine("MoveRight");
                                            break;
                                        case 3:
                                            StartCoroutine("MoveLeft");
                                            break;
                                    }
                                    audios.Play();
                                }
                            }
                            break;
                        case "Earcher(Clone)":
                        case "Ecatapalt(Clone)":
                            if (Cobj.name == "grass(Clone)" || Cobj.name == "area2(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    CM.EChange_REAP(apnum, renum);
                                    switch (Now_Move_Anim(_x, _y, Uobj))
                                    {
                                        case 0:
                                            StartCoroutine("MoveUp");
                                            break;
                                        case 1:
                                            StartCoroutine("MoveDown");
                                            break;
                                        case 2:
                                            StartCoroutine("MoveRight");
                                            break;
                                        case 3:
                                            StartCoroutine("MoveLeft");
                                            break;
                                    }
                                    audios.Play();
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    CM.EChange_REAP(apnum, renum);
                                    switch (Now_Move_Anim(_x, _y, Uobj))
                                    {
                                        case 0:
                                            StartCoroutine("MoveUp");
                                            break;
                                        case 1:
                                            StartCoroutine("MoveDown");
                                            break;
                                        case 2:
                                            StartCoroutine("MoveRight");
                                            break;
                                        case 3:
                                            StartCoroutine("MoveLeft");
                                            break;
                                    }
                                    audios.Play();
                                }
                            }
                            break;
                    }
                }
            }
        }
    }

    int Now_Move_Anim(float x, float y, GameObject obj)
    {
        move_pos = new Vector3(-54 + x * 4.5f, 54 - y * 4.5f, 14.0f);
        unit_pos = obj.transform.position;
        vec_x = move_pos.x - unit_pos.x;
        vec_y = move_pos.y - unit_pos.y;

        //�ړ���������𒲂ׂ�
        if (vec_y >= 2.5f)//��
        {
            return 0;
        }
        else if (vec_y <= -2.5f)//��
        {
            return 1;
        }
        else if (vec_x >= 2.5f)//�E
        {
            return 2;
        }
        else if (vec_x <= -2.5f)//��
        {
            return 3;
        }
        return -1;
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
