using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_SE : MonoBehaviour
{
    public GameObject obj;
    AudioSource button_Audio;
    AudioClip Source;
    bool first_hit = false;

    // Start is called before the first frame update
    public void Start()
    {
        button_Audio = obj.GetComponent<AudioSource>();
    }

    public void OnMouseEnter()
    {
        //�}�E�X�J�[�\�����d�Ȃ����Ƃ���x����������炷
        if (first_hit == false) 
        {
           button_Audio.Play();
           first_hit = true;
        }
    }

    public void OnMouseExit()
    {
        //�}�E�X�J�[�\�������ꂽ���悤�ɖ߂�
        first_hit = false;
    }

}
