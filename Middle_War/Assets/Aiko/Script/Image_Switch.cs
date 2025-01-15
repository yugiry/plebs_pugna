using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Switch : MonoBehaviour
{
    public int text_num;
    private Text my_text;

    GameObject button;

    SpriteRenderer SR;

    [field: SerializeField] public int text_num_num { get; set; }
   
     [field: SerializeField]
    public int all_image
    { get; set; }
    
     [field: SerializeField]
    public int what_number_image
    {
        get; set;
    }

    public Sprite[] next_image;

    [SerializeField] GameObject Next;
    [SerializeField] GameObject Back;
    
    public Transform parent;

    button_color_change BCC;

    [SerializeField] GameObject Blind;

    public AudioClip enter;
    private AudioSource audiosouse;

    void Start()
    {
        my_text = GameObject.Find("explanation").GetComponent<Text>();//シーン内のtextオブジェクトを取得
        my_text.color = new Color(1.0f, 1.0f, 1.0f);

        Destroy_Next();//次へボタンを非表示
        Destroy_Back();//戻るボタンを非表示

    } 
    void Summon_Next()
    {
        Vector3 pos = parent.transform.localPosition;         //クリックされたボタンの位置情報
        Next = parent.transform.Find("Next_Core").gameObject; //親オブジェクトを取得
        Next.SetActive(true);                                 //次へボタンを表示
        Next.transform.position = new Vector3( 60, -51, 0.0f);//次へボタンの位置を変更

    }
    void Summon_Back()
    {
        Vector3 pos = parent.transform.localPosition;        //クリックされたボタンの位置情報
        Back = parent.transform.Find("Back_Core").gameObject;//親オブジェクトを取得
        Back.SetActive(true);                                //戻るボタンを表示
        Back.transform.position = new Vector3( 0, -51, 0.0f);//戻るボタンの位置を変更

    }
    
    void Destroy_Next()
    {
        GameObject[] click_next = GameObject.FindGameObjectsWithTag("Next");//Nextタグがついた全てのオブジェクトを取得

            foreach (GameObject next_child in click_next)
            {
            
            next_child.SetActive(false);                                   //Nextタグがついた全てのオブジェクトを非表示にする

            }       
        
    }

    void Destroy_Back()
    {
        GameObject[] click_back = GameObject.FindGameObjectsWithTag("Back");//Backタグがついた全てのオブジェクトを取得

        foreach (GameObject back_child in click_back)
            {
            
            back_child.SetActive(false);                                   //Backタグがついた全てのオブジェクトを非表示にする
        }
        
    }

    void Storage_Blind()
    {
        GameObject[] _blind = GameObject.FindGameObjectsWithTag("Blind");//Blindタグがついた全てのオブジェクトを取得

        foreach (GameObject blind_child in _blind)
        {
            
            blind_child.SetActive(false);                                   //Blindタグがついた全てのオブジェクトを非表示にする
        }

    }

    void Summon_Blind()
    {
        Vector3 pos = parent.transform.localPosition;//クリックされたユニットの位置情報
        Blind = parent.transform.Find("Blind_Core").gameObject;//親オブジェクトを取得
        Blind.SetActive(true);//オブジェクトを表示

    }

    public void Swith_Over_Image()
    {
        audiosouse = this.gameObject.GetComponent<AudioSource>(); //オーディオソース取得

        audiosouse.PlayOneShot(enter);//効果音を再生する
        text_num_num = 0;
        Text_Rewrite();//text内の文章を書き換える

       Storage_Blind();//オブジェクトを非表示
        Summon_Blind();//オブジェクトを表示
       
        Destroy_Next();//次へボタンを非表示
        Destroy_Back();//戻るボタンを非表示
      
        text_num_num = 0;

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//オブジェクトのスプライト情報を取得

        what_number_image = 0;
                
        SR.sprite = next_image[what_number_image];//数字に応じた画像を表示する

        if(all_image>1)//画像の総数が1より大きいなら
        {
            Summon_Next(); //次へボタンを表示
            Destroy_Back();//戻るボタンを非表示
        }
        else
        {
            Destroy_Next();//次へボタンを非表示
            Destroy_Back();//戻るボタンを非表示
        }

    }

    public void display_next()
    {
        audiosouse.PlayOneShot(enter);//効果音を再生する

        text_num_num++;//増やす

        Text_Rewrite();               //text内の文章を書き換える

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//オブジェクトのスプライト情報を取得

        what_number_image++;

        if (what_number_image == all_image - 1)//現在の画像番号が画像総数と同じ値ならば
        {
            what_number_image = all_image - 1;//その値に固定する
            
            
            SR.sprite = next_image[what_number_image];//数字＝画像総数-1に応じた画像を表示する

            Destroy_Next();//次へボタンを非表示
            Summon_Back();//戻るボタンを表示

        }
        else//そうでないなら＝画像総数と同値でないなら
        {
      
            SR.sprite = next_image[what_number_image];//現在の数字に応じた画像を表示する

            Summon_Back();//次へボタンを表示
        }
  
    }

    public void display_back()
    {
        audiosouse.PlayOneShot(enter);//効果音を再生する

        text_num_num--;//減らす

        if (text_num_num == 0)//テキスト番号が0なら
        {
            text_num_num = 0;//0のままにしておく
        }

        Text_Rewrite();//text内の文章を書き換える

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//オブジェクトのスプライト情報を取得

        what_number_image--;//減らす

        if (what_number_image == 0)//画像番号が0なら
        {

            what_number_image = 0;//0のままにする
           
            SR.sprite = next_image[what_number_image];//数字＝0に応じた画像を表示する

            Destroy_Back();//戻るボタンを非表示
            Summon_Next(); //次へボタンを表示

        }
        else//そうでない＝0以外なら
        {
            
            SR.sprite = next_image[what_number_image];//数字に応じた画像を表示する
            Summon_Next();//次へボタンを表示

        }

    }

    public void Text_Rewrite()//文章を書き換える
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
                        my_text.text = "\n移動させたいユニットを左クリックしてから、そのユニットの行きたい方向の上下左右1マスを左クリックすれば移動できる。\n";
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
                        my_text.text = "\n各ユニットの攻撃射程はユニットを左クリックすると確認できる。\n";
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
                        my_text.text = "\n敵の攻撃によって\n自軍の本陣のHPが0にされれば敗北となる。\n";
                        break;
                    default:
                        text_num_num = 0;
                        break;
                }
                break;
            case 6://フィールド情報
                switch (text_num_num) {
                    case 0:
                my_text.text = "\n草…どのユニットも特に障害なく移動することができる。\n森、深い水…全てのユニットが通ることができない場所。\n水…どのユニットでも通ることができるが移動時の消費AP量がそれぞれ1ずつ増える。\n";
                        break;
                    case 1:
                        my_text.text = "\n資材…カタパルトを召喚する為に必要なもの。\n歩兵でのみ回収が可能だが、回収後は一定ターンが経過するまで再回収できなくなる。\n";
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

}
