using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mapfaito : MonoBehaviour
{
    public int countrynum;
    [SerializeField] public Text text1;
    [SerializeField] public Text text2;
    public GameObject Button;

    public infan CI;

    // Start is called before the first frame update
    void Start()
    {
        string countrynum;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void show_country(int num)
    {
        //int number = 1;

        switch (num)
        {
            case 1:
                text1.text = "";
                text2.text = "";
                
                //Button = ;
                mapbatoru.transform.position = new Vector3(20, 0, 0);
                break;
            case 2:
                text1.text = "";
                text2.text = "";

                //Button = ;
                mapbatoru.transform.position = new Vector3(20, 0, 0);
                break;
            case 3:
                text1.text = "";
                text2.text = "";

                //Button = ;
                mapbatoru.transform.position = new Vector3(20, 0, 0);
                break;
            default:
                Debug.Log("Default");              
                break;
        }
    }
}