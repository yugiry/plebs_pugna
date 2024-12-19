using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castlenemyhp : MonoBehaviour
{
    [SerializeField] Text hpText;//敵HPテキスト

    int maxhp = 35;//敵HP最大
    float nowhp = 35;//敵HP現在
    // Start is called before the first frame update
    void Start()
    {
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();//敵HP表示変更処理
    }

}
