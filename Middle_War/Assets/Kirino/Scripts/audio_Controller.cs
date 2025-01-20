using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class audio_Controller : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;//オーディオのクリップ作成
    [SerializeField] float pitchRange = 0.1f;//開始・終了インデックス
    protected AudioSource source;//オーディオソウス追加
    //ゲームオブジェクト名・変数宣言
    bool PlaySound;
    public mapfaito MF;
    [SerializeField] GameObject NotClick;
    private void Start()
    {
        source = GetComponent<AudioSource>();//オーディオソウスを取得。
        PlaySound = false;//再生中のサウンドを止める
    }

    private void Update()
    {
        if(PlaySound && !source.isPlaying)
        {
            MF.Change_Button();//ボタン変更
        }
    }

    public void map_select()
    {
        source.PlayOneShot(clips[0]);//クリップ０の音声データを再生
    }

    public void click_fight()
    {
        NotClick.SetActive(true);
        source.PlayOneShot(clips[1]);//クリップ１の音声データを再生
        PlaySound = true;//サウンド再生
    }
}
