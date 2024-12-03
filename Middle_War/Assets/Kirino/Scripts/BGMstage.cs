using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class BGMstage : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;//�I�[�f�B�I�N���b�N
    [SerializeField] float pitchRange = 0.1f;
    protected AudioSource source;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        source = GetComponents<AudioSource>()[0];//�I�[�f�B�I�\�E�X�u�O�v���擾����
    }

    public void PlayFootstepSE()
    {
        source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
   
}
