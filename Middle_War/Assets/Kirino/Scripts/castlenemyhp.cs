using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castlenemyhp : MonoBehaviour
{
    [SerializeField] Text hpText;//敵HPテキスト

    int maxhp = 35;//敵HP最大
    float nowhp = 35;//敵HP現在

    GameObject c2;
    SpriteRenderer SR;
    [SerializeField] Sprite[] enemy_castle_image;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();//敵HP表示変更処理

        //c2 = GameObject.Find("castle2(Clone)");
        //SR = c2.GetComponent<SpriteRenderer>();//オブジェクトのスプライト情報を取得
        //SR.sprite = enemy_castle_image[2];


    }

    // Update is called once per frame
    void Update()
    {
        if (c2 == null)
        {
            c2 = GameObject.Find("castle2(Clone)");
            SR = c2.GetComponent<SpriteRenderer>();//オブジェクトのスプライト情報を取得
                                                   //SR.sprite = enemy_castle_image[2];

        }
        Debug.Log("検索終了");

        if (nowhp > 30)
        {
            SR.sprite = enemy_castle_image[0];
        }
        else if (nowhp > 20)
        {
            SR.sprite = enemy_castle_image[1];
        }

        if (nowhp == 0)
        {

        }
    }
}