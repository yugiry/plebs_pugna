using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_TileColor_change : MonoBehaviour
{
    //GameObject Tile;

    // Start is called before the first frame update
    void Start()
    {
        //Tile = GameObject.Find("range tile(Clone)");
    }



    public void OnMouseOver()
    {//�}�E�X�J�[�\����������Ƃ�
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 0.8f);
    }

    public void OnMouseExit()
    {//�}�E�X�J�[�\�����~�肽�Ƃ�
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
