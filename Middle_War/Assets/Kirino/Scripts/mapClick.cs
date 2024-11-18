using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapClick : MonoBehaviour
{
    public GameObject mapbatoru;
    public int countrynum;//クリックした時に値を与える

    [SerializeField] mapfaito mapfaito;//値を送りたいスクリプトの名前
    //[SerializeField] imagemap imagemap;//値を送りたいスクリプトの名前

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Cllik()
    {
        mapbatoru.SetActive(true);//マップボード表示
        mapfaito.Show_country(countrynum);//mapfaito.csスクリプトにクリックされたcountrynumの値を送る
        //imagemap.Shew_island(countrynum);//imagemap.csスクリプトにクリックされたcountrynumの値を送る
    }
}
