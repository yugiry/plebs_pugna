using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AP_Kanri : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI KeyText;

    public int AP = 100;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            AP--;

            string AP_Total = AP.ToString();

            KeyText.text = "AP:" + AP_Total;
        }

       
    }
}
