using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Check : MonoBehaviour
{
    GameObject canmove;
    CPU_TileCheck CTC;

    private void Start()
    {
        canmove = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "unit" || collision.tag == "Eunit")
        //{
        //    canmove = null;
        //    onunit = true;
        //}

        if (collision.name == "grass(Clone)" || collision.name == "area2(Clone)")
        {
            CTC = collision.GetComponent<CPU_TileCheck>();
            if(CTC != null)
            {
                if(!CTC.Check_Unit())
                {
                    canmove = collision.gameObject;
                }
                else
                {
                    canmove = null;
                }
            }
            else
            {
                Debug.Log("CTCÅAnull");
                canmove = null;
            }
        }
        else if (collision.name == "water(Clone)")
        {
            CTC = collision.GetComponent<CPU_TileCheck>();
            if (CTC != null)
            {
                if (!CTC.Check_Unit())
                {
                    canmove = collision.gameObject;
                }
                else
                {
                    canmove = null;
                }
            }
            else
            {

                Debug.Log("CTCÅAnull");
                canmove = null;
            }
        }
        else if(collision.name == "resource(Clone)")
        {
            canmove = collision.gameObject;
        }
    }

    public GameObject Can_Move()
    {
        return canmove;
    }

    public void Null_CanMove()
    {
        canmove = null;
    }
}
