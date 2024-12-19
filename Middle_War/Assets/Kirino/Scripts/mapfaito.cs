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
    public int countrynum;//ゲームオブジェクト・関数宣言
    public GameObject mapbatoru;
    [SerializeField] public Text text1;//１つ目のテキスト変換
    [SerializeField] public Text text2;//２つ目のテキスト変換
    public Image image; //画像表示
    public GameObject Button;//敵とのバトルボタン
    public Sprite[] newSprite;//画像表示追加
    public string NextScene;
    GameObject rcnobj;
    remenber_country_num RCN;

    private void Awake()
    {
        rcnobj = GameObject.Find("country_info");
        RCN = rcnobj.GetComponent<remenber_country_num>();
    }
   
    public void Show_country(int countrynum)
    { //mapClickから受け取った値を読み取る

        image.sprite = newSprite[countrynum - 1]; //画像表示

        switch (countrynum) //受け取った値別処理
        {
            case 1:
                text1.text = "自国"; //国名
                text2.text = "どんどん敵国を攻め領土を拡張して天下統一を目指そう！！"; //国説明
                Button.SetActive(false); //ボタン表示（自国はボタン表示しない）
                mapbatoru.transform.position = new Vector3(0, 0, 50); //国情報ボード表示位置
                RCN.country_num = countrynum;
                break;
            case 2:
                text1.text = "フスラン"; //国名
                text2.text = "できたばかりの国で国王の権力が低く攻め入りやすい！"; //国説明            
                Button.SetActive(true); //敵国はボタン表示する
                mapbatoru.transform.position = new Vector3(0, 0, 50); //国情報ボード表示位置
                RCN.country_num = countrynum;
                break;
            case 3:
                text1.text = "ア・タイリ"; //国名
                text2.text = "できたばかりではないが国民のまとまりがなくあまり発展していない！"; //国説明             
                Button.SetActive(true); //敵国はボタン表示する
                mapbatoru.transform.position = new Vector3(0, 0, 50); //国情報ボード表示位置
                RCN.country_num = countrynum;
                break;
            case 4:
                text1.text = "アイべり半島"; //国名
                text2.text = "少し発展しており徐々に宗教が広まっている!!（宗教名ligare）"; //国説明          
                Button.SetActive(true); //敵国はボタン表示する
                mapbatoru.transform.position = new Vector3(0, 0, 50); //国情報ボード表示位置
                RCN.country_num = countrynum;
                break;
            case 5:
                text1.text = "アベチネ";
                text2.text = "国自体は狭いが漁業が盛んでいろんな国と取引している。";
                Button.SetActive(true); //敵国はボタン表示する
                mapbatoru.transform.position = new Vector3(0, 0, 50); //国情報ボード表示位置
                RCN.country_num = countrynum;
                break;
            case 6:
                text1.text = "ナクウイラ";
                text2.text = "どの国からも狙われやすいが、攻めずらい。";
                Button.SetActive(true); //敵国はボタン表示する
                mapbatoru.transform.position = new Vector3(0, 0, 50); //国情報ボード表示位置
                RCN.country_num = countrynum;
                break;
            case 7:
                text1.text = "アブリガル";
                text2.text = "アイべり半島と対立しており少しずつリガル教が進行している。";
                Button.SetActive(true); //敵国はボタン表示する
                mapbatoru.transform.position = new Vector3(0, 0, 50); //国情報ボード表示位置
                RCN.country_num = countrynum;
                break;
            default:
                Debug.Log("Default"); //switch処理の最後
                break;
        }
    }

    public void change_button()//ボタン変更
    {
        SceneManager.LoadScene(NextScene);//ボタンが押された時シーンを変える
    }
}