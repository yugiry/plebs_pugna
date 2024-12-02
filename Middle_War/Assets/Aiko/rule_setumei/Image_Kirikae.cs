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
    [SerializeField] GameObject Next1;
    [SerializeField] GameObject Back2;

    [SerializeField] GameObject Next;
    [SerializeField] GameObject Back;
    private GameObject button_hyouji1;
    private GameObject button_hyouji2;
    public Transform parent;

    button_color_change BCC;

    [SerializeField] GameObject Mekakusi;


    public AudioClip enter;
    private AudioSource audiosouse;
    //private void Awake()
    //{
    //    source = GetComponents<AudioSource>()[0];

    //}
    //public void PlayFootstepsSE()
    //{
    //    source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
    //    source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    //}

    void Start()
    {
        my_text = GameObject.Find("setumei").GetComponent<Text>();
        my_text.color = new Color(1.0f, 1.0f, 1.0f);


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
        Next.transform.position = new Vector3(pos.x + 160, -51, 0.0f);
        //Next = parent.transform.Find("next").gameObject;
        //button_hyouji1 = Instantiate(Next, new Vector3(pos.x+360, -10, 15.0f), Quaternion.identity,parent) as GameObject;
    }
    void Summon_Back()
    {
        Vector3 pos = parent.transform.localPosition;//クリックされたユニットの位置情報
        Back = parent.transform.Find("back hyouji").gameObject;
        Back.SetActive(true);
        Back.transform.position = new Vector3(pos.x+500, -51, 0.0f);
        //Back = parent.transform.Find("back").gameObject;
        //button_hyouji2 = Instantiate(Back, new Vector3(pos.x+300, -10, 15.0f), Quaternion.identity,parent) as GameObject;
        Debug.Log(pos.x);
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

    void Kakunou_Mekakusi()
    {
        GameObject[] _mekakusi = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject mekakusi_child in _mekakusi)
        {
            //Destroy(back_child);
            mekakusi_child.SetActive(false);
        }

    }

    void Yobidasi_Mekakusi()
    {
        Vector3 pos = parent.transform.localPosition;//クリックされたユニットの位置情報
        Mekakusi = parent.transform.Find("mekakusi_hontai").gameObject;
        Mekakusi.SetActive(true);
        //Mekakusi.transform.position = new Vector3(pos.x ,pos.y, 0.0f);
        //Back = parent.transform.Find("back").gameObject;
        //button_hyouji2 = Instantiate(Back, new Vector3(pos.x+300, -10, 15.0f), Quaternion.identity,parent) as GameObject;
    }

    public void Gazou_wo_Kirikaeyo()
    {
        audiosouse = this.gameObject.GetComponent<AudioSource>(); //オーディオソース取得

        audiosouse.PlayOneShot(enter);

        Text_Kakikae();

        Kakunou_Mekakusi();
        Yobidasi_Mekakusi();
        //Destroy_NB();

        Destroy_Next();
        Destroy_Back();

        // Next.SetActive(false);
        //Back.SetActive(false);

        text_num_num = 0;

        Debug.Log("img_tag" + img);

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai = 0;
        
        //test.sprite = summon_gazou[image_num];
        test.sprite = next_gazou[gazou_nanmai];
       
       
        
        Debug.Log("SOUSU" + gazou_sousu);

        if(gazou_sousu>1)
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

       

    }

    public void next_hyouji()
    {
        audiosouse.PlayOneShot(enter);

        text_num_num++;

        Text_Kakikae();

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
        audiosouse.PlayOneShot(enter);

        text_num_num--;

        if (text_num_num == 0)
        {
            text_num_num = 0;
        }

        Text_Kakikae();

        
        Debug.Log("img_tag" + img);

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai--;

        if (gazou_nanmai == 0)
        {

            gazou_nanmai = 0;
            Debug.Log("Gazouha0" + gazou_nanmai);
            test.sprite = next_gazou[gazou_nanmai];
            
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


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
