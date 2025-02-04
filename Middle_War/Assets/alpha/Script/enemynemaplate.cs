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

        switch (Country_Num) //受け取った値別処理
        {
            case 1:
                //text2.text = "自国"; //国名
                break;
            case 2:
                text[0].text = "フスラン"; //国名
                countryname.text = text[0].text;
                break;
            case 3:
                text[0].text = "ア・タイリ"; //国名
                countryname.text = text[0].text;
                break;
            case 4:
                text[0].text = "アイべり半島"; //国名
                countryname.text = text[0].text;
                break;
            case 5:
                text[0].text = "アベチネ";
                countryname.text = text[0].text;
                break;
            case 6:
                text[0].text = "ナクウイラ";
                countryname.text = text[0].text;
                break;
            case 7:
                text[0].text = "アブリガル";
                countryname.text = text[0].text;
                break;
            default:
                Debug.Log("Default"); //switch処理の最後
                break;
        }
    }
}
