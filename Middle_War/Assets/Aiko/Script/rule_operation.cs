using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rule_operation : MonoBehaviour
{ 
    public string NextScene;//�ړ�������V�[��

    int num_loads;
  
   public void Scene_Back()
    {
        SceneManager.LoadScene(NextScene);//NextScene�ɏ������񂾃V�[�����Ɉړ�����B

    }
}
