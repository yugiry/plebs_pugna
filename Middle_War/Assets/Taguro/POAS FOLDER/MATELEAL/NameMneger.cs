using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 名前を入力をしてからテキストを獲得するためのもの
/// </summary>
public class NameMneger : MonoBehaviour
{
    public GameObject NameEnter;

    public static string name = "";//入力された名前を保存する

    //テキスト獲得関数
    //説明
    public void GetText()
    {
   
        Text input_text = GameObject.Find("name_entry").GetComponent<Text>();//name_entryに入力されたのを確認する

        string name_text = input_text.text.Replace("\n","").Replace(" ","").Replace(" ","").Trim();//名前が入力されていない・空白がある場合ボタンを押せないようにする

        Debug.Log(name_text);

        name = name_text;

        NameEnter.SetActive(false);
    }
}