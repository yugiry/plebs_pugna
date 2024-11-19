using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Check : MonoBehaviour
{
    GameObject canmove;
    bool onunit;

    private void Start()
    {
        canmove = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "unit" || collision.tag == "Eunit")
        {
            canmove = null;
            onunit = true;
        }


        if (collision.name == "grass(Clone)" || collision.name == "area2(Clone)")
        {
            if (!onunit)
            {
                canmove = collision.gameObject;
            }
        }
        else if (collision.name == "water(Clone)")
        {
            if (!onunit)
            {
                canmove = collision.gameObject;
            }
        }
        else if(collision.name == "resource(Clone)")
        {
            canmove = collision.gameObject;
        }
        else
        {
            canmove = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "unit" || collision.tag == "Eunit")
        {
            onunit = false;
        }
    }

    public GameObject Can_Move()
    {
        return canmove;
    }
}
