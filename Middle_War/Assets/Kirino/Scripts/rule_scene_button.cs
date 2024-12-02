using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rule_scene_button : MonoBehaviour
{
    public string NextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button_Click()
    {
        SceneManager.LoadScene(NextScene);
    }
}
