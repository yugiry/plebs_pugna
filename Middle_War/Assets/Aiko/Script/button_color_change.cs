using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_color_change : MonoBehaviour
{
    public void change_button_enter()//�}�E�X�J�[�\�����{�^���̏�ɏ������
    {

            this.GetComponent<Renderer>().material.color = new Color(0.7f, 0.7f, 0.7f, 1.0f);//�{�^���̐F���Â�����
                   
    }
    public void change_button2_exit()//�}�E�X�J�[�\�����{�^���̏ォ��~�肽��
    {

            this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);//�{�^���̐F�����̔��F�ɖ߂�
  
    }

  
}
