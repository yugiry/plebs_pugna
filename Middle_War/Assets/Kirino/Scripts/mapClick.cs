using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapClick : MonoBehaviour
{
    public GameObject mapbatoru;
    //public int countrynum;
    public int countrynum;
    public GameObject faito;

    [SerializeField] mapfaito mapfaito;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Cllik()
    {
        mapbatoru.SetActive(true);
        mapfaito.show_country(countrynum);
    }

   
}
