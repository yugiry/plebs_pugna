using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clearover : MonoBehaviour
{
    public GameObject mainText;//image後で画像表示
    public Sprite gameOverSpr;
    public Sprite gameClearSpr;
    public GameObject panel;
    public GameObject restartBotton;
    public GameObject nextBotton;
    //現在はテキスト　あとで画像に変更する
    Text titleText;

    // Start is called before the first frame update
    void Start()
    {
        //画像を非表示にする（現在テキスト表示中）
        Invoke("InactiveText", 1.0f);
        // ボタン、パネルを非表示にする
        panel.SetActive(false);
    }

    // 画像を非表示にする
    void InactiveText()
    {
        mainText.SetActive(false);
    }
}
