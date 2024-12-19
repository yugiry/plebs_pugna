using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class stageboard : MonoBehaviour
{
    public GameObject mapboard;
   
    void Update()
    {
       if (Input.GetMouseButtonDown(1))//ボタン設定
       {
            mapboard.SetActive(false);//ボタン押された時ゲームオブジェクト非表示
       }
    }

    public void Cancel()//クリック設定
    {
        mapboard.SetActive(false); ;//クリックした時ゲームオブジェクト非表示
    }
}
