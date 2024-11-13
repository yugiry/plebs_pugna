using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rule_kakunin_change : MonoBehaviour
{
    // public GameObject panel;
    public string load_scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rule_change()
    {
       // if (panel.activeSelf)
       // {
       //     panel.SetActive(false);
       //}else
       // {
       //     panel.SetActive(true);
       // }
        SceneManager.LoadScene(load_scene);

    }
}
