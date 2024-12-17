using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack_Check : MonoBehaviour
{
    GameObject canattack;

    private void Start()
    {
        canattack = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //unit�^�O���������I�u�W�F�N�g���U���\�͈͂ɓ�������f�[�^�ۑ�
        if (collision.tag == "unit")
        {
            canattack = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //unit�^�O���������I�u�W�F�N�g���U���\�͈͂��o����f�[�^�폜
        if (collision.gameObject == canattack)
        {
            canattack = null;
        }
    }

    public GameObject Can_Attack()
    {
        return canattack;
    }
}
