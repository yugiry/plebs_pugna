using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_right : MonoBehaviour
{//ゲームオブジェクト名・関数制限
    [SerializeField] AudioClip[] clips;
    AudioSource audioSource;
    public GameObject soundObj;//サウンドオブジェクト
    public GameObject info;
    void Start()
    {
        //Componentを取得

        audioSource = soundObj.GetComponent<AudioSource>();//オーディオのオーディオソウスを取得している。
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))//ボタン設定
        {
            if (info.activeSelf)
            {
                Debug.Log("AAA");//このプログラム処理が動いてるかのチェック
                audioSource.PlayOneShot(clips[0]);//オーディオソウスからクリップ０の音声データを再生する
            }
        }
    }
}
