using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Kirikae : MonoBehaviour
{

    GameObject button;

    
    public int mode_change;

    SpriteRenderer test;

    public Sprite[] summon_gazou;

    int i1;
    int i2;
    int i3;
    int i4;

    /*[SerializeField]*/
    [field: SerializeField] public int image_num { get; set; }
   
    

    /*[SerializeField]*/
    [field: SerializeField] public int img { get; set; }

    

    /*[SerializeField]*/
     [field: SerializeField]
    public int gazou_sousu
    { get; set; }
    

    /*[SerializeField]*/
     [field: SerializeField]
    public int gazou_nanmai
    {
        get; set;
    }

    //GameObject Next;
    //GameObject Back;

    public Sprite[] next_gazou;
    [SerializeField] GameObject Next;
    [SerializeField] GameObject Back;

    private void Awake()
    {
        //Next = GameObject.Find("Canvas(ALL)/rule_hyouji_button/next hyouji");
        //Back = GameObject.Find("Canvas(ALL)/rule_hyouji_button/back hyouji");

        //Next = GameObject.Find("Canvas(ALL)/kirikae_I/next hyouji");
        //Back = GameObject.Find("Canvas(ALL)/kirikae_I/back hyouji");
        


    }

    void Start()
    {
        //Next = button.transform.Find("next_hyouji").gameObject;
        //Back = button.transform.Find("back_hyouji").gameObject;
        //button = GameObject.Find("rule_hyouji_button");

        //Next = GameObject.Find("next hyouji");
        //Back = GameObject.Find("back hyouji");
        // Next.SetActive(false);
        // Back.SetActive(false);
        //NBB=GetComponent<next_back_button>();
    }

    //public void Destroy_NB()
    //{
    //    GameObject[] next_back = GameObject.FindGameObjectsWithTag("Finish");

    //    if (next_back.activeSelf)
    //    {
    //        //var unitclick = Instantiate(unit_click) as GameObject;
    //        foreach (GameObject N_B in next_back)
    //        {
    //            N_B.SetActive(false);
                
    //        }
    //    }
    //}

    public void Gazou_wo_Kirikaeyo()
    {
        //Destroy_NB();

        Next.SetActive(false);
        Back.SetActive(false);

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

        //switch (mode_change)
        //{
        //    case 1:
        //        NBB.fullpage = 4;
        //        NBB.hyouji_num = mode_change;
        //        break;
        //    case 2:
        //        NBB.fullpage = 1;
        //        NBB.hyouji_num = mode_change;
        //        break;
        //    case 3:
        //        NBB.fullpage = 2;
        //        NBB.hyouji_num = mode_change;
        //        break;
        //    case 4:
        //        NBB.fullpage = 1;
        //        NBB.hyouji_num = mode_change;
        //        break;
        //    case 5:
        //        NBB.fullpage = 3;
        //        NBB.hyouji_num = mode_change;
        //        break;
        //    case 6:
        //        NBB.fullpage = 1;
        //        NBB.hyouji_num = mode_change;
        //        break;
        //    case 7:
        //        NBB.fullpage = 1;
        //        NBB.hyouji_num = mode_change;
        //        break;
        //    case 8:
        //        NBB.fullpage = 1;
        //        NBB.hyouji_num = mode_change;
        //        break;
        //}

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

    public void sansyo()
    {
       i1= image_num;
       i2= img;
       i3= gazou_sousu;
       i4= gazou_nanmai;

        Debug.Log("image_num"+i1+"image_num");
    }
   

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
