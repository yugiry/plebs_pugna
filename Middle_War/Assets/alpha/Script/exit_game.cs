using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_game : MonoBehaviour
{
    public string NextScene;

    public void click()
    {
        SceneManager.LoadScene(NextScene);
    }
}
