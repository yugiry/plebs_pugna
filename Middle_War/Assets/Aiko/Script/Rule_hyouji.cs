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
   
    //[SerializeField] TextMeshProUGUI text;

    public int color_change=1;
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
    public void text_color_change()
    {
        color_change++;
        if(color_change>1)
        {
            color_change = 0;
        }

        switch(color_change)
        {
            case 0:
                //change_black();
                text.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            
            Debug.Log("t"+color_change);
                break;
           
            case 1:
                text.color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
               // change_black();
            Debug.Log("t"+color_change);
                break;
        }


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
