using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class NameMneger : MonoBehaviour
{
    public GameObject NameEnter;

    public static string name = "";//���͂��ꂽ���O��ۑ�����

    public void GetText()
    {
        

        Text inputText = GameObject.Find("name_entry").GetComponent<Text>();//name_entry�ɓ��͂��ꂽ�̂��m�F����

        string nametext = inputText.text.Replace("\n","").Replace(" ","").Replace(" ","").Trim();//���O�����͂���Ă��Ȃ��E�󔒂�����ꍇ�{�^���������Ȃ��悤�ɂ���

        Debug.Log(nametext);

        name = nametext;

        NameEnter.SetActive(false);
    }
}

    