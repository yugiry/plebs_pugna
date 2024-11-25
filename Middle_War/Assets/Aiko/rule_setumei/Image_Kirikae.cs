using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Kirikae : MonoBehaviour
{
    SpriteRenderer test;

    public Sprite[] summon_gazou;


    /*[SerializeField]*/public int image_num;
    /*[SerializeField]*/public int img;

    /*[SerializeField]*/public int gazou_sousu;
    /*[SerializeField]*/public int gazou_nanmai;

    public Sprite[] next_gazou;
    [SerializeField] GameObject Next;
    [SerializeField] GameObject Back;

    private void Awake()
    {
        Next = GameObject.Find("Canvas(ALL)/kirikae_I/next hyouji");
        Back = GameObject.Find("Canvas(ALL)/kirikae_I/back hyouji");
        
    }

    public void Gazou_wo_Kirikaeyo()
    {
        img = image_num;

        Debug.Log("img_tag" + img);

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai = -1;
        
        test.sprite = summon_gazou[image_num];
        Debug.Log(image_num+"i");
       
        
        Debug.Log("SOUSU" + gazou_sousu);

        if(gazou_sousu>0)
        {
           
                Next.SetActive(true);
                Back.SetActive(false);

            
        }
        else
        {
            
                Next.SetActive(false);
                Back.SetActive(false);
            
        }

    }

    public void next_hyouji()
    {
        img = image_num;
        Debug.Log("img_tag" + img);

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai++;

        if (gazou_nanmai == gazou_sousu-1)
        {
            gazou_nanmai = gazou_sousu-1;
            
            Debug.Log("Gazouha0"+gazou_nanmai);
            test.sprite = next_gazou[gazou_nanmai];
            if (Next.activeSelf)
            {
                Next.SetActive(false);
                Back.SetActive(true);
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
        img = image_num;
        Debug.Log("img_tag" + img);

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai--;

        if (gazou_nanmai <= -1)
        {

            gazou_nanmai = -1;
            Debug.Log("Gazouha0" + gazou_nanmai);
            test.sprite = summon_gazou[img];
            if (Back.activeSelf)
            {
                Back.SetActive(false);
                Next.SetActive(true);
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
        //Next = GameObject.Find("next hyouji");
        //Back = GameObject.Find("back hyouji");
        // Next.SetActive(false);
        // Back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
