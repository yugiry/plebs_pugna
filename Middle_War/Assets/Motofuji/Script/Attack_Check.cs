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
        //unitタグを持ったオブジェクトが攻撃可能範囲に入ったらデータ保存
        if (collision.tag == "unit")
        {
            canattack = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //unitタグを持ったオブジェクトが攻撃可能範囲を出たらデータ削除
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
