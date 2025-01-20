using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Switch : MonoBehaviour
{
    public int Text_Num;
    private Text My_Text;

    SpriteRenderer SR;

    [field: SerializeField] public int Text_Num_Num { get; set; }
   
     [field: SerializeField]
    public int Total_Image
    { get; set; }
    
     [field: SerializeField]
    public int What_Num_Image
    {
        get; set;
    }

    public Sprite[] Next_Image;

    [SerializeField] GameObject Next;
    [SerializeField] GameObject Back;
    
    public Transform parent;

    [SerializeField] GameObject Blind;

    public AudioClip Enter;//カーソルが乗ったときに鳴らす音
    public AudioClip Push;//マウスを押したときに鳴らす音
    private AudioSource AudioSource;

    private Color DarkGray = new Color(0.3f, 0.3f, 0.3f);

    private enum Rule_Number
    {
        Summon,
        Move,
        Harvest,
        Attack,
        Victory,
        Lose,
        Field,
        Unit_Information,
    };

    private enum Text_Number
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
    }

    //スタート関数
    //説明
    void Start()
    {
        My_Text = GameObject.Find("explanation").GetComponent<Text>();//シーン内のtextオブジェクトを取得
        

        Destroy_Next();//次へボタンを非表示
        Destroy_Back();//戻るボタンを非表示

    } 
    void Summon_Next()
    {
        Next = parent.transform.Find("Next_Core").gameObject; //親オブジェクトを取得
        Next.SetActive(true);                                 //次へボタンを表示
        Next.transform.position = new Vector3( 60, -51, 0.0f);//次へボタンの位置を変更

    }
    void Summon_Back()
    {
        Back = parent.transform.Find("Back_Core").gameObject;//親オブジェクトを取得
        Back.SetActive(true);                                //戻るボタンを表示
        Back.transform.position = new Vector3( 0, -51, 0.0f);//戻るボタンの位置を変更

    }
    
    void Destroy_Next()
    {
        GameObject[] Click_Next = GameObject.FindGameObjectsWithTag("Next");//Nextタグがついた全てのオブジェクトを取得

        foreach (GameObject Next_Child in Click_Next)
        {
            Next_Child.SetActive(false);  //Nextタグがついた全てのオブジェクトを非表示にする
        }       
        
    }

    void Destroy_Back()
    {
        GameObject[] Click_Back = GameObject.FindGameObjectsWithTag("Back");//Backタグがついた全てのオブジェクトを取得

        foreach (GameObject Back_Child in Click_Back)
        {    
            Back_Child.SetActive(false); //Backタグがついた全てのオブジェクトを非表示にする
        }
        
    }

    

    void Storage_Blind()
    {
        GameObject[] _blind = GameObject.FindGameObjectsWithTag("Blind");//Blindタグがついた全てのオブジェクトを取得

        foreach (GameObject blind_child in _blind)
        {
            //Blindタグがついた全てのオブジェクトを非表示にする
            blind_child.GetComponent<Renderer>().material.color = Color.white;
            
        }

    }
    
    void Summon_Blind()
    {
        this.GetComponent<Renderer>().material.color = DarkGray;
    }

    public void Swith_Over_Image()
    {
        AudioSource = this.gameObject.GetComponent<AudioSource>(); //オーディオソース取得

        AudioSource.PlayOneShot(Push);//効果音を再生する
        Text_Num_Num = 0;
        Text_Rewrite();//text内の文章を書き換える

       Storage_Blind();//オブジェクトを非表示
        Summon_Blind();//オブジェクトを表示
       
        Destroy_Next();//次へボタンを非表示
        Destroy_Back();//戻るボタンを非表示

        Text_Num_Num = 0;

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//オブジェクトのスプライト情報を取得

        What_Num_Image = 0;
                
        SR.sprite = Next_Image[What_Num_Image];//数字に応じた画像を表示する

        if(Total_Image > 1)//画像の総数が1より大きいなら
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
        AudioSource.PlayOneShot(Push);//効果音を再生する

        Text_Num_Num++;//増やす

        Text_Rewrite();               //text内の文章を書き換える

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//オブジェクトのスプライト情報を取得

        What_Num_Image++;

        if (What_Num_Image == Total_Image - 1)//現在の画像番号が画像総数と同じ値ならば
        {
            What_Num_Image = Total_Image - 1;//その値に固定する
            
            
            SR.sprite = Next_Image[What_Num_Image];//数字＝画像総数-1に応じた画像を表示する

            Destroy_Next();//次へボタンを非表示
            Summon_Back();//戻るボタンを表示

        }
        else//そうでないなら＝画像総数と同値でないなら
        {
      
            SR.sprite = Next_Image[What_Num_Image];//現在の数字に応じた画像を表示する

            Summon_Back();//次へボタンを表示
        }
  
    }

    public void display_back()
    {
        AudioSource.PlayOneShot(Push);//効果音を再生する

        Text_Num_Num--;//減らす

        if (Text_Num_Num == 0)//テキスト番号が0なら
        {
            Text_Num_Num = 0;//0のままにしておく
        }

        Text_Rewrite();//text内の文章を書き換える

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//オブジェクトのスプライト情報を取得

        What_Num_Image--;//減らす

        if (What_Num_Image == 0)//画像番号が0なら
        {

            What_Num_Image = 0;//0のままにする
           
            SR.sprite = Next_Image[What_Num_Image];//数字＝0に応じた画像を表示する

            Destroy_Back();//戻るボタンを非表示
            Summon_Next(); //次へボタンを表示

        }
        else//そうでない＝0以外なら
        {
            
            SR.sprite = Next_Image[What_Num_Image];//数字に応じた画像を表示する
            Summon_Next();//次へボタンを表示

        }

    }

    public void Text_Rewrite()//文章を書き換える
    {
        switch (Text_Num)
        {
            case (int)Rule_Number.Summon://召喚
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\nUI画面にあるユニットを左クリックしてから自分の陣地を左クリックすると召喚できる。\nただし、召喚に必要なAPまたは資源が足りないと召喚できない。";
                        break;
                    case (int)Text_Number.One:
                        My_Text.text = "\nUI画面にあるユニットを左クリックしてから自分の陣地を左クリックすると召喚できる。\nただし、召喚に必要なAPまたは資源が足りないと召喚できない。";
                        break;
                    default:
                        Text_Num_Num = 1;
                        break;
                }
                break;

            case (int)Rule_Number.Move://移動
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n移動させたいユニットを左クリックしてから、そのユニットの行きたい方向の上下左右1マスを左クリックすれば移動できる。\n";
                        break;
                    default:
                        Text_Num_Num = 0;
                        break;
                }
                break;
            case (int)Rule_Number.Harvest://採取
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\nフィールドマップ上にある資材まで'歩兵'を移動させてから資材を左クリックすることで回収ができる。\n";
                        break;
                    default:
                        Text_Num_Num = 0;
                        break;
                }
                break;
            case (int)Rule_Number.Attack://攻撃
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n攻撃させたいユニットを左クリックして、攻撃したいユニットを左クリックすれば攻撃する事ができる。\n";
                        break;
                    case (int)Text_Number.One:
                        My_Text.text = "\n各ユニットの攻撃射程はユニットを左クリックすると確認できる。\n";
                        break;
                    default:
                        Text_Num_Num = 1;
                        break;
                }
                break;
            case (int)Rule_Number.Victory://勝利条件
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n自軍が敵の本陣のHPを0にすれば勝利となる。\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nがんばれ！\n";
                break;
                    default:
                        Text_Num_Num = 0;
                        break;
                }
                break;
            case (int)Rule_Number.Lose://敗北条件
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n敵の攻撃によって\n自軍の本陣のHPが0にされれば敗北となる。\n";
                        break;
                    default:
                        Text_Num_Num = 0;
                        break;
                }
                break;
            case (int)Rule_Number.Field://フィールド情報
                switch (Text_Num_Num) {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n草…どのユニットも特に障害なく移動することができる\n\n水…どのユニットでも通ることができるが移動時の消費AP量がそれぞれ1ずつ増える。\n";
                        break;
                    case (int)Text_Number.One:
                        My_Text.text = "\n森、深い水…全てのユニットが通ることができない場所\n";
                        break;
                    case (int)Text_Number.Two:
                        My_Text.text = "\n資材…カタパルトを召喚する為に必要なもの。\n歩兵でのみ回収が可能だが、回収後は一定ターンが経過するまで再回収できなくなる。\n";
                        break;
                    default:
                        Text_Num_Num = 2;
                        break;
                }
                break;
            case (int)Rule_Number.Unit_Information://ユニット情報
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n歩兵…近接攻撃しかできないが召喚に必要なAPが少なく資材を回収する事ができる唯一の兵士。\n";
                        break;
                    case (int)Text_Number.One:
                        My_Text.text = "\n歩兵…近接攻撃しかできないが召喚に必要なAPが少なく資材を回収する事ができる唯一の兵士。\n";
                        break;
                    case (int)Text_Number.Two:
                        My_Text.text = "\n弓兵…遠距離攻撃が可能な兵士。体力が低く召喚に必要なAPも多い。\n";
                        break;
                    case (int)Text_Number.Three:
                        My_Text.text = "\n弓兵…遠距離攻撃が可能な兵士。体力が低く召喚に必要なAPも多い。\n";
                        break;
                    case (int)Text_Number.Four:
                        My_Text.text = "\nカタパルト…長距離攻撃が可能な攻城兵器。攻撃力が高いが召喚コストも移動に使用するAP量も多く周囲1マスまで近寄られると何もできなくなる弱点がある。\n";
                        break;
                    case (int)Text_Number.Five:
                        My_Text.text = "\nカタパルト…長距離攻撃が可能な攻城兵器。攻撃力が高いが召喚コストも移動に使用するAP量も多く周囲1マスまで近寄られると何もできなくなる弱点がある。\n";
                        break;
                    default:
                        Text_Num_Num = 5;
                        break;
                }
                  break;
        }
    }

    public void OnMouseEnter()
    {
        //ボタンにマウスカーソルが乗ったとき

        if (this.GetComponent<Renderer>().material.color ==Color.white)
        {
            this.GetComponent<Renderer>().material.color = Color.gray;
        }

        AudioSource = this.gameObject.GetComponent<AudioSource>(); //オーディオソース取得

        AudioSource.PlayOneShot(Enter);//効果音を再生する

    }
    public void OnMouseExit()
    {
        //ボタンに乗ったマウスカーソルが離れたとき
       
        if (this.GetComponent<Renderer>().material.color == DarkGray)
        {
            this.GetComponent<Renderer>().material.color = DarkGray;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = Color.white;
        }

    }

   

}
