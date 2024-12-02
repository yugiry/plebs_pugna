using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_country : MonoBehaviour
{
    public int max_country; 
    [SerializeField] GameObject[] country_clear;
    GameObject clear_obj;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 4; i++)
        {
            if(country_clear[i - 1].transform.GetChild(0).gameObject.activeSelf)
            {
                country_clear[i].SetActive(true);
            }
        }
    }
}
