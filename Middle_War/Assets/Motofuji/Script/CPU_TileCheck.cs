using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU_TileCheck : MonoBehaviour
{
    [SerializeField] bool onunit;

    private void Start()
    {
        onunit = false;   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "unit" || collision.tag == "Eunit" || collision.name == "move_checker")
        {
            onunit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "unit" || collision.tag == "Eunit" || collision.name == "move_checker")
        {
            onunit = false;
        }
    }

    public bool Check_Unit()
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
