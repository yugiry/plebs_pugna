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
    { //mapClickから受け取った値を読み取る
        switch (countrynum) //受け取った値別処理
        {
            case 1:
                //text2.text = "自国"; //国名
                break;
            case 2:
                text2.text = "フスラン"; //国名
                RCN.country_num = countrynum;
                break;
            case 3:
                text2.text = "ア・タイリ"; //国名           
                RCN.country_num = countrynum;
                break;
            case 4:
                text2.text = "アイべり半島"; //国名             
                RCN.country_num = countrynum;
                break;
            case 5:
                text2.text = "アベチネ";
                RCN.country_num = countrynum;
                break;
            case 6:
                text2.text = "ナクウイラ";
                RCN.country_num = countrynum;
                break;
            case 7:
                text2.text = "アブリガル";
                RCN.country_num = countrynum;
                break;
            default:
                Debug.Log("Default"); //switch処理の最後
                break;
        }
    }

}
