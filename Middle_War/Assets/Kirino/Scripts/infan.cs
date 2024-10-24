using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infan : MonoBehaviour
{
    public GameObject castlevalue;
    public GameObject infantrystatus;
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
        infantrystatus.SetActive(true);
    }
}