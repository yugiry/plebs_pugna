using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class on_mouse : MonoBehaviour
{//ゲームオブジェクト名・関数宣言
    public GameObject obj;
    AudioSource GameObject_Audio;
    AudioClip Source;
    bool first_hit = false;
    public GameObject country_board;

    // Start is called before the first frame update
    public void Start()
    {
        GameObject_Audio = obj.GetComponent<AudioSource>();//ゲームオブジェクトにオーディオソースを追加
    }

    public void OnMouseEnter()
    {
        if (first_hit == false && !country_board.activeSelf)//なにかが非表示になった時条件内に入る
        {
            GameObject_Audio.Play();//ゲームオブジェクトのオーディオソースをプレイする
            first_hit = true;//なにかがヒットした時表示する
        }
    }
    public void OnMouseExit()//キー設定
    {
        first_hit = false;//非表示
    }
}
