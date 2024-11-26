using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;//スクリプトでUI(テキストなど)扱うときはこれ必須！！

public class Rule_hyouji : MonoBehaviour
{
    public GameObject rule_hyouji;
    private GameObject rule;
    public Text text;

    public next_back_button NBB;
    //[SerializeField] TextMeshProUGUI text;

    public int mode_change;
   public static int hyouji_hihyouji = 0;

    // Start is called before the first frame update
    void Start()
    {
        //color_change = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    invisible_rules();
        //}
    }

    public void rule_miseru()
    {
        switch (mode_change)
        {
            case 1:
                NBB.fullpage = 4;
                NBB.hyouji_num = mode_change;
                break;
            case 2:
                NBB.fullpage = 1;
                NBB.hyouji_num = mode_change;
                break;
            case 3:
                NBB.fullpage = 2;
                NBB.hyouji_num = mode_change;
                break;
            case 4:
                NBB.fullpage = 1;
                NBB.hyouji_num = mode_change;
                break;
            case 5:
                NBB.fullpage = 3;
                NBB.hyouji_num = mode_change;
                break;
            case 6:
                NBB.fullpage = 1;
                NBB.hyouji_num = mode_change;
                break;
            case 7:
                NBB.fullpage = 1;
                NBB.hyouji_num = mode_change;
                break;
            case 8:
                NBB.fullpage = 1;
                NBB.hyouji_num = mode_change;
                break;
        }

        hyouji_hihyouji++;
        if(hyouji_hihyouji>1)
        {
            hyouji_hihyouji = 0;
        }
        /*switch(hyouji_hihyouji)
        {
            case 0:
                hyouji_hihyouji = 1;
                //rule_hyouji.SetActive(false);
                text_color_change();

                invisible_rules();

                Debug.Log(hyouji_hihyouji);
                break;
            case 1:
                text_color_change();

                invisible_rules();

                rule_hyouji.SetActive(true);
                Debug.Log(hyouji_hihyouji);
                break;


        }*/

        if(rule_hyouji.activeSelf )
        {
            hyouji_hihyouji = 1;
            //rule_hyouji.SetActive(false);
           // text_color_change();

            invisible_rules();
            
            Debug.Log(hyouji_hihyouji);
        }
        else //if(hyouji_hihyouji==1)
        {
           // text_color_change();

            invisible_rules();
            
            rule_hyouji.SetActive(true);
            Debug.Log(hyouji_hihyouji);
        }


    }
    public void text_mode_change()
    {
        
    }

    public void invisible_rules()
    {
       GameObject[] rule = GameObject.FindGameObjectsWithTag("Respawn");

        
            foreach (GameObject Push in rule)
            {
                Push.SetActive(false);
                Debug.Log("destroy"+Push.name);
            }
        

    }

    //public void change_black()
    //{
    //    GameObject[] TEXT = GameObject.FindGameObjectsWithTag("Player");

    //    foreach(GameObject color in TEXT)
    //    {
    //        text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    //    }

    //}

    public void change_button_enter()
    {
        //GameObject[] Button = GameObject.FindGameObjectsWithTag("Player");

        
        
            this.GetComponent<Renderer>().material.color = new Color(0.7f, 0.7f, 0.7f, 1.0f);
        
    }
    public void change_button2_exit()
    {
        //GameObject[] Button = GameObject.FindGameObjectsWithTag("Player");



        this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    }

}
