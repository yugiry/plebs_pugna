using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testSeen : MonoBehaviour
{
    public string NextScene;

    public void change_button()
    {
        if(NameMneger.name != "")//名前が入力されたら
        {
            FadeManager.Instance.LoadScene(NextScene,1.0f);//シーン移動
        }
       
    }
}
