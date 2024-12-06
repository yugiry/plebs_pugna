using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(AudioSource))]
public class mapClick : MonoBehaviour
{
    public GameObject mapbatoru;
    public int countrynum;//クリックした時に値を与える
    public audio_Controller AC;
    public bool clear_flag;
    [SerializeField] mapfaito mapfaito;//値を送りたいスクリプトの名前
    [SerializeField] SpriteRenderer change_color;


    public void Cllik()
    {
        if (Input.GetMouseButtonDown(0) && !mapbatoru.activeSelf)
        {
            mapbatoru.SetActive(true);//マップボード表示
            mapfaito.Show_country(countrynum);//mapfaito.csスクリプトにクリックされたcountrynumの値を送る
            AC.map_select();
            //imagemap.Shew_island(countrynum);//imagemap.csスクリプトにクリックされたcountrynumの値を送る
        }
    }

    public void pointer_enter()
    {
        change_color.color = new Color(1, 1, 0, 1);
    }

    public void pointer_exit()
    {
        change_color.color = new Color(1, 1, 1, 1);
    }
}
