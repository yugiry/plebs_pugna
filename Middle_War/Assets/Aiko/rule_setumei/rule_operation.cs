using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rule_operation : MonoBehaviour
{
    Rule_kakunin_change rule_kakunin; //�ĂԃX�N���v�g�ɂ����Ȃ���

    int num_loads;
    // Start is called before the first frame update
    void Start()
    {
        
       // GameObject obj = GameObject.Find("Rule_Button"); //Rule_Button���Ă����I�u�W�F�N�g��T��
        rule_kakunin = GetComponent<Rule_kakunin_change>(); //�t���Ă���X�N���v�g���擾

    }
   public void Scene_Modoru()
    {

      num_loads = Scene_Num.load_num;

        switch(num_loads)
        {
            case 0:
                SceneManager.LoadScene("Tile_test_Scene");      
                break;
            case 1:
                SceneManager.LoadScene("Test Scene");
                break;
        }

        Debug.Log(num_loads);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
