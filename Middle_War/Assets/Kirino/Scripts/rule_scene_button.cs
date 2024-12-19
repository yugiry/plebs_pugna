using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rule_scene_button : MonoBehaviour
{
    public string NextScene;//新しいscene

    public void Button_Click()//ボタンクリック設定
    {
        SceneManager.LoadScene(NextScene);//別sceneに移動
    }
}
