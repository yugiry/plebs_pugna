using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(AudioSource))]
public class mapfaito : MonoBehaviour
{
    public GameObject Map_Batoru;

    [SerializeField] public Text[] text;//テキスト変換

    public Image image; //画像表示
    public GameObject Button;//敵とのバトルボタン
    public Sprite[] newSprite;//画像表示で新しくマップを追加した時でも簡単に表示できる。
    public string NextScene;//変数を文字に変えることでどこでもシーンの名前を変更すればすぐに違うシーンに移動できる。

    //RCNの空OBJECT
    GameObject RCNobj;

    //remenber_country_num 訳 = RCN 
    //別スクリプト
    remenber_country_num RCN;

    //呼び出し関数
    //説明　　startよりも先にAwaekが呼ばれ非アクティブ状態にしていてもAwakeメソッドは呼ばれる
    //ゲーム(敵とのバトルが終わった時)
    private void Awake()
    {
        RCNobj = GameObject.Find("country_info");
        RCN = RCNobj.GetComponent<remenber_country_num>();
    }

    //mapClickから受け取った値を読み取る
    public void Country_Num(int Country_Num)
    { 
        image.sprite = newSprite[Country_Num - 1]; //画像表示

        RCN.country_num = Country_Num;

        Button.SetActive(true); //敵国はボタン表示する

        switch (Country_Num) //受け取った値別テキスト処理
        {
            case 1:
                text[0].text = NameMneger.name+"の国"; //国名
                text[1].text = "どんどん敵国を攻め\n領土を拡張し\n天下統一を目指そう！"; //国説明
                Button.SetActive(false); //ボタン表示（自国はボタン表示しない）
                break;
            case 2:
                text[0].text = "フスラン"; //国名
                text[1].text = "できたばかりの国で\n国王の権力が弱く\n攻め入りやすい"; //国説明
                break;
            case 3:
                text[0].text = "ア・タイリ"; //国名
                text[1].text = "少し前にできた国だが\n国民のまとまりがなく\nあまり発展していない"; //国説明        
                break;
            case 4:
                text[0].text = "アイべり半島"; //国名
                text[1].text = "少し発展しており\n徐々に宗教が広まり\n国民のまとまりがある"; //国説明     
                break;
            case 5:
                text[0].text = "アベチネ"; //国名
                text[1].text = "国自体は狭いが漁業が\n盛んでいろんな国と\n取引している"; //国説明
                break;
            case 6:
                text[0].text = "ナクウイラ"; //国名
                text[1].text = "他国に狙われやすいが\n地形が入り組んでいて\n攻めずらい国"; //国説明
                break;
            case 7:
                text[0].text = "アブリガル"; //国名
                text[1].text = "アイベリ半島と対立\nしており宗教が徐々に\n進行してきている"; //国説明
                break;
            default:
                Debug.Log("Default"); //switch処理確認用ログ
                break;
        }
    }
    public void Change_Button()//ボタン変更
    {
        SceneManager.LoadScene(NextScene);//ボタンが押された時シーンを変える
    }
}