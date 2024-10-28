using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_range_hyouji : MonoBehaviour
{
    public GameObject unit_click;
    public Transform parent;
    public GameObject base_point_unit;
    GameObject unitclick;
    public void Click_unit()
    {
         
        Vector3 pos = parent.transform.localPosition;
        if ( GameObject.Find("infantry"))
        {

            Instantiate(unit_click, new Vector3(pos.x + 4.0f, pos.y + 4.0f, -4.0f), Quaternion.identity,parent);
            Debug.Log("クリックされたぞい。");
            // Destroy_Range();
            Destroy(unitclick);
        }



    }

    private void Destroy_Range()
    {
        //var unitclick = Instantiate(unit_click) as GameObject;
        Destroy(unitclick);

    }

    // Start is called before the first frame update
    void Start()
    {
       unitclick= Instantiate(unit_click)/* as GameObject*/;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
