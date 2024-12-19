using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class APchange : MonoBehaviour
{
    [SerializeField] Text apText;//APテキスト

    int maxAp = 999;//最大のAP表示
    float nowAp = 0;//最小のAP表示

    // Start is called before the first frame update
    void Start()
    {//テキスト変更
        apText.text = nowAp.ToString() + "/" + maxAp.ToString();//APテキスト表示変更処理
    }

}
