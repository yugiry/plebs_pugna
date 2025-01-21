using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pcastlehp : MonoBehaviour
{
    [SerializeField] Text HP_TEXT;
    int Max_Hp;
    int Now_Hp;
    public GameObject mainText;//image後で画像表示
    public GameObject panel;
    public GameObject nextBotton;

    public AudioSource CastleHitAudioSound;

    //城の差分を変えるエリア
    SpriteRenderer SR;
    [SerializeField] Sprite[] player_castle_image;

    // Start is called before the first frame update
    void Start()
    {
        Max_Hp = 35;
        Now_Hp = 35;
        HP_TEXT.text = Now_Hp.ToString() + "/" + Max_Hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Now_Hp <= 0)
        {
            Debug.Log("Game Over!");
            // ここにゲームオーバー時の処理を追加（例：シーンのリセットやメニュー画面の表示など）
            mainText.SetActive(true); //画像を表示する（現在テキストを表示中）
            panel.SetActive(true);    //ボタン（パネル）を表示する
                                      //NEXTボタンを無効化する
            Button bt = nextBotton.GetComponent<Button>();
            bt.interactable = false;
            //mainText.GetComponent<Text>().sprite = gameOverSpr; //画像を設定する
        }

        if (SR == null)
        {

            SR = GameObject.Find("castle1(Clone)").GetComponent<SpriteRenderer>();//オブジェクトのスプライト情報を取得
                                                                                  //SR.sprite = enemy_castle_image[2];
        }


        Debug.Log("検索終了");

        switch (Now_Hp / 7)
        {
            case 0:
                SR.sprite = player_castle_image[4];
                break;
            case 1:
                SR.sprite = player_castle_image[3];
                break;
            case 2:
                SR.sprite = player_castle_image[2];
                break;
            case 3:
                SR.sprite = player_castle_image[1];
                break;
            case 4:
                SR.sprite = player_castle_image[0];
                break;
            default:
                SR.sprite = player_castle_image[0];
                break;

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
