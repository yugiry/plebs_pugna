using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_back_button : MonoBehaviour
{
    SpriteRenderer test;

    public int hyouji_num;

    //public int image_num;

    //public int gazou_sousu;
    //private int gazou_nanmai = 0;

    //public Sprite[] next_gazou;
    GameObject obj;
    Image_Switch IK;
    public Transform parent;

    public int i1;
    public int i2;
    public int i3;
    public int i4;

    public int fullpage;
    public int page;

    public void n_hyouji()
    {
        obj = parent.transform.Find("rule_hyouji_button").gameObject;
        //obj = GameObject.FindWithTag("Finish");

        IK = obj.GetComponent<Image_Switch>(); //付いているスクリプトを取得

        //page++;

        //if (page > fullpage)
        //{
        //    page = fullpage;
        //}

        //if(hyouji_num==1&&page==1)
        //{

        //}

        //i1 = IK.image_num;
        //i2 = IK.img;
        //i3 = IK.gazou_sousu;
        //i4 = IK.gazou_nanmai;

        IK.display_next();
       
        Debug.Log("i2" + i2);
    }

    public void b_hyouji()
    {
        obj = parent.transform.Find("rule_hyouji_button").gameObject;
        //obj = GameObject.FindWithTag("Finish");

        IK = obj.GetComponent<Image_Switch>(); //付いているスクリプトを取得

        //page--;
        //if(page < 1)
        //{
        //    page = 1;
        //}

        //i1 = IK.image_num;
        //i2 = IK.img;
        //i3 = IK.gazou_sousu;
        //i4 = IK.gazou_nanmai;
        IK.display_back();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //obj = GameObject.Find("rule_hyouji_button");
        //IK = obj.GetComponent<Image_Kirikae>(); //付いているスクリプトを取得

        //i1 = IK.image_num;
        //i2 = IK.img;
        //i3 = IK.gazou_sousu;
        //i4 = IK.gazou_nanmai;

        //Debug.Log("i1" + i1);
        //Debug.Log("i2" + i2);
        //Debug.Log("i3" + i3);
        //Debug.Log("i4" + i4);
    }
}
