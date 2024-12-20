using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class NameMneger : MonoBehaviour
{
    public GameObject NameEnter;

    public static string name = "";//入力された名前を保存する

    public void GetText()
    {
        

        Text inputText = GameObject.Find("name_entry").GetComponent<Text>();//name_entryに入力されたのを確認する

        string nametext = inputText.text.Replace("\n","").Replace(" ","").Replace(" ","").Trim();//名前が入力されていない・空白がある場合ボタンを押せないようにする

        Debug.Log(nametext);

        name = nametext;

        NameEnter.SetActive(false);
    }
}

    