using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit_Range : MonoBehaviour/*,IPointerClickHandler*/
{
   

    public GameObject kougekihanni;

    public void OnPointerClick(/*PointerEventData eventdata*/)
    {
        //var eventData = (PointerEventData)data;

        //kougekihanni.transform.position = new Vector3(100, 0, 0);
        Active_false_selected_by_Tag("Respawn");

        Debug.Log(this.name+"�N���b�N���ꂽ");
        //GameObject newBlock = Instantiate(kougekihanni, kougekihanni.transform.position, Quaternion.identity);
        this.gameObject.transform.Find("range tile").gameObject.SetActive(true);
    }

    public void Active_false_selected_by_Tag(string tag)
    {
        // Hierarchy��̃^�O�̂����I�u�W�F�N�g�����ׂĊi�[
        GameObject[] tags = GameObject.FindGameObjectsWithTag(tag);

        // ���ׂẴ^�O���\���ɂ���
        foreach (GameObject t in tags)
        {
            t.SetActive(false);
        }
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
