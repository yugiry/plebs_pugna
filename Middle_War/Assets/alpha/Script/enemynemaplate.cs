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

        switch (Country_Num) //受け取った値別処理
        {
            case 1:
                //text2.text = "自国"; //国名
                break;
            case 2:
                text[0].text = "フスラン"; //国名
                RCN.country_num = countrynum;
                break;
            case 3:
                text[0].text = "ア・タイリ"; //国名           
                RCN.country_num = countrynum;
                break;
            case 4:
                text[0].text = "アイべり半島"; //国名             
                RCN.country_num = countrynum;
                break;
            case 5:
                text[0].text = "アベチネ";
                RCN.country_num = countrynum;
                break;
            case 6:
                text[0].text = "ナクウイラ";
                RCN.country_num = countrynum;
                break;
            case 7:
                text[0].text = "アブリガル";
                RCN.country_num = countrynum;
                break;
            default:
                Debug.Log("Default"); //switch処理の最後
                break;
        }
    }
}
