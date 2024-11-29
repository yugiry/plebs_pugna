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
        canattack = collision.gameObject;
        canallattack = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canattack = null;
        canallattack = null;
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
