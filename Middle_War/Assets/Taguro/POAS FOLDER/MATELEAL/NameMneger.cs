using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class NameMneger : MonoBehaviour
{
    public static string name = "";

    public void GetText()
    {
        Text inputText = GameObject.Find("NameNyuuryoku").GetComponent<Text>();

        string nametext = inputText.text;

        Debug.Log(nametext);

        name = nametext;

    }
}

    