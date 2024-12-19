using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class castlhp : MonoBehaviour
{
    [SerializeField] Text hpText;//HPテキスト

    int maxhp = 35;//最大HP
    float nowhp = 35;//現在HP

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();//HP表示処理
    }

    // Update is called once per frame
    void Update()
    {
        if(nowhp == 0)
        {

        }
    }
  
    public void HitAttack(int hit)//HP変更
    {
        nowhp -= hit;
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();//HPテキスト変更処理
    }
}