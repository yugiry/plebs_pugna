using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_TileColor_change : MonoBehaviour
{
   // public GameObject Tile;

    // Start is called before the first frame update
    void Start()
    {
        //Tile = GameObject.Find("range tile(Clone)");
    }



    public void OnMouseOver()
    {//�}�E�X�J�[�\����������Ƃ�
        //this.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 1.0f, 0.8f);
        this.GetComponent<Renderer>().material.color = Color.blue;
        Debug.Log("change!");
    }

    public void OnMouseExit()
    {//�}�E�X�J�[�\�����~�肽�Ƃ�
        //this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
        this.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("not change!");
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
