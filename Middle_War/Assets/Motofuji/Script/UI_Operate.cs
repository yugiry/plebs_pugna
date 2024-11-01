using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UI_Operate : MonoBehaviour
{
    public int Unit_Num;
    private int MaxUnit;
    [SerializeField] Text UnitText;

    // Start is called before the first frame update
    void Start()
    {
        Unit_Num = 0;
        MaxUnit = 20;
        UnitText.text = Unit_Num.ToString() + "/" + MaxUnit.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.name == "Pinfantry(Clone)" || other.gameObject.name == "Parcher(Clone)" || other.gameObject.name == "Pcatapalt(Clone)") && Unit_Num < MaxUnit)
        {
            Unit_Num++;
            UnitText.text = Unit_Num.ToString() + "/" + MaxUnit.ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Pinfantry(Clone)" || other.gameObject.name == "Parcher(Clone)" || other.gameObject.name == "Pcatapalt(Clone)")
        {
            Unit_Num--;
            UnitText.text = Unit_Num.ToString() + "/" + MaxUnit.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
