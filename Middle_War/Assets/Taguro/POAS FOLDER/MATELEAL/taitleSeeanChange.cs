using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class taitleSeeanChange : MonoBehaviour
{
  public void change_button()
    {
        SceneManager.LoadScene("taitle");//タイトルにシーン移動
    }
}
