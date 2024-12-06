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

    int[] move_range_research;

    private void Start()
    {
        mapobj = GameObject.Find("map");
        CM = mapobj.GetComponent<CreateMap>();
        UO = this.GetComponent<Unit_Operation>();
        move_range_research = new int[CM.MAPSIZE_X * CM.MAPSIZE_Y];
    }

    //AP�c�ʂɂ���Ĉړ��ł���͈͂�\��(�}�b�v���WX�A�}�b�v���WY)
    public void Summon_Move_Range(int x, int y)
    {
        for (int i = 0; i < CM.MAPSIZE_Y; i++)
        {
            for (int j = 0; j < CM.MAPSIZE_X; j++)
            {
                move_range_research[i * 25 + j] = -1;
            }
        }
        //int tmp1, tmp2;
        int dx = 0, dy = 0;//���ׂ�ʒu���c���Ă������߂̕ϐ�
        int summon_x, summon_y;//Instantiate������Ƃ��Ɏg�����W
        ap = CM.Now_PAP / UO.move_ap;
        ap = 1;

        move_range_research[y * 25 + x] = ap;

        //AP�̗ʂňړ��\�Ȕ͈͂𒲂ׂ�
        for (int c = ap; c > 0; c--)
        {
            for (int i = 0; i < CM.MAPSIZE_Y; i++)
            {
                for (int j = 0; j < CM.MAPSIZE_X; j++)
                {
                    if (move_range_research[i * 25 + j] == ap)
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
                            summon_x = x + dx;
                            summon_y = y + dy;
                            if (move_range_research[summon_x + summon_y * 25] == 0 || move_range_research[summon_x + summon_y * 25] == 0)
                                move_range_research[summon_x + summon_y * 25] = c - 1;
                        }
                    }
                }
            }
        }

        for (int i = 0; i < CM.MAPSIZE_Y; i++)
        {
            for (int j = 0; j < CM.MAPSIZE_X; j++)
            {
                if(move_range_research[i * 25 + j] != ap && move_range_research[i * 25 + j] >= 0)
                {
                    unitclick = Instantiate(move_range, new Vector3(-54 + (4 + 0.5f) * j, 54 - (4 + 0.5f) * i, 15.0f), Quaternion.identity);
                }
            }
        }
    }

    public void Destroy_Move_Range()
    {
        GameObject[] unitclick = GameObject.FindGameObjectsWithTag("move_range");

        if (move_range.activeSelf)
        {
            //var unitclick = Instantiate(unit_click) as GameObject;
            foreach (GameObject range_child in unitclick)
            {
                Destroy(range_child);
                Debug.Log("destroy");
            }
        }
    }
}
