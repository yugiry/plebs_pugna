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
    [SerializeField] GameObject Next1;
    [SerializeField] GameObject Back2;

    [SerializeField] GameObject Next;
    [SerializeField] GameObject Back;
    private GameObject button_hyouji1;
    private GameObject button_hyouji2;
    public Transform parent;

    private void Awake()
    {
        //Next = GameObject.Find("Canvas(ALL)/rule_hyouji_button/next hyouji");
        //Back = GameObject.Find("Canvas(ALL)/rule_hyouji_button/back hyouji");

        //Next = GameObject.Find("Canvas(ALL)/kirikae_I/next hyouji");
        //Back = GameObject.Find("Canvas(ALL)/kirikae_I/back hyouji");
        


    }

    void Start()
    {
        Destroy_Next();
        Destroy_Back();

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
    void Summon_Next()
    {
        Vector3 pos = parent.transform.localPosition;//クリックされたユニットの位置情報
        Next = parent.transform.Find("next hyouji").gameObject;
        Next.SetActive(true);
        Next.transform.position = new Vector3(pos.x + 160, -50, 0.0f);

        //button_hyouji1 = Instantiate(Next, new Vector3(pos.x+360, -10, 15.0f), Quaternion.identity,parent) as GameObject;
    }
    void Summon_Back()
    {
        Vector3 pos = parent.transform.localPosition;//クリックされたユニットの位置情報
        Back = parent.transform.Find("back hyouji").gameObject;
        Back.SetActive(true);
        Back.transform.position = new Vector3(pos.x+500, -50, 0.0f);
        
        //button_hyouji2 = Instantiate(Back, new Vector3(pos.x+300, -10, 15.0f), Quaternion.identity,parent) as GameObject;
    }

    void Destroy_Next()
    {
        GameObject[] click_next = GameObject.FindGameObjectsWithTag("Finish");

       // if (button_hyouji1.activeSelf)
        //{
            foreach (GameObject next_child in click_next)
            {
            //Destroy(next_child);
            next_child.SetActive(false);
            }
        //}


    }

    void Destroy_Back()
    {
        GameObject[] click_back = GameObject.FindGameObjectsWithTag("EditorOnly");

        //if (button_hyouji2.activeSelf)
        //{
            foreach (GameObject back_child in click_back)
            {
            //Destroy(back_child);
            back_child.SetActive(false);
            }
        //}

    }

    public void Gazou_wo_Kirikaeyo()
    {
       
        //Destroy_NB();

        Destroy_Next();
        Destroy_Back();

       // Next.SetActive(false);
        //Back.SetActive(false);

        img = image_num;

        Debug.Log("img_tag" + img);

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai = -1;
        
        test.sprite = summon_gazou[image_num];
        Debug.Log(image_num+"i");
       
        
        Debug.Log("SOUSU" + gazou_sousu);

        if(gazou_sousu>0)
        {
            Summon_Next();
            Destroy_Back();
            //Next.SetActive(true);
            //Back.SetActive(false);


        }
        else
        {
            Destroy_Next();
            Destroy_Back();
               // Next.SetActive(false);
                //Back.SetActive(false);
            
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
            
                Destroy_Next();
                Summon_Back();

                //Next.SetActive(false);
                //Back.SetActive(true);
            
        }
        else
        {
            
            Debug.Log("gazounannmai" + gazou_nanmai);
            test.sprite = next_gazou[gazou_nanmai];
            //Back.SetActive(true);
            Summon_Back();
        }
        

        
    }

    public void back_hyouji()
    {
        img = image_num;
        Debug.Log("img_tag" + img);

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai--;

        if (gazou_nanmai == -1)
        {

            gazou_nanmai = -1;
            Debug.Log("Gazouha0" + gazou_nanmai);
            test.sprite = summon_gazou[img];
            
                Destroy_Back();
                Summon_Next();
                //Back.SetActive(false);
                //Next.SetActive(true);
            
        }
        else
        {
            
            test.sprite = next_gazou[gazou_nanmai];
            Summon_Next();
            //Next.SetActive(true);
        }
        

        Debug.Log(gazou_nanmai);
    }

    
   

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
