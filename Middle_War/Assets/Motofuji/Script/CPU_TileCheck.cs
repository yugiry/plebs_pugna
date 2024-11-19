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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "unit" || collision.tag == "Eunit")
        {
            onunit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "unit" || collision.tag == "Eunit")
        {
            onunit = false;
        }
    }

    public bool Check_Unit()
    {
        if(onunit)
        {
            return true;
        }
        return false;
    }
}
