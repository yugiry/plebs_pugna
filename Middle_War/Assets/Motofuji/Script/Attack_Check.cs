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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canattack = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canattack = null;
    }

    public GameObject Can_Attack()
    {
        return canattack;
    }
}
