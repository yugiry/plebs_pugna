using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Switch : MonoBehaviour
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
    public int all_image
    { get; set; }
    

    /*[SerializeField]*/
     [field: SerializeField]
    public int what_number_image
    {
        get; set;
    }

    //GameObject Next;
    //GameObject Back;

    public Sprite[] next_image;
   

    [SerializeField] GameObject Next;
    [SerializeField] GameObject Back;
    private GameObject button_hyouji1;
    private GameObject button_hyouji2;
    public Transform parent;

    button_color_change BCC;

    [SerializeField] GameObject Blind;


    public AudioClip enter;
    private AudioSource audiosouse;


    

    void Start()
    {
        my_text = GameObject.Find("explanation").GetComponent<Text>();
        my_text.color = new Color(1.0f, 1.0f, 1.0f);

        
        Destroy_Next();
        Destroy_Back();


       
    }

    
    
    void Summon_Next()
    {
        Vector3 pos = parent.transform.localPosition;//クリックされたボタンの位置情報
        Next = parent.transform.Find("Next_Core").gameObject;
        Next.SetActive(true);
        Next.transform.position = new Vector3( 60, -51, 0.0f);

       

    }
    void Summon_Back()
    {
        Vector3 pos = parent.transform.localPosition;//クリックされたボタンの位置情報
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

    void Storage_Blind()
    {
        GameObject[] _mekakusi = GameObject.FindGameObjectsWithTag("Blind");

        foreach (GameObject mekakusi_child in _mekakusi)
        {
            
            mekakusi_child.SetActive(false);
        }

    }

    void Summon_Blind()
    {
        Vector3 pos = parent.transform.localPosition;//クリックされたユニットの位置情報
        Blind = parent.transform.Find("Blind_Core").gameObject;
        Blind.SetActive(true);
        
    }

    public void Swith_Over_Image()
    {
        audiosouse = this.gameObject.GetComponent<AudioSource>(); //オーディオソース取得

        audiosouse.PlayOneShot(enter);
        text_num_num = 0;
        Text_Rewrite();

       Storage_Blind();
        Summon_Blind();
       

        Destroy_Next();
        Destroy_Back();

      

        text_num_num = 0;

        

        test = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();

        what_number_image = 0;
        
        
        test.sprite = next_image[what_number_image];
       
       
        
       

        if(all_image>1)
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

    public void display_next()
    {
        audiosouse.PlayOneShot(enter);

        text_num_num++;

        Text_Rewrite();

        

        test = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();

        what_number_image++;

        if (what_number_image == all_image - 1)
        {
            what_number_image = all_image - 1;
            
            
            test.sprite = next_image[what_number_image];
            
                Destroy_Next();
                Summon_Back();

               
            
        }
        else
        {
            
            
            test.sprite = next_image[what_number_image];
            //Back.SetActive(true);
            Summon_Back();
        }
        

        
    }

    public void display_back()
    {
        audiosouse.PlayOneShot(enter);

        text_num_num--;

        if (text_num_num == 0)
        {
            text_num_num = 0;
        }

        Text_Rewrite();

        
       

        test = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();

        what_number_image--;

        if (what_number_image == 0)
        {

            what_number_image = 0;
           
            test.sprite = next_image[what_number_image];
            
                Destroy_Back();
                Summon_Next();
               
            
        }
        else
        {
            
            test.sprite = next_image[what_number_image];
            Summon_Next();
            
        }
        

        Debug.Log(what_number_image);
    }

    public void Text_Rewrite()
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
        //ボタンにマウスカーソルが乗ったとき
        this.GetComponent<Renderer>().material.color = new Color(0.7f, 0.7f, 0.7f, 1.0f);
      
    }
    public void OnMouseExit()
    {
        //ボタンに乗ったマウスカーソルが離れたとき
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);


    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
