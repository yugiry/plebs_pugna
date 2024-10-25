using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitsummohn : MonoBehaviour
{
   
   // public Canvas m_canvasRoot;
   // public RectTransform m_rtParent;
   // public RectTransform m_rtTarget;
    GameObject clickedGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            clickedGameObject = hit2d.transform.gameObject;
            if (clickedGameObject.name == "area1(Clone)")
            {
                
                Debug.Log(clickedGameObject.name);//ゲームオブジェクトの名前を出力
                this.gameObject.transform.Find("area1(Clone)").gameObject.SetActive(true);

                Destroy(clickedGameObject);//ゲームオブジェクトを破壊

                //position_manager pm = new position_manager();
                //pm.set_koma_select_position(this.gameObject.transform.parent.gameObject.transform.parent.gameObject, 4, 8);
                //Debug.Log("You clicked " + this.name);
                //this.gameObject.transform.Find("").gameObject.SetActive(true);
            }

        }
      
    }

    public void Click()
    {
        //infantrystatus.SetActive(true);
        //archerstatus.SetActive(true);
        //catapultstatus.SetActive(true);
    }

}
