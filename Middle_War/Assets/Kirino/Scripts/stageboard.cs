using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class stageboard : MonoBehaviour
{
    public GameObject mapboard;
   
    void Update()
    {
       if (Input.GetMouseButtonDown(1))//�{�^���ݒ�
       {
            mapboard.SetActive(false);//�{�^�������ꂽ���Q�[���I�u�W�F�N�g��\��
       }
    }

    public void Cancel()//�N���b�N�ݒ�
    {
        mapboard.SetActive(false); ;//�N���b�N�������Q�[���I�u�W�F�N�g��\��
    }
}
