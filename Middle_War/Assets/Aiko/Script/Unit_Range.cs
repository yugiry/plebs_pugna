using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit_Range : MonoBehaviour/*,IPointerClickHandler*/
{
    public void OnPointerClick(/*PointerEventData eventdata*/)
    {
        //var eventData = (PointerEventData)data;

        Debug.Log(this.name+"ƒNƒŠƒbƒN‚³‚ê‚½");
        this.gameObject.transform.Find("range tile").gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
