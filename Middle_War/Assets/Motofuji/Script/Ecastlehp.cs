using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ecastlehp : MonoBehaviour
{
    [SerializeField] Text HP_TEXT;
    int Max_Hp;
    int Now_Hp;

    public GameObject mainText;//image後で画像表示
    public GameObject panel;
    public GameObject restartBotton;
    public AudioSource CastleHitAudioSound;

    GameObject country_num;
    remenber_country_num RCN;
    GameObject remenber_falg;
    clear_flag_operation CFO;

    //城の差分を変えるエリア
    SpriteRenderer SR;
    [SerializeField] Sprite[] enemy_castle_image;

    // Start is called before the first frame update
    void Start()
    {
        //城のHPを初期化
        Max_Hp = 35;
        Now_Hp = 35;
        HP_TEXT.text = Now_Hp.ToString() + "/" + Max_Hp.ToString();
        country_num = GameObject.Find("country_info");
        RCN = country_num.GetComponent<remenber_country_num>();
        remenber_falg = GameObject.Find("remenber_clear_flag");
        CFO = remenber_falg.GetComponent<clear_flag_operation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Now_Hp <= 0)
        {
            Debug.Log("Game Clear!");
            CFO.clear_flag[RCN.country_num - 1] = true;
            // ここにゲームオーバー時の処理を追加（例：シーンのリセットやメニュー画面の表示など）
            mainText.SetActive(true); //画像を表示する（現在テキストを表示中）
            panel.SetActive(true);    //ボタン（パネル）を表示する
                                      //NEXTボタンを無効化する
            Button bt = restartBotton.GetComponent<Button>();
            bt.interactable = false;
            //mainText.GetComponent<Text>().sprite = gameOverSpr; //画像を設定する
        }

        if (SR == null)
        {

            SR = GameObject.Find("castle2(Clone)").GetComponent<SpriteRenderer>();//オブジェクトのスプライト情報を取得
                                                                                  //SR.sprite = enemy_castle_image[2];

        }


        Debug.Log("検索終了");

        switch(Now_Hp/7)
        {
            case 0:
                SR.sprite = enemy_castle_image[3];
                break;
            case 1:
                SR.sprite = enemy_castle_image[3];
                break;
            case 2:
                SR.sprite = enemy_castle_image[2];
                break;
            case 3:
                SR.sprite = enemy_castle_image[1];
                break;
            case 4:
                SR.sprite = enemy_castle_image[0];
                break;
            default:
                SR.sprite = enemy_castle_image[0];
                break;

        }
        if(Now_Hp==0)
        {
            SR.sprite = enemy_castle_image[4];
        }
        

    }

    public void HitAttack(int hit)
    {
        CastleHitAudioSound.Play();
        Now_Hp -= hit;
        if (Now_Hp < 0) Now_Hp = 0;
        HP_TEXT.text = Now_Hp.ToString() + "/" + Max_Hp.ToString();
    }
}
