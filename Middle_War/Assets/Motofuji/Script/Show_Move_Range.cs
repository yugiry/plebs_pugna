using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Show_Move_Range : MonoBehaviour
{
    GameObject mapobj;
    CreateMap CM;
    int ap;
    public GameObject move_range;
    private GameObject unitclick;
    Unit_Tile_Check UTC;
    Unit_Operation UO;

    [SerializeField] int[] move_range_research;

    private void Start()
    {
        mapobj = GameObject.Find("map");
        CM = mapobj.GetComponent<CreateMap>();
        UO = this.GetComponent<Unit_Operation>();
        UTC = mapobj.GetComponent<Unit_Tile_Check>();
        move_range_research = new int[CM.MAPSIZE_X * CM.MAPSIZE_Y];
    }

    //AP�c�ʂɂ���Ĉړ��ł���͈͂�\��(�}�b�v���WX�A�}�b�v���WY)
    public void Summon_Move_Range(int x, int y)
    {
        //�z��̏�����
        for (int i = 0; i < CM.MAPSIZE_Y; i++)
        {
            for (int j = 0; j < CM.MAPSIZE_X; j++)
            {
                move_range_research[i * 25 + j] = -1;
            }
        }
        int dx = 0, dy = 0;//���ׂ�ʒu���c���Ă������߂̕ϐ�
        int summon_x, summon_y;//Instantiate���g�p����Ƃ��Ɏg�����W
        ap = CM.Now_PAP / UO.move_ap;

        move_range_research[y * 25 + x] = ap;

        //AP�̗ʂɂ���Ĉړ��\�Ȕ͈͂𒲂ׂ�
        for (int c = ap; c > 0; c--)
        {
            //�}�b�v�̑S�}�X�𒲂ׂ�
            for (int i = 0; i < CM.MAPSIZE_Y; i++)
            {
                for (int j = 0; j < CM.MAPSIZE_X; j++)
                {
                    if (move_range_research[i * 25 + j] == c)
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
                            summon_x = j + dx;
                            summon_y = i + dy;
                            if (summon_x < 0) summon_x = 0;
                            if (summon_y < 0) summon_y = 0;
                            if (summon_x >= 25) summon_x = 24;
                            if (summon_y >= 25) summon_y = 24;
                            //�^�C�������������͐��Ń��j�b�g�����Ȃ��ꍇ���l��u��
                            if (move_range_research[summon_x + summon_y * 25] == -1 && (CM.map[summon_x + summon_y * 25] == 0 || CM.map[summon_x + summon_y * 25] == 2) && !UTC.tile[summon_x + summon_y * 25])
                                move_range_research[summon_x + summon_y * 25] = c - 1;
                        }
                    }
                }
            }
        }

        //�͈͂̕\��
        for (int i = 0; i < CM.MAPSIZE_Y; i++)
        {
            for (int j = 0; j < CM.MAPSIZE_X; j++)
            {
                //�����̈ʒu��0�ȉ��̐��l�̎��͕\�����Ȃ�
                if (move_range_research[i * 25 + j] >= 0 && move_range_research[i * 25 + j] != ap)
                {
                    unitclick = Instantiate(move_range, new Vector3(-54 + (4 + 0.5f) * j, 54 - (4 + 0.5f) * i, 15.0f), Quaternion.identity);
                }
            }
        }
    }

    public void Destroy_Move_Range()
    {
        //move_range�̃^�O�������Ă���I�u�W�F�N�g��S�Ē��ׂ�
        GameObject[] unitclick = GameObject.FindGameObjectsWithTag("move_range");

        if (move_range.activeSelf)
        {
            //�ړ��͈͂̃I�u�W�F�N�g��S�č폜����
            foreach (GameObject range_child in unitclick)
            {
                Destroy(range_child);
                Debug.Log("destroy");
            }
        }
    }
}
