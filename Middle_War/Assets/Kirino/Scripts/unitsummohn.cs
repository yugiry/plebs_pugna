using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitsummohn : MonoBehaviour
{
  
    GameObject clickedGameObject;

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
            }

        }
      
    }

}
