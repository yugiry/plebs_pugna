using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Kirikae : MonoBehaviour
{
    SpriteRenderer test;

    public Sprite[] summon_gazou;

   
    public int image_num;

    public int gazou_sousu;
    private int gazou_nanmai=0;

    public Sprite[] next_gazou;
    public GameObject Next;
    public GameObject Back;
    public void Gazou_wo_Kirikaeyo()
    {
        
        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();
        

        
        test.sprite = summon_gazou[image_num];
        Debug.Log(image_num+"i");
       
        Debug.Log("nooooooon....");

    }

    public void next_hyouji()
    {
        if (this.gameObject.name == "next")
        {
            Debug.Log("fffffffffff!!!");
        }

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        if (gazou_nanmai > gazou_sousu)
        {
            gazou_nanmai=0;
        }
        else
        {
            gazou_nanmai++;
        }
        test.sprite = next_gazou[gazou_nanmai];

        Debug.Log(gazou_nanmai);
    }

    public void back_hyouji()
    {
        if (this.gameObject.name == "back")
        {
            Debug.Log("!!!");
        }

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        if (gazou_nanmai < 0)
        {
            gazou_nanmai = gazou_sousu;
        }
        else
        {
            gazou_nanmai--;
        }
        test.sprite = next_gazou[gazou_nanmai];

        Debug.Log(gazou_nanmai);
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
