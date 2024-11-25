using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testSeen : MonoBehaviour
{
    public void change_button()
    {
        if(NameMneger.name != "")
        {
            SceneManager.LoadScene("test");
        }
       
    }
}
