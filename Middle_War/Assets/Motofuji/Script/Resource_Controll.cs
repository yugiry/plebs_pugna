using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource_Controll : MonoBehaviour
{
    public Sprite RS1;
    public Sprite RS2;
    public SpriteRenderer RI;
    public bool OnResource;
    int troughturn;
    int troughtime;

    GameObject cmobj;
    CreateMap CM;

    GameObject GetResourceSE;
    AudioSource GRS;

    int ap;
    int re;

    // Start is called before the first frame update
    void Start()
    {
        troughturn = 0;
        troughtime = 5;
        RI = this.GetComponent<SpriteRenderer>();
        GetResourceSE = GameObject.Find("");
    }

    // Update is called once per frame
    void Update()
    {
        //5��^�[�����߂����玑�����̂���Ԃɂ���
        if (troughturn == 0)
        {
            OnResource = true;
            RI.sprite = RS1;
        }
        else
        {
            OnResource = false;
        }
    }

    public void PGetResource()
    {
        //�������̂���ԂȂ�
        if(OnResource)
        {
            //�������̂�Ȃ���Ԃɂ���
            troughturn = troughtime;
            cmobj = GameObject.Find("map");
            CM = cmobj.GetComponent<CreateMap>();
            ap = CM.Now_PAP;
            re = CM.Now_PResource + 5;
            //����ȏ�͂Ȃ��������Ƃɂ���
            if(re >= 999)
            {
                re = 999;
            }
            CM.Character(ap, re, 0);
            RI.sprite = RS2;
        }
    }

    public void EGetResource()
    {
        //�������̂���ԂȂ�
        if (OnResource)
        {
            //�������̂�Ȃ���Ԃɂ���
            troughturn = troughtime;
            cmobj = GameObject.Find("map");
            CM = cmobj.GetComponent<CreateMap>();
            ap = CM.Now_EAP;
            re = CM.Now_EResource + 5;
            //����ȏ�͂Ȃ��������Ƃ�
            if(re >= 999)
            {
                re = 999;
            }
            CM.Character(ap, re, 1);
            RI.sprite = RS2;
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
