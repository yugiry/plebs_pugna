using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_right : MonoBehaviour
{//�Q�[���I�u�W�F�N�g���E�֐�����
    [SerializeField] AudioClip[] clips;
    AudioSource audioSource;
    public GameObject soundObj;//�T�E���h�I�u�W�F�N�g
    public GameObject info;
    void Start()
    {
        //Component���擾

        audioSource = soundObj.GetComponent<AudioSource>();//�I�[�f�B�I�̃I�[�f�B�I�\�E�X���擾���Ă���B
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))//�{�^���ݒ�
        {
            if (info.activeSelf)
            {
                Debug.Log("AAA");//���̃v���O���������������Ă邩�̃`�F�b�N
                audioSource.PlayOneShot(clips[0]);//�I�[�f�B�I�\�E�X����N���b�v�O�̉����f�[�^���Đ�����
            }
        }
    }
}
