using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class APchange : MonoBehaviour
{
    [SerializeField] Text apText;

    int maxAp = 999;
    float nowAp = 0;

    // Start is called before the first frame update
    void Start()
    {
        apText.text = nowAp.ToString() + "/" + maxAp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
