using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouseManager : MonoBehaviour
{
    public GameObject pausePanel;
   
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);//非表示
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//エスケープが押されたら
        {
            pausePanel.SetActive(!pausePanel.activeSelf);//アクティブ状態を反転させる
        }
 
    }
   
}
