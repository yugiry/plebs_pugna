using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_clear_flag : MonoBehaviour
{
    public int country_num;
    [SerializeField]GameObject[] clear_flag_obj;
    GameObject rcfobj;
    clear_flag_operation CFR;

    private void Start()
    {
        rcfobj = GameObject.Find("remenber_clear_flag");
        CFR = rcfobj.GetComponent<clear_flag_operation>();

        //全ての国分調べる
        for (int i = 0; i < country_num; i++)
        {
            if (CFR.clear_flag[i])
            {
                //クリアフラグが立っている場合フラグを表示する
                clear_flag_obj[i].SetActive(true);
            }
        }
    }
}
