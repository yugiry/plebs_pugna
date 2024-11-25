using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class next_back_button : MonoBehaviour
{
    SpriteRenderer test;

    //public int image_num;

    //public int gazou_sousu;
    //private int gazou_nanmai = 0;

    //public Sprite[] next_gazou;
    GameObject obj;
    Image_Kirikae IK;

    int i;
    int i2;
    int i3;

    public void n_hyouji()
    {
        
        IK.next_hyouji();
    }

    public void b_hyouji()
    {
        
        IK.back_hyouji();
        
    }


    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("rule_hyouji_button");

        IK = obj.GetComponent<Image_Kirikae>(); //付いているスクリプトを取得
        
    }

    // Update is called once per frame
    void Update()
    {
        i = IK.img;
        i2 = IK.image_num;
        i3 = IK.gazou_nanmai;
    }
}
