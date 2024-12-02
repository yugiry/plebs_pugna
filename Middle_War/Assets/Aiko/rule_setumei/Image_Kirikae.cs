using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Kirikae : MonoBehaviour
{
    public int text_num;
    private Text my_text;

    GameObject button;

    
    //public int mode_change;

    SpriteRenderer test;

    //public Sprite[] summon_gazou;

    [SerializeField] AudioClip[] clips;
    [SerializeField] float pitchRange = 0.1f;
    protected AudioSource source;

    


    /*[SerializeField]*/
    [field: SerializeField] public int text_num_num { get; set; }
   
    

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
    private GameObject button_hyouji1;
    private GameObject button_hyouji2;
    public Transform parent;

    button_color_change BCC;

    [SerializeField] GameObject Mekakusi;


    public AudioClip enter;
    private AudioSource audiosouse;


    

    void Start()
    {
        my_text = GameObject.Find("setumei").GetComponent<Text>();
        my_text.color = new Color(1.0f, 1.0f, 1.0f);

        
        Destroy_Next();
        Destroy_Back();


       
    }

    
    
    void Summon_Next()
    {
        Vector3 pos = parent.transform.localPosition;//クリックされたユニットの位置情報
        Next = parent.transform.Find("Next_Core").gameObject;
        Next.SetActive(true);
        Next.transform.position = new Vector3( 60, -51, 0.0f);

       

    }
    void Summon_Back()
    {
        Vector3 pos = parent.transform.localPosition;//クリックされたユニットの位置情報
        Back = parent.transform.Find("Back_Core").gameObject;
        Back.SetActive(true);
        Back.transform.position = new Vector3( 0, -51, 0.0f);
       
        
    }
    
    void Destroy_Next()
    {
        GameObject[] click_next = GameObject.FindGameObjectsWithTag("Next");

      
            foreach (GameObject next_child in click_next)
            {
            
            next_child.SetActive(false);
            }
       
        
    }

    void Destroy_Back()
    {
        GameObject[] click_back = GameObject.FindGameObjectsWithTag("Back");

            foreach (GameObject back_child in click_back)
            {
            
            back_child.SetActive(false);
            }
       
        
    }

    void Kakunou_Mekakusi()
    {
        GameObject[] _mekakusi = GameObject.FindGameObjectsWithTag("Blind");

        foreach (GameObject mekakusi_child in _mekakusi)
        {
            
            mekakusi_child.SetActive(false);
        }

    }

    void Yobidasi_Mekakusi()
    {
        Vector3 pos = parent.transform.localPosition;//クリックされたユニットの位置情報
        Mekakusi = parent.transform.Find("Blind_Core").gameObject;
        Mekakusi.SetActive(true);
        
    }

    public void Gazou_wo_Kirikaeyo()
    {
        audiosouse = this.gameObject.GetComponent<AudioSource>(); //オーディオソース取得

        audiosouse.PlayOneShot(enter);
        text_num_num = 0;
        Text_Kakikae();

        Kakunou_Mekakusi();
        Yobidasi_Mekakusi();
       

        Destroy_Next();
        Destroy_Back();

      

        text_num_num = 0;

        

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai = 0;
        
        
        test.sprite = next_gazou[gazou_nanmai];
       
       
        
       

        if(gazou_sousu>1)
        {
            Summon_Next();
            Destroy_Back();
            


        }
        else
        {
            Destroy_Next();
            Destroy_Back();
               
            
        }

       

    }

    public void next_hyouji()
    {
        audiosouse.PlayOneShot(enter);

        text_num_num++;

        Text_Kakikae();

        

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai++;

        if (gazou_nanmai == gazou_sousu-1)
        {
            gazou_nanmai = gazou_sousu-1;
            
            
            test.sprite = next_gazou[gazou_nanmai];
            
                Destroy_Next();
                Summon_Back();

               
            
        }
        else
        {
            
            
            test.sprite = next_gazou[gazou_nanmai];
            //Back.SetActive(true);
            Summon_Back();
        }
        

        
    }

    public void back_hyouji()
    {
        audiosouse.PlayOneShot(enter);

        text_num_num--;

        if (text_num_num == 0)
        {
            text_num_num = 0;
        }

        Text_Kakikae();

        
       

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai--;

        if (gazou_nanmai == 0)
        {

            gazou_nanmai = 0;
           
            test.sprite = next_gazou[gazou_nanmai];
            
                Destroy_Back();
                Summon_Next();
               
            
        }
        else
        {
            
            test.sprite = next_gazou[gazou_nanmai];
            Summon_Next();
            
        }
        

        Debug.Log(gazou_nanmai);
    }

    public void Text_Kakikae()
    {
        switch (text_num)
        {
            case 0://召喚
                switch (text_num_num)
                {
                    case 0:
                        my_text.text = "\nUI画面にあるユニットを左クリックしてから自分の陣地を左クリックすると召喚できる。\nただし、召喚に必要なAPまたは資源が足りないと召喚できない。";
                        break;
                    case 1:
                        my_text.text = "\nUI画面にあるユニットを左クリックしてから自分の陣地を左クリックすると召喚できる。\nただし、召喚に必要なAPまたは資源が足りないと召喚できない。";
                        break;
                    default:
                        text_num_num = 1;
                        break;
                }
                break;

            case 1://移動
                switch (text_num_num)
                {
                    case 0:
                        my_text.text = "\n移動させたいユニットを左クリックしてから行きたいマスを左クリックすれば移動できる。\n";
                        break;
                    default:
                        text_num_num = 0;
                        break;
                }
                break;
            case 2://採取
                switch (text_num_num)
                {
                    case 0:
                        my_text.text = "\nフィールドマップ上にある資材まで'歩兵'を移動させてから資材を左クリックすることで回収ができる。\n";
                        break;
                    default:
                        text_num_num = 0;
                        break;
                }
                break;
            case 3://攻撃
                switch (text_num_num)
                {
                    case 0:
                my_text.text = "\n攻撃させたいユニットを左クリックして、攻撃したいユニットを左クリックすれば攻撃する事ができる。\n";
                        break;
                    case 1:
                        my_text.text = "\n各ユニットの攻撃射程はユニットを左クリックしてからマウスホイールでクリックすると確認できる。\n";
                        break;
                    default:
                        text_num_num = 1;
                        break;
                }
                break;
            case 4://勝利条件
                switch (text_num_num)
                {
                    case 0:
                my_text.text = "\n自軍が敵の本陣のHPを0にすれば勝利となる。\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nがんばれ！\n";
                break;
                    default:
                        text_num_num = 0;
                        break;
                }
                break;
            case 5://敗北条件
                switch (text_num_num)
                {
                    case 0:
                        my_text.text = "\n敵軍によって自軍の本陣のHPが0にされれば敗北となる。\n";
                        break;
                    default:
                        text_num_num = 0;
                        break;
                }
                break;
            case 6://フィールド情報
                switch (text_num_num) {
                    case 0:
                my_text.text = "\n草…どのユニットも特に障害なく移動することができる。\n川…どのユニットでも通ることができるが移動時の消費AP量がそれぞれ1ずつ増える。\n森…どんなユニットも通ることができない場所。\n";
                        break;
                    case 1:
                        my_text.text = "\n資材…カタパルトを召喚する為に必要なもの。歩兵で回収が可能。\n回収後は一定ターンが経過するまで再回収できなくなる。\n";
                        break;
                    default:
                        text_num_num = 1;
                        break;
                }
                break;
            case 7://ユニット情報
                switch (text_num_num)
                {
                    case 0:
                        my_text.text = "\n歩兵…近接攻撃しかできないが召喚に必要なAPが少なく資材を回収する事ができる唯一の兵士。\n";
                        break;
                    case 1:
                        my_text.text = "\n歩兵…近接攻撃しかできないが召喚に必要なAPが少なく資材を回収する事ができる唯一の兵士。\n";
                        break;
                    case 2:
                        my_text.text = "弓兵…遠距離攻撃が可能な兵士。体力が低く召喚に必要なAPも多い。\n";
                        break;
                    case 3:
                        my_text.text = "弓兵…遠距離攻撃が可能な兵士。体力が低く召喚に必要なAPも多い。\n";
                        break;
                    case 4:
                        my_text.text = "カタパルト…長距離攻撃が可能な攻城兵器。攻撃力が高いが召喚コストも移動に使用するAP量も多く周囲1マスまで近寄られると何もできなくなる弱点がある。\n";
                        break;
                    case 5:
                        my_text.text = "カタパルト…長距離攻撃が可能な攻城兵器。攻撃力が高いが召喚コストも移動に使用するAP量も多く周囲1マスまで近寄られると何もできなくなる弱点がある。\n";
                        break;
                    default:
                        text_num_num = 5;
                        break;
                }
                              break;


        }


    }

    public void OnMouseEnter()
    {
        this.GetComponent<Renderer>().material.color = new Color(0.7f, 0.7f, 0.7f, 1.0f);
      
    }
    public void OnMouseExit()
    {
  
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);


    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
