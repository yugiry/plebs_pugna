using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remenber_country_num : MonoBehaviour
{
    public int country_num;
    public bool clear_flag;

    private void Awake()
    {
       
    }

    public void Check_GameClear()
    {
        //�G�̏��j�󂵂���N���A�t���O��true�ɂ���
        clear_flag = true;
    }

    public void Check_GameOver()
    {
        //�v���C���[�̏邪�j�󂳂ꂽ��N���A�t���O��false�ɂ���
        clear_flag = false;
    }
}
