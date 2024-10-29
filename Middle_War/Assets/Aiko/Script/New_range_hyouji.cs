using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_range_hyouji : MonoBehaviour
{
    public GameObject unit_click;
    public Transform parent;
    public GameObject base_point_unit;
    private GameObject unitclick;
    public void Click_unit()
    {
        //unitclick = unit_click as GameObject; 

        Vector3 pos = parent.transform.localPosition;//クリックされたユニットの位置情報
        if ( GameObject.Find("infantry"))
        {
            Destroy_Range();
            Destroy_Range();
            for (float x = - 4.0f; x <= +4.0f; x += 4.0f)
            {
                for (float y = -4.0f; y <= +4.0f; y += 4.0f)
                {
                    unitclick = Instantiate(unit_click, new Vector3(pos.x+x, pos.y+y, -5.5f), Quaternion.identity, parent) as GameObject;
                }

            }

            
            Debug.Log("クリックされたぞい。");
             
           // Destroy(unitclick, 1);
        }else if (GameObject.Find("archer"))
        {
            Destroy_Range();
            Destroy_Range();
            for (float x = -4.0f; x <= +4.0f; x += 4.0f)
            {
                for (float y = -4.0f; y <= +4.0f; y += 4.0f)
                {
                    unitclick = Instantiate(unit_click, new Vector3(pos.x + x, pos.y + y, -5.5f), Quaternion.identity, parent) as GameObject;
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
        
    }
}
