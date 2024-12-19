using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapselection : MonoBehaviour
{
    public GameObject mapsere;//ゲームオブジェクト名宣言
    public GameObject player;
    public GameObject player2;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject map;

    public void click()//クリック設定
    {
        mapsere.SetActive(false);//各ゲームオブジェクト表示・非表示
        player.SetActive(true);
        player2.SetActive(true);
        enemy.SetActive(true);
        enemy2.SetActive(true);
        map.SetActive(true);
    }
}
