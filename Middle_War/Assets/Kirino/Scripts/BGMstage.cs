using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class BGMstage : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;//オーディオクリック
    [SerializeField] float pitchRange = 0.1f;
    protected AudioSource source;
    // Start is called before the first frame update
   
    private void Awake()
    {
        source = GetComponents<AudioSource>()[0];//オーディオソウス「０」を取得する
    }

    public void PlayFootstepSE()
    {
        source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
   
}
