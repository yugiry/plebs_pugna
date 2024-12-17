using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_color_change : MonoBehaviour
{
    public void change_button_enter()//マウスカーソルがボタンの上に乗ったら
    {

            this.GetComponent<Renderer>().material.color = new Color(0.7f, 0.7f, 0.7f, 1.0f);//ボタンの色を暗くする
                   
    }
    public void change_button2_exit()//マウスカーソルがボタンの上から降りたら
    {

            this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);//ボタンの色を元の白色に戻す
  
    }

  
}
