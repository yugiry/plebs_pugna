using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_range_hyouji : MonoBehaviour
{
    public GameObject unit_click;
    public Transform parent;
    public GameObject base_point_unit;
    private GameObject unitclick;
    float masume_size=4.5f;
    public void Click_unit()
    {
        //unitclick = unit_click as GameObject; 
        Vector3 pos = parent.transform.localPosition;//クリックされたユニットの位置情報
        if (this.gameObject.name == "Pinfantry(Clone)")
        {
            Destroy_Range();
            Destroy_Range();
            for (float x = -masume_size; x <= +masume_size; x += masume_size)
            {
                for (float y = -masume_size; y <= +masume_size; y += masume_size)
                {
                    unitclick = Instantiate(unit_click, new Vector3(pos.x + x, pos.y + y, 14.0f), Quaternion.identity, parent) as GameObject;

                }
            }

            Debug.Log("クリックされたぞい。");

            // Destroy(unitclick, 1);
        }
        //弓兵処理
        else if (this.gameObject.name == "Parcher(Clone)")
        {
            Destroy_Range();
            Destroy_Range();
            for (float x = -masume_size * 2; x <= +masume_size * 2; x += masume_size)
            {
                for (float y = -masume_size * 2; y <= +masume_size * 2; y += masume_size)
                {
                    unitclick = Instantiate(unit_click, new Vector3(pos.x + x, pos.y + y, 14.0f), Quaternion.identity, parent) as GameObject;
                }

            }
        }
        //カタパルト処理
        else if (this.gameObject.name == "Pcatapalt(Clone)")
        {
            Destroy_Range();
            Destroy_Range();
            for (float x = -masume_size * 4; x <= +masume_size * 4; x += masume_size)
            {
                for (float y = -masume_size * 4; y <= +masume_size * 4; y += masume_size)
                {
                    if (x >= -masume_size * 1 && x <= masume_size * 1 && y >= -masume_size * 1 && y <= masume_size * 1)
                    {

                    }
                    else
                    {
                        unitclick = Instantiate(unit_click, new Vector3(pos.x + x, pos.y + y, 14.0f), Quaternion.identity, parent) as GameObject;
                    }
                }
            }
        }
    }

    private void Destroy_Range()
    {
        GameObject[] unitclick = GameObject.FindGameObjectsWithTag("Respawn");

        if (unit_click.activeSelf) {
            //var unitclick = Instantiate(unit_click) as GameObject;
            foreach (GameObject range_child in unitclick)
            {
                Destroy(range_child);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       //unitclick= Instantiate(unit_click)/* as GameObject*/;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Destroy_Range();
        }
    }
}
