using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static mapClick;

public class enemynemaplate : MonoBehaviour
{
    public int country_num;
    [SerializeField] public Text[] text;

    public Text countryname;

    private void Start()
    {
        country_num = mapfaito.instance.countrynum;
        cuntrynum(country_num);
    }

    public void cuntrynum(int Country_Num)
    { 

        switch (Country_Num) //�󂯎�����l�ʏ���
        {
            case 1:
                //text2.text = "����"; //����
                break;
            case 2:
                text[0].text = "�t�X����"; //����
                countryname.text = text[0].text;
                break;
            case 3:
                text[0].text = "�A�E�^�C��"; //����
                countryname.text = text[0].text;
                break;
            case 4:
                text[0].text = "�A�C�ׂ蔼��"; //����
                countryname.text = text[0].text;
                break;
            case 5:
                text[0].text = "�A�x�`�l";
                countryname.text = text[0].text;
                break;
            case 6:
                text[0].text = "�i�N�E�C��";
                countryname.text = text[0].text;
                break;
            case 7:
                text[0].text = "�A�u���K��";
                countryname.text = text[0].text;
                break;
            default:
                Debug.Log("Default"); //switch�����̍Ō�
                break;
        }
    }
}
