using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSeean : MonoBehaviour
{
   
    public void change_button()
    {
        FadeManager.Instance.LoadScene("NameSeean", 1.0f);//�t�F�[�h�}�l�[�W���[���g���ăV�[���ړ�������
        
    }
}
