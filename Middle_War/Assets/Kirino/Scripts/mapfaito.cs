using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mapfaito : MonoBehaviour
{
    public int countrynum;
    public GameObject mapbatoru;

    public infan CI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click()
    {
        mapbatoru.SetActive(true);

    }

    //public void show_country(int num)
    //{
    //    switch(num)
    //    {
    //        case 1:
    //            text = "УGН№Вы";
    //            mapubatoru.transform.position = new Vector3(0, 0, 0);
    //            break;
    //    }
    //}
}