using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    //�G���j�b�g�ւ̍U���s��(���W�P�A���W�Q�A�U���̍ő�͈́A�U���̍ŏ��͈́A�N���b�N�����I�u�W�F�N�g)
    public void Attack_Unit(Vector3 p1, Vector3 p2, float max, float min, GameObject obj)
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

            }
        }
    }

    //��ւ̍U���s��()
    public void Attack_Castle()
    {

    }
}
