using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_TileColor_change : MonoBehaviour
{
   public GameObject Tile;
    
    public void OnMouseOver()
    {//�}�E�X�J�[�\����������Ƃ�
        
       
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 0.8f);
        
    }

    public void OnMouseExit()
    {//�}�E�X�J�[�\�����~�肽�Ƃ�
        
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 0.4f);
        
    }

    
}
