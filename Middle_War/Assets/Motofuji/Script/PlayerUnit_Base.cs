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

    [NonSerialized] public GameObject chobj;
    [NonSerialized] public Pcastlehp PCH;
    [NonSerialized] public Ecastlehp ECH;

    [NonSerialized] public GameObject cmobj;
    [NonSerialized] public CreateMap CM;

    GameObject rcobj;
    [NonSerialized] public Resource_Controll RC;

    [NonSerialized] public int apnum;
    [NonSerialized] public int renum;

    //�G���j�b�g�ւ̍U���s��(���W�P�A���W�Q�A�U���̍ő�͈́A�U���̍ŏ��͈́A�U���́A�N���b�N�����I�u�W�F�N�g�A���I�����Ă���I�u�W�F�N�g)
    public bool Attack_Unit(Vector3 p1, Vector3 p2, float max, float min, int attack, GameObject Cobj, GameObject Uobj)
    {
        Vector3 v;
        v.x = p1.x - p2.x;
        v.y = p1.y - p2.y;
        v.x = Mathf.Abs(v.x);
        v.y = Mathf.Abs(v.y);
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
    public bool Attack_Castle(Vector3 p1, Vector3 p2, float max, float min, int attack, GameObject Uobj)
    {
        Vector3 v;
        v.x = p1.x - p2.x;
        v.y = p1.y - p2.y;
        v.x = Mathf.Abs(v.x);
        v.y = Mathf.Abs(v.y);
        if (v.x <= max * (TILESIZE_X + TILESPACE) && v.y <= max * (TILESIZE_Y + TILESPACE))
        {
            if (v.x >= min * (TILESIZE_X + TILESPACE) || v.y >= min * (TILESIZE_Y + TILESPACE))
            {
                switch (Uobj.tag)
                {
                    case "unit":
                        chobj = GameObject.Find("map");
                        ECH = chobj.GetComponent<Ecastlehp>();
                        ECH.HitAttack(attack);
                        break;
                    case "Eunit":
                        chobj = GameObject.Find("map");
                        PCH = chobj.GetComponent<Pcastlehp>();
                        PCH.HitAttack(attack);
                        break;
                }
                return true;
            }
        }
        return false;
    }

    //���j�b�g�̈ړ�(���j�b�g�̍��Wx�A���j�b�g�̍��Wy�A�}�E�X�̍��W�A �ړ��Ɏg��AP�A�N���b�N�����I�u�W�F�N�g�A���I�����Ă���I�u�W�F�N�g)
    public void Move_Unit(float tx, float ty, Vector3 mousepos, int m_AP, GameObject Cobj, GameObject Uobj)
    {
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
                    switch (Uobj.name)
                    {
                        case "Pinfantry(Clone)":
                            if (Cobj.name == "grass(Clone)")
                            {
                                cmobj = GameObject.Find("map");
                                CM = cmobj.GetComponent<CreateMap>();
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    CM.PChange_REAP(apnum, renum);
                                    Uobj.transform.position = new Vector3(-54 + _x * 4.5f, 54 - _y * 4.5f, 14.0f);
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                cmobj = GameObject.Find("map");
                                CM = cmobj.GetComponent<CreateMap>();
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    CM.PChange_REAP(apnum, renum);
                                    Uobj.transform.position = new Vector3(-54 + _x * 4.5f, 54 - _y * 4.5f, 14.0f);
                                }
                            }
                            else if (Cobj.name == "resource(Clone)")
                            {
                                Debug.Log("�����m��");
                                RC = Cobj.GetComponent<Resource_Controll>();
                                RC.PGetResource();
                            }
                            break;
                        case "Einfantry(Clone)":
                            if (Cobj.name == "grass(Clone)")
                            {
                                cmobj = GameObject.Find("map");
                                CM = cmobj.GetComponent<CreateMap>();
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    CM.EChange_REAP(apnum, renum);
                                    Uobj.transform.position = new Vector3(-54 + _x * 4.5f, 54 - _y * 4.5f, 14.0f);
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                cmobj = GameObject.Find("map");
                                CM = cmobj.GetComponent<CreateMap>();
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    CM.EChange_REAP(apnum, renum);
                                    Uobj.transform.position = new Vector3(-54 + _x * 4.5f, 54 - _y * 4.5f, 14.0f);
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
                            if (Cobj.name == "grass(Clone)")
                            {
                                cmobj = GameObject.Find("map");
                                CM = cmobj.GetComponent<CreateMap>();
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    CM.PChange_REAP(apnum, renum);
                                    Uobj.transform.position = new Vector3(-54 + _x * 4.5f, 54 - _y * 4.5f, 14.0f);
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                cmobj = GameObject.Find("map");
                                CM = cmobj.GetComponent<CreateMap>();
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    CM.PChange_REAP(apnum, renum);
                                    Uobj.transform.position = new Vector3(-54 + _x * 4.5f, 54 - _y * 4.5f, 14.0f);
                                }
                            }
                            break;
                        case "Earcher(Clone)":
                        case "Ecatapalt(Clone)":
                            if (Cobj.name == "grass(Clone)")
                            {
                                cmobj = GameObject.Find("map");
                                CM = cmobj.GetComponent<CreateMap>();
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - m_AP;
                                if (apnum >= 0)
                                {
                                    CM.EChange_REAP(apnum, renum);
                                    Uobj.transform.position = new Vector3(-54 + _x * 4.5f, 54 - _y * 4.5f, 14.0f);
                                }
                            }
                            else if (Cobj.name == "water(Clone)")
                            {
                                cmobj = GameObject.Find("map");
                                CM = cmobj.GetComponent<CreateMap>();
                                apnum = CM.Now_PAP;
                                renum = CM.Now_PResource;
                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                apnum = apnum - (m_AP + 1);
                                if (apnum >= 0)
                                {
                                    CM.EChange_REAP(apnum, renum);
                                    Uobj.transform.position = new Vector3(-54 + _x * 4.5f, 54 - _y * 4.5f, 14.0f);
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
