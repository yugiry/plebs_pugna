using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PouseManager : MonoBehaviour
{
    public GameObject pausePanel;

    [SerializeField]Pause_Explanation PE;

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
            
            PE._Pause();
            pausePanel.SetActive(!pausePanel.activeSelf);//アクティブ状態を反転させる
        }
 
    }
   
}
