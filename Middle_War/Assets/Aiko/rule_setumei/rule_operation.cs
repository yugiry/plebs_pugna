using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rule_operation : MonoBehaviour
{
    Rule_kakunin_change rule_watch; //�ĂԃX�N���v�g�ɂ����Ȃ���

    public string NextScene;

    int num_loads;
    // Start is called before the first frame update
    void Start()
    {
        
       
        //rule_watch = GetComponent<Rule_kakunin_change>(); //�t���Ă���X�N���v�g���擾

    }
   public void Scene_Back()
    {

     

        SceneManager.LoadScene(NextScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
