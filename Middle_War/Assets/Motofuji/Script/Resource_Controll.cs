using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Controll : MonoBehaviour
{
    public bool OnResource;
    int troughturn;
    int troughtime;

    GameObject cmobj;
    CreateMap CM;

    int ap;
    int re;

    // Start is called before the first frame update
    void Start()
    {
        troughturn = 0;
        troughtime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (troughturn == 0)
        {
            OnResource = true;
        }
        else
        {
            OnResource = false;
        }
    }

    public void PGetResource()
    {
        if(OnResource)
        {
            troughturn = troughtime;
            cmobj = GameObject.Find("map");
            CM = cmobj.GetComponent<CreateMap>();
            ap = CM.Now_PAP;
            re = CM.Now_PResource + 5;
            CM.PChange_REAP(ap, re);
        }
    }

    public void EGetResource()
    {
        if (OnResource)
        {
            troughturn = troughtime;
            cmobj = GameObject.Find("map");
            CM = cmobj.GetComponent<CreateMap>();
            ap = CM.Now_EAP;
            re = CM.Now_EResource + 5;
            CM.EChange_REAP(ap, re);
        }
    }

    public void GetTurn()
    {
        troughturn--;
        if(troughturn <= 0)
        {
            troughturn = 0;
        }
    }
}
