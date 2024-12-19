using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class castlhit : MonoBehaviour
{
    //ゲームオブジェクト名宣言・関数宣言
    public int maxHealth = 35;  // 最大HP
    private int currentHealth = 35;  // 現在のHP
    public Text healthText;  // HP表示用のテキスト(UI)

    public GameObject mainText;//image後で画像表示
    public Sprite gameOverSpr;
    public GameObject panel;
    public GameObject restartBotton;
    public GameObject nextBotton;

    //現在はテキスト　あとで画像に変更する
    Text titleText;//テキスト設定
    void Start()
    {
        // 現在のHPを最大HPで初期化
        currentHealth = maxHealth;
        UpdateHealthUI();

        //画像を非表示にする（現在テキスト表示中）
        Invoke("InactiveText", 1.0f);
        // ボタン、パネルを非表示にする
        panel.SetActive(false);
    }

    // ダメージを受ける関数
    public void TakeDamage(int damage)//HP変更
    {
        currentHealth -= damage;

        // HPが0未満にならないようにする
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthUI();

        // HPが0になったらゲームオーバー処理
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    // HPの表示を更新する関数
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Base HP: " + currentHealth.ToString();//HP管理
        }
    }

    // ゲームオーバー処理
    void GameOver()
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