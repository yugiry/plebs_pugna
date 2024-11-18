using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Hyouji : MonoBehaviour
{
    public int text_num;
    private Text my_text;

    public void Text_Kakikae()
    {
        switch(text_num)
        {
            case 0://召喚
                my_text.text = "\nUI画面にあるユニットを左クリックしてから自分の陣地を左クリックすると召喚できる。\nただし、召喚に必要なAPまたは資源が足りないと召喚できない。";
            break;

            case 1://移動
                my_text.text = "\n移動させたいユニットを左クリックしてから行きたいマスを左クリックすれば移動できる。\n";
                break;

            case 2://採取
                my_text.text = "\nフィールドマップ上にある資材まで歩兵を移動させてから資材を左クリックすることで回収ができる。\n";
                break;

            case 3://攻撃
                my_text.text = "\n攻撃したいユニットが射程内なら、攻撃させたいユニットを左クリックして、攻撃したいユニットを左クリックする事で攻撃することができる。\n各ユニットの攻撃射程はユニットを左クリックしてからマウスホイールでクリックすると確認できる。\n";
                break;
            case 4://勝利条件
                my_text.text = "\n自軍が敵の本陣のHPを0にすれば勝利となる。\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nがんばれ！\n";
                break;
            case 5://敗北条件
                my_text.text = "\n敵軍によって自軍の本陣のHPが0にされれば敗北となる。\n";
                break;
            case 6://フィールド情報
                my_text.text = "\n資材…\n川…\n山…\n";
                break;
            case 7://ユニット情報
                my_text.text = "\n歩兵…\t\n弓兵…\t\nカタパルト…長距離攻撃が可能な攻城兵器。攻撃力が高いが召喚コストも移動に使用するAP量も多く周囲1マスまで近寄られると何もできなくなる弱点がある。\n";
                break;


        }


    }

    // Start is called before the first frame update
    void Start()
    {
        my_text = GameObject.Find("setumei").GetComponent<Text>();
        my_text.color = new Color(1.0f,1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
