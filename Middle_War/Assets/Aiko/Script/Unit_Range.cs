using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit_Range : MonoBehaviour, IPointerClickHandler
{
    public GameObject kougekihanni;
    
    public void OnPointerClick(PointerEventData eventdata)
    {
        //var eventData = (PointerEventData)data;
        
        //kougekihanni.transform.position = new Vector3(100, 0, 0);
        Active_false_selected_by_Tag("Respawn");

        Debug.Log(this.name+"クリックされた");
        //GameObject newBlock = Instantiate(kougekihanni, kougekihanni.transform.position, Quaternion.identity);
        this.gameObject.transform.Find("ranges").gameObject.SetActive(true);
        
    }

    //public void OnPointerClick2(PointerEventData eventdata)
    //{
    //    Active_false_selected_by_Tag("Respawn");

    //    Debug.Log(this.name + "クリックされた2");

    //    //Active_false_selected_by_Tag("Respawn");
    //    this.gameObject.transform.Find("range tile").gameObject.SetActive(false);
    //}

    public void Active_false_selected_by_Tag(string tag)
    {
        // Hierarchy状のタグのついたオブジェクトをすべて格納
        GameObject[] tags = GameObject.FindGameObjectsWithTag(tag);

        // すべてのタグを非表示にする
        foreach (GameObject t in tags)
        {
            t.SetActive(false);
        }
    }

   

    // Start is called before the first frame update
   

    // Update is called once per frame
     void Update()
    {
        //if (Input.GetMouseButtonUp(0) && count == 0)
        //{
        //    OnPointerClick();

            //    count++;
            //}
        ///*else*/ if (Input.GetMouseButtonUp(0)/* && count != 0*/)
        //{
        //    Active_false_selected_by_Tag("Respawn");
        //    //count--;
        //}


    }
}
