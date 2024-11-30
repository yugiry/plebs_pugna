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
        if (Now_Hp == 0)
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
    }

    public void HitAttack(int hit)
    {
        CastleHitAudioSound.Play();
        Now_Hp -= hit;
        HP_TEXT.text = Now_Hp.ToString() + "/" + Max_Hp.ToString();
    }
}
