using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Next_Back
{
    public static int next_back_room = 0;
}

public class next_back_button : MonoBehaviour
{
    SpriteRenderer test;

    //public int image_num;

    //public int gazou_sousu;
    //private int gazou_nanmai = 0;

    //public Sprite[] next_gazou;

    Image_Kirikae IK;
    //GameObject obj = GameObject.Find("next");
    

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
        IK = GetComponent<Image_Kirikae>(); //付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
