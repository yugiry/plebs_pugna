using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Check : MonoBehaviour
{
    [SerializeField] bool onunit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Eunit" || collision.tag == "unit" || collision.name == "move_checker")
        {
            onunit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
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
