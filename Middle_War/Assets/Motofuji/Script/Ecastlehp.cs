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
    }

    public void HitAttack(int hit)
    {
        CastleHitAudioSound.Play();
        Now_Hp -= hit;
        if (Now_Hp < 0) Now_Hp = 0;
        HP_TEXT.text = Now_Hp.ToString() + "/" + Max_Hp.ToString();
    }
}
