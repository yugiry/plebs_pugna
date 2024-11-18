using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Check : MonoBehaviour
{
    int canmove;
    bool onunit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "unit")
        {
            canmove = 0;
            onunit = true;
        }
        else if (collision.name == "grass(Clone)" || collision.name == "area2(Clone)")
        {
            if (!onunit)
            {
                canmove = 1;
            }
        }
        else if(collision.name == "water(Clone)")
        {
            if (!onunit)
            {
                canmove = 2;
            }
        }

        if (collision.name == "mountain(Clone)" || collision.name == "resource(Clone)" || collision.name == "castle2(Clone)" || collision.name == "area1(Clone)" || collision.name == "castle1(Clone)")
        {
            canmove = 0;
        }
        if(collision.tag == "Eunit")
        {
            canmove = 0;
            onunit = true;
        }

        if(collision.name == "outside")
        {
            canmove = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "unit" || collision.tag == "Eunit")
        {
            canmove = 0;
            onunit = false;
        }
        if (collision.name == "grass(Clone)" || collision.name == "water(Clone)" || collision.name == "area2(Clone)")
        {
            canmove = 0;
        }
    }

    public int Can_Move()
    {
        return canmove;
    }
}
