using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rule_scene_button : MonoBehaviour
{
    public string NextScene;

    public void Button_Click()
    {
        SceneManager.LoadScene(NextScene);
    }
}
