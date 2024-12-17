using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rule_operation : MonoBehaviour
{
    
    
    public string NextScene;//移動させるシーン

    int num_loads;
    // Start is called before the first frame update
    void Start()
    {
        
       
        

    }
   public void Scene_Back()
    {

     

        SceneManager.LoadScene(NextScene);//NextSceneに書き込んだシーン名に移動する。

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
