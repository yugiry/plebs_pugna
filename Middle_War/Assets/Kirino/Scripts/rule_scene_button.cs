using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rule_scene_button : MonoBehaviour
{
    public string NextScene;//�V����scene

    public void Button_Click()//�{�^���N���b�N�ݒ�
    {
        SceneManager.LoadScene(NextScene);//��scene�Ɉړ�
    }
}
