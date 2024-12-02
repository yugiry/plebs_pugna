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
        clear_flag = true;
    }

    public void Check_GameOver()
    {
        clear_flag = false;
    }
}
