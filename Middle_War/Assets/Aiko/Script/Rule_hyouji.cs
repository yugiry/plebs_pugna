using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rule_hyouji : MonoBehaviour
{
    public GameObject rule_hyouji;
    private GameObject rule;
    //public GameObject text;
    [SerializeField] TextMeshProUGUI text;

     int color_change=0;
   public static int hyouji_hihyouji = 0;

    // Start is called before the first frame update
    void Start()
    {
        //color_change = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rule_miseru()
    {
        hyouji_hihyouji++;
        if(hyouji_hihyouji>1)
        {
            hyouji_hihyouji = 0;
        }

        if(rule_hyouji.activeSelf )
        {
            hyouji_hihyouji = 1;
            //rule_hyouji.SetActive(false);
            invisible_rules();
            Debug.Log(hyouji_hihyouji);
        }
        else /*if(hyouji_hihyouji==1)*/
        {
            invisible_rules();
          rule_hyouji.SetActive(true);
            Debug.Log(hyouji_hihyouji);
        }


    }
    public void text_color_change()
    {
        if(color_change==0)
        {
            text.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            color_change++;
            Debug.Log(color_change);
        }
         else
        {
            text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            color_change--;
            Debug.Log(color_change);
        }


    }

    public void invisible_rules()
    {
       GameObject[] rule = GameObject.FindGameObjectsWithTag("Respawn");

        if(rule_hyouji.activeSelf)
        {
            foreach (GameObject Push in rule)
            {
                rule_hyouji.SetActive(false);
                Debug.Log("destroy");
            }
        }

    }

}
