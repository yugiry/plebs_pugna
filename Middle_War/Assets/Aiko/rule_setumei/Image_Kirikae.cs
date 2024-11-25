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
    public int gazou_nanmai;

    public Sprite[] next_gazou;
     GameObject Next;
     GameObject Back;

    

    public void Gazou_wo_Kirikaeyo()
    {
        
        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai = -1;
        
        test.sprite = summon_gazou[image_num];
        Debug.Log(image_num+"i");
       
        
        Debug.Log("SOUSU" + gazou_sousu);

        if(gazou_sousu>0)
        {
            if (!Next.activeSelf || !Back.activeSelf)
            {
                Next.SetActive(true);
                Back.SetActive(true);

            }
        }
        else
        {
            if (Next.activeSelf||Back.activeSelf)
            {
                Next.SetActive(false);
                Back.SetActive(false);
            }
        }

    }

    public void next_hyouji()
    {
        if (this.gameObject.name == "next")
        {
            Debug.Log("fffffffffff!!!");
        }

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai++;

        if (gazou_nanmai >= gazou_sousu)
        {
            gazou_nanmai = gazou_sousu - 1;
            
            Debug.Log("Gazouha0"+gazou_nanmai);
            //test.sprite = summon_gazou[image_num];
            if (Next.activeSelf)
            {
                Next.SetActive(false);
            }
        }
        else
        {
            
            Debug.Log("gazounannmai" + gazou_nanmai);
            test.sprite = next_gazou[gazou_nanmai];
            Back.SetActive(true);
        }
        

        
    }

    public void back_hyouji()
    {
        if (this.gameObject.name == "back")
        {
            Debug.Log("!!!");
        }

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai--;

        if (gazou_nanmai == -1)
        {

            gazou_nanmai = -1;
            Debug.Log("Gazouha0" + gazou_nanmai);
            test.sprite = summon_gazou[image_num];
            if (Back.activeSelf)
            {
                Back.SetActive(false);
            }
        }
        else
        {
            
            test.sprite = next_gazou[gazou_nanmai];
            Next.SetActive(true);
        }
        

        Debug.Log(gazou_nanmai);
    }

    // Start is called before the first frame update
    void Start()
    {
        Next = GameObject.Find("next hyouji");
        Back = GameObject.Find("back hyouji");
        Next.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
