using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemynemaplate : MonoBehaviour
{
    public int countrynum;
    [SerializeField] public Text[] text;

    GameObject RCNobj;
    remenber_country_num RCN;

    private void Awake()
    {
        RCNobj = GameObject.Find("country_info");
        RCN = RCNobj.GetComponent<remenber_country_num>();
    }

    public void Country_Num(int Country_Num)
    { 
        RCN.country_num = Country_Num;

        switch (Country_Num) //�󂯎�����l�ʏ���
        {
            case 1:
                //text2.text = "����"; //����
                break;
            case 2:
                text[0].text = "�t�X����"; //����
                RCN.country_num = countrynum;
                break;
            case 3:
                text[0].text = "�A�E�^�C��"; //����           
                RCN.country_num = countrynum;
                break;
            case 4:
                text[0].text = "�A�C�ׂ蔼��"; //����             
                RCN.country_num = countrynum;
                break;
            case 5:
                text[0].text = "�A�x�`�l";
                RCN.country_num = countrynum;
                break;
            case 6:
                text[0].text = "�i�N�E�C��";
                RCN.country_num = countrynum;
                break;
            case 7:
                text[0].text = "�A�u���K��";
                RCN.country_num = countrynum;
                break;
            default:
                Debug.Log("Default"); //switch�����̍Ō�
                break;
        }
    }
}
