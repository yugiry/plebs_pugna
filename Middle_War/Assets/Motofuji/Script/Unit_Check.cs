using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Check : MonoBehaviour
{
    [SerializeField] bool onunit = false;
    public int tilenum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���j�b�g������Ȃ�true�ɂ���
        if (collision.tag == "Eunit" || collision.tag == "unit")
        {
            onunit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //���j�b�g�����Ȃ��Ȃ�����false�ɂ���
        if (collision.tag == "Eunit" || collision.tag == "unit")
        {
            onunit = false;
        }
    }

    public bool OnUnit()
    {
        if (onunit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
