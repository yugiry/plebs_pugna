using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class on_mouse : MonoBehaviour
{//�Q�[���I�u�W�F�N�g���E�֐��錾
    public GameObject obj;
    AudioSource GameObject_Audio;
    AudioClip Source;
    bool first_hit = false;
    public GameObject country_board;

    // Start is called before the first frame update
    public void Start()
    {
        GameObject_Audio = obj.GetComponent<AudioSource>();//�Q�[���I�u�W�F�N�g�ɃI�[�f�B�I�\�[�X��ǉ�
    }

    public void OnMouseEnter()
    {
        if (first_hit == false && !country_board.activeSelf)//�Ȃɂ�����\���ɂȂ������������ɓ���
        {
            GameObject_Audio.Play();//�Q�[���I�u�W�F�N�g�̃I�[�f�B�I�\�[�X���v���C����
            first_hit = true;//�Ȃɂ����q�b�g�������\������
        }
    }
    public void OnMouseExit()//�L�[�ݒ�
    {
        first_hit = false;//��\��
    }
}
