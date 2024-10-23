using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject castlevalue;
    public GameObject castlevalue2;
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
        castlevalue.SetActive(false);
        castlevalue2.SetActive(true);
    }
}
