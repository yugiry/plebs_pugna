using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack_Check : MonoBehaviour
{
    GameObject canattack;
    GameObject canallattack;

    private void Start()
    {
        canattack = null;
        canallattack = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "unit")
        {
            canattack = collision.gameObject;
            canallattack = collision.gameObject;
        }
        else if (collision.name == "castle1(Clone)")
        {
            canallattack = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "unit")
        {
            canattack = null;
            canallattack = null;
        }
        if(collision.name == "castle1(Clone)")
        {
            canallattack = null;
        }
    }

    public GameObject Can_Attack()
    {
        return canattack;
    }

    public GameObject Can_AllAttack()
    {
        return canallattack;
    }
}
