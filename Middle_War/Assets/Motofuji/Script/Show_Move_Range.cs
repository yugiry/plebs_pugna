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

    private void Start()
    {
        mapobj = GameObject.Find("map");
        CM = mapobj.GetComponent<CreateMap>();
    }

    //AP残量によって移動できる範囲を表示(マップ座標X、マップ座標Y)
    public void Summon_Move_Range(int x, int y)
    {
        int tmp1;
        int tmp2;
        ap = CM.Now_PAP;
        for (int i = y - ap; i <= y + ap; i++)
        {
            tmp1 = Math.Abs(i - y);
            tmp2 = Math.Abs(tmp1 - ap);
            for (int j = x - tmp2; j <= x + tmp2; j++)
            {
                if (i >= 0 && i < 25 && j >= 0 && j < 25)
                    if (i == y && j == x)
                    {

                    }
                    else if (CM.map[i * 25 + j] == 0 || CM.map[i * 25 + j] == 2)
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
