using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undo : MonoBehaviour
{
    GameObject clickedGameObject;
    public GameObject castlevalue;//各ゲームオブジェクト名宣言
    public GameObject infantrystatus;
    public GameObject archerstatus;
    public GameObject catapultstatus;
    public GameObject castlevalue2;
    public GameObject button_infantry;
    public GameObject button_archer;
    public GameObject button_catapalt;

    public GameObject enemycastlevalue;
    public GameObject enemyinfantrystatus;
    public GameObject enemyarcherstatus;
    public GameObject enemycatapultstatus;
    public GameObject enemycastlevalue2;
    public GameObject enemybutton_infantry;
    public GameObject enemybutton_archer;
    public GameObject enemybutton_catapalt;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))//ボタン設定
        {
            infantrystatus.SetActive(false);//ボタン押された時のゲームオブジェクト表示・非表示処理
            archerstatus.SetActive(false);
            catapultstatus.SetActive(false);
            castlevalue.SetActive(true);
            castlevalue2.SetActive(false);
            button_infantry.SetActive(true);
            button_archer.SetActive(true);
            button_catapalt.SetActive(true);

            enemyinfantrystatus.SetActive(false);
            enemyarcherstatus.SetActive(false);
            enemycatapultstatus.SetActive(false);
            enemycastlevalue.SetActive(true);
            enemycastlevalue2.SetActive(false);
            enemybutton_infantry.SetActive(true);
            enemybutton_archer.SetActive(true);
            enemybutton_catapalt.SetActive(true);
        }
    }
}
