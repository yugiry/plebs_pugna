using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class audio_Controller : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;//オーディオのくりっプ製作
    [SerializeField] float pitchRange = 0.1f;//
    protected AudioSource source;//オーディオのソウス追加

    bool PlaySound;
    public mapfaito MF;

    private void Start()
    {
        source = GetComponent<AudioSource>();//オーディオのオーディオソウスを取得している。
        PlaySound = false;
    }

    private void Update()
    {
        if(PlaySound && !source.isPlaying)
        {
            MF.change_button();
        }
    }

    public void map_select()
    {
        source.PlayOneShot(clips[0]);//クリップ０の音声データを再生
    }

    public void click_fight()
    {
        source.PlayOneShot(clips[1]);//クリップ１の音声データを再生
        PlaySound = true;
    }
}
