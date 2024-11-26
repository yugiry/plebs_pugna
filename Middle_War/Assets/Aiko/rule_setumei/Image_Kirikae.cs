using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Kirikae : MonoBehaviour
{
     next_back_button NBB;
    public int mode_change;

    SpriteRenderer test;

    public Sprite[] summon_gazou;

    int i1;
    int i2;
    int i3;
    int i4;

    /*[SerializeField]*/
    [field: SerializeField] public int image_num { get; set; }
   
    //public int i1{
    //    get
    //    {
    //       return image_num;
    //    }
    //    set 
    //    {
    //        image_num = value;
    //    }

    //}
    /*[SerializeField]*/
    [field: SerializeField] public int img { get; set; }

    //public int i2{
    //    get
    //    {
    //        return img;
    //    }
    //    set
    //    {
    //        img = value;
    //    }

    //}

    /*[SerializeField]*/
     [field: SerializeField]
    public int gazou_sousu
    { get; set; }
    
    //public int i3{
    //    get
    //    {
    //        return gazou_sousu;
    //    }
    //    set
    //    {
    //        gazou_sousu = value;
    //    }

    //}
    /*[SerializeField]*/
     [field: SerializeField]
    public int gazou_nanmai
    {
        get; set;
    }
    
    //public int i4{
    //    get
    //    {
    //        return gazou_nanmai;
    //    }
    //    set
    //    {
    //        gazou_nanmai = value;
    //    }

    //}

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

        switch (mode_change)
        {
            case 1:
                NBB.fullpage = 4;
                NBB.hyouji_num = mode_change;
                break;
            case 2:
                NBB.fullpage = 1;
                NBB.hyouji_num = mode_change;
                break;
            case 3:
                NBB.fullpage = 2;
                NBB.hyouji_num = mode_change;
                break;
            case 4:
                NBB.fullpage = 1;
                NBB.hyouji_num = mode_change;
                break;
            case 5:
                NBB.fullpage = 3;
                NBB.hyouji_num = mode_change;
                break;
            case 6:
                NBB.fullpage = 1;
                NBB.hyouji_num = mode_change;
                break;
            case 7:
                NBB.fullpage = 1;
                NBB.hyouji_num = mode_change;
                break;
            case 8:
                NBB.fullpage = 1;
                NBB.hyouji_num = mode_change;
                break;
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
        NBB=GetComponent<next_back_button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
