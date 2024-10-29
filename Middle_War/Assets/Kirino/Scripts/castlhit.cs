using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class castlhit : MonoBehaviour
{
    [SerializeField] Text hpText;

    int maxhp = 35;
    float nowhp = 35;

    public GameObject mainText;//image後で画像表示
    public Sprite gameOverSpr;
    public GameObject panel;
    public GameObject restartBotton;
    public GameObject nextBotton;

    //現在はテキスト　あとで画像に変更する
    Text titleText;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();

        //画像を非表示にする（現在テキスト表示中）
        Invoke("InactiveText", 1.0f);
        // ボタン、パネルを非表示にする
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //if (hpText.text = nowhp.ToString())
        //{
        //    // ゲームオーバー
        //    mainText.SetActive(true); //画像を表示する（現在テキストを表示中）
        //    panel.SetActive(true);    //ボタン（パネル）を表示する
        //    //NEXTボタンを無効化する
        //    Button bt = nextBotton.GetComponent<Button>();
        //    bt.interactable = false;
        //    mainText.GetComponent<Text>().sprite = gameOverSpr; //画像を設定する
        //    //castleController.gameState = "gameend";
        //}
        //else if (castleController.gameState == "playing")
        //{
        //    //ゲーム中
        //}

    }
    // 画像を非表示にする
    void InactiveText()
    {
        mainText.SetActive(false);
    }
}