using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class enemynemaplate : MonoBehaviour
{
    public int countrynum;
    [SerializeField] public Text text2;
    GameObject rcnobj;
    remenber_country_num RCN;

    private Text nameText;

    private void Awake()
    {
        rcnobj = GameObject.Find("country_info");
        RCN = rcnobj.GetComponent<remenber_country_num>();
    }

    public void Show_country(int countrynum)
    { //mapClick����󂯎�����l��ǂݎ��
        switch (countrynum) //�󂯎�����l�ʏ���
        {
            case 1:
                //text2.text = "����"; //����
                break;
            case 2:
                text2.text = "�t�X����"; //����
                RCN.country_num = countrynum;
                break;
            case 3:
                text2.text = "�A�E�^�C��"; //����           
                RCN.country_num = countrynum;
                break;
            case 4:
                text2.text = "�A�C�ׂ蔼��"; //����             
                RCN.country_num = countrynum;
                break;
            case 5:
                text2.text = "�A�x�`�l";
                RCN.country_num = countrynum;
                break;
            case 6:
                text2.text = "�i�N�E�C��";
                RCN.country_num = countrynum;
                break;
            case 7:
                text2.text = "�A�u���K��";
                RCN.country_num = countrynum;
                break;
            default:
                Debug.Log("Default"); //switch�����̍Ō�
                break;
        }
    }

}
