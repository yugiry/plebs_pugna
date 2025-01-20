using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class audio_Controller : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;//�I�[�f�B�I�̃N���b�v�쐬
    [SerializeField] float pitchRange = 0.1f;//�J�n�E�I���C���f�b�N�X
    protected AudioSource source;//�I�[�f�B�I�\�E�X�ǉ�
    //�Q�[���I�u�W�F�N�g���E�ϐ��錾
    bool PlaySound;
    public mapfaito MF;
    [SerializeField] GameObject NotClick;
    private void Start()
    {
        source = GetComponent<AudioSource>();//�I�[�f�B�I�\�E�X���擾�B
        PlaySound = false;//�Đ����̃T�E���h���~�߂�
    }

    private void Update()
    {
        if(PlaySound && !source.isPlaying)
        {
            MF.Change_Button();//�{�^���ύX
        }
    }

    public void map_select()
    {
        source.PlayOneShot(clips[0]);//�N���b�v�O�̉����f�[�^���Đ�
    }

    public void click_fight()
    {
        NotClick.SetActive(true);
        source.PlayOneShot(clips[1]);//�N���b�v�P�̉����f�[�^���Đ�
        PlaySound = true;//�T�E���h�Đ�
    }
}
