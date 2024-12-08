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
                my_text.text = "\nフィールドマップ上にある資材まで'歩兵'を移動させてから資材を左クリックすることで回収ができる。\n";
                break;

            case 3://攻撃
                my_text.text = "\n攻撃したいユニットが射程内なら、攻撃させたいユニットを左クリックして、攻撃したいユニットを左クリックすれば攻撃する事ができる。\n各ユニットの攻撃射程はユニットを左クリックしてからマウスホイールでクリックすると確認できる。\n";
                break;
            case 4://勝利条件
                my_text.text = "\n自軍が敵の本陣のHPを0にすれば勝利となる。\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nがんばれ！\n";
                break;
            case 5://敗北条件
                my_text.text = "\n敵軍によって自軍の本陣のHPが0にされれば敗北となる。\n";
                break;
            case 6://フィールド情報
                my_text.text = "\n資材…カタパルトを召喚する為に必要なもの。歩兵で回収が可能。\n川…どのユニットでも通ることができるが移動時の消費AP量がそれぞれ1ずつ増える。\n森…どんなユニットも通ることができない場所。\n";
                break;
            case 7://ユニット情報
                my_text.text = "\n歩兵…近接攻撃しかできないが召喚に必要なAPが少なく資材を回収する事ができる唯一の兵士。\n弓兵…遠距離攻撃が可能な兵士。体力が低く召喚に必要なAPも多い。\nカタパルト…長距離攻撃が可能な攻城兵器。攻撃力が高いが召喚コストも移動に使用するAP量も多く周囲1マスまで近寄られると何もできなくなる弱点がある。\n";
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
