using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_country : MonoBehaviour
{
    public int max_country;//遊べる国の最大数
    [SerializeField] GameObject[] country_clear;//各国のクリアフラグを置いておく変数

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < max_country; i++)
        {
            //クリアフラグが立っていたら次の国を表示する
            if(country_clear[i - 1].transform.GetChild(0).gameObject.activeSelf)
            {
                country_clear[i].SetActive(true);
            }
        }
    }
}
