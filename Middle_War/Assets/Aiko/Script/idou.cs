using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class idou : MonoBehaviour
{
    public GameObject koma;
    public GameObject idouhanni;
    public bool myturn;



    private GameObject GetClickObject()
    {
        GameObject result = null;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                result = collition2d.transform.gameObject;
            }
        }
        return result;
    }


    void Update()
    {
        GameObject obj = GetClickObject();
        if (obj != null)
        {
            koma.transform.position = GetClickObject().transform.position;
        }

        if (obj != null)
        {
            koma.SetActive(!idouhanni.activeInHierarchy);
        }
    }
}