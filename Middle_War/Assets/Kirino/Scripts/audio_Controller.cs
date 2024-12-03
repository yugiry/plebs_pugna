using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class audio_Controller : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;//�I�[�f�B�I�̂�����v����
    [SerializeField] float pitchRange = 0.1f;//
    protected AudioSource source;//�I�[�f�B�I�̃\�E�X�ǉ�

    bool PlaySound;
    public mapfaito MF;

    private void Start()
    {
        source = GetComponent<AudioSource>();//�I�[�f�B�I�̃I�[�f�B�I�\�E�X���擾���Ă���B
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
        source.PlayOneShot(clips[0]);//�N���b�v�O�̉����f�[�^���Đ�
    }

    public void click_fight()
    {
        source.PlayOneShot(clips[1]);//�N���b�v�P�̉����f�[�^���Đ�
        PlaySound = true;
    }
}
