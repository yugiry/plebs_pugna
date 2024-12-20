using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UI_Operate : MonoBehaviour
{
    public int PUnit_Num;
    private int MaxUnit;
    [SerializeField] Text PUnitText;
    public int EUnit_Num;
    [SerializeField] Text EUnitText;

    // Start is called before the first frame update
    void Start()
    {
        PUnit_Num = 0;
        EUnit_Num = 0;
        MaxUnit = 20;
        PUnitText.text = PUnit_Num.ToString() + "/" + MaxUnit.ToString();
        EUnitText.text = EUnit_Num.ToString() + "/" + MaxUnit.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //ユニットがマップ上に召喚されたら増やす
        if (other.tag == "unit" && PUnit_Num < MaxUnit)
        {
            PUnit_Num++;
            PUnitText.text = PUnit_Num.ToString() + "/" + MaxUnit.ToString();
        }
        if (other.tag == "Eunit" && EUnit_Num < MaxUnit)
        {
            EUnit_Num++;
            EUnitText.text = EUnit_Num.ToString() + "/" + MaxUnit.ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //ユニットが破壊されたら減らす
        if (other.tag == "unit")
        {
            PUnit_Num--;
            PUnitText.text = PUnit_Num.ToString() + "/" + MaxUnit.ToString();
        }
        if (other.tag == "Eunit")
        {
            EUnit_Num--;
            EUnitText.text = EUnit_Num.ToString() + "/" + MaxUnit.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
