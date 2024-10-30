using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMneger : MonoBehaviour
{
    public GameObject clickPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        clickPanel.SetActive(false); //非表示
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))//右クリックが押されたら
        {
            clickPanel.SetActive(!clickPanel.activeSelf);//アクティブ状態を反転
        }
    }
}
