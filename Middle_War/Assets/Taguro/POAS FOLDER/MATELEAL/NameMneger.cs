using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���O����͂����Ă���e�L�X�g���l�����邽�߂̂���
/// </summary>
public class NameMneger : MonoBehaviour
{
    public GameObject NameEnter;

    public static string name = "";//���͂��ꂽ���O��ۑ�����

    //�e�L�X�g�l���֐�
    //����
    public void GetText()
    {
   
        Text input_text = GameObject.Find("name_entry").GetComponent<Text>();//name_entry�ɓ��͂��ꂽ�̂��m�F����

        string name_text = input_text.text.Replace("\n","").Replace(" ","").Replace(" ","").Trim();//���O�����͂���Ă��Ȃ��E�󔒂�����ꍇ�{�^���������Ȃ��悤�ɂ���

        Debug.Log(name_text);

        name = name_text;

        NameEnter.SetActive(false);
    }
}