using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CPU_Controller : PlayerUnit_Base
{
    bool nowturn;
    bool map_complete;
    bool can_summon;

    [SerializeField] GameObject infantry;
    [SerializeField] GameObject archer;
    [SerializeField] GameObject catapalt;

    [SerializeField] GameObject unitbox;
    GameObject Sunit;

    [SerializeField] GameObject tilebox;
    Transform castle;

    [NonSerialized] EUnit_Operation IEUO;
    [NonSerialized] EUnit_Operation AEUO;
    [NonSerialized] EUnit_Operation CEUO;

    public UI_Operate UIO;
    int urd;//ユニットの出す種類のランダム
    int ard;//エリアのどこに出すかのランダム
    int atrd;//CPUがユニットにする行動のランダム
    int summon_or_action;//ユニットを召喚するか行動させるか

    float summon_x, summon_y;
    int unit_move_ap;

    // Start is called before the first frame update
    void Start()
    {
        map_complete = false;
        can_summon = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(map_complete)
        {
            castle = tilebox.transform.Find("castle2(Clone)");
            map_complete = false;
        }

        if(nowturn)
        {
            if (UIO.EUnit_Num == 0)
            {
                if (can_summon)
                {
                    Debug.Log("ユニット無し");
                    Unit_Summon();
                }
            }
            else
            {
                Debug.Log("ユニット在り");
                summon_or_action = UnityEngine.Random.Range(0, 4);
                switch(summon_or_action)
                {
                    case 0:
                        Unit_Summon();
                        break;
                    case 1:
                    case 2:
                    case 3:
                        Random_Action();
                        break;
                }
            }
        }
    }

    public void UnitNumChange()
    {
        can_summon = true;
    }

    public void Map_Collect()
    {
        map_complete = true;
    }

    public void Turn_Here()
    {
        nowturn = true;
        IEUO = infantry.GetComponent<EUnit_Operation>();
        AEUO = archer.GetComponent<EUnit_Operation>();
        CEUO = catapalt.GetComponent<EUnit_Operation>();
    }

    //移動、強化、攻撃からランダムで一つ行動する
    void Random_Action()
    {
        atrd = UnityEngine.Random.Range(0, 3);
        switch(atrd)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }

    //ユニット召喚
    void Unit_Summon()
    {
        urd = UnityEngine.Random.Range(0, 3);
        ard = UnityEngine.Random.Range(0, 8);

        

        switch(ard)
        {
            case 0:
                summon_x = -1;
                summon_y = -1;
                break;
            case 1:
                summon_x = 0;
                summon_y = -1;
                break;
            case 2:
                summon_x = 1;
                summon_y = -1;
                break;
            case 3:
                summon_x = -1;
                summon_y = 0;
                break;
            case 4:
                summon_x = 1;
                summon_y = 0;
                break;
            case 5:
                summon_x = -1;
                summon_y = 1;
                break;
            case 6:
                summon_x = 0;
                summon_y = 1;
                break;
            case 7:
                summon_x = 1;
                summon_y = 1;
                break;
        }

        cmobj = GameObject.Find("map");
        CM = cmobj.GetComponent<CreateMap>();
        apnum = CM.Now_EAP;
        renum = CM.Now_EResource;
        switch (urd)
        {
            case 0://歩兵召喚
                apnum = apnum - IEUO.move_ap;
                if (apnum >= 0)
                {
                    Sunit = Instantiate(infantry, new Vector3(castle.position.x + (summon_x * (TILESIZE_X + TILESPACE)), castle.position.y + (summon_y * (TILESIZE_Y + TILESPACE)), 14.0f), Quaternion.identity);
                    CM.EChange_REAP(apnum, renum);
                }
                break;
            case 1://弓兵召喚
                apnum = apnum - AEUO.move_ap;
                if (apnum >= 0)
                {
                    Sunit = Instantiate(archer, new Vector3(castle.position.x + (summon_x * (TILESIZE_X + TILESPACE)), castle.position.y + (summon_y * (TILESIZE_Y + TILESPACE)), 14.0f), Quaternion.identity);
                    CM.EChange_REAP(apnum, renum);
                }
                break;
            case 2://カタパルト召喚
                apnum = apnum - CEUO.move_ap;
                if (apnum >= 0)
                {
                    Sunit = Instantiate(catapalt, new Vector3(castle.position.x + (summon_x * (TILESIZE_X + TILESPACE)), castle.position.y + (summon_y * (TILESIZE_Y + TILESPACE)), 14.0f), Quaternion.identity);
                    CM.EChange_REAP(apnum, renum);
                }
                break;
        }
        Sunit.transform.parent = unitbox.transform;

        can_summon = false;
    }
}
