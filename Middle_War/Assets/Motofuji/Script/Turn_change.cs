using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turn_change : MonoBehaviour
{
    public int nowturn;

    GameObject ccobj;
    CPU_Controller CC;

    public GameObject noclick_tile;
    public GameObject player_turn;
    public GameObject enemy_turn;

    GameObject[] rcobj;
    Resource_Controll RC;

    private GameObject CMobj;
    CreateMap CM;
    private int PAP;
    private int PRE;
    private int EAP;
    private int ERE;

    GameObject[] action;

    GameObject[] uo;
    GameObject[] euo;

    Unit_Operation UO;
    EUnit_Operation EUO;

    GameObject[] unitobj;
    New_range_hyouji NR;
    Show_Move_Range SMR;

    public GameObject Pcas;
    public GameObject Pcas2;
    public GameObject Pinf;
    public GameObject Parc;
    public GameObject Pcat;
    public GameObject Pinfsta;
    public GameObject Parcsta;
    public GameObject Pcatsta;
    public GameObject Psta;

    public GameObject Ecas;
    public GameObject Ecas2;
    public GameObject Einf;
    public GameObject Earc;
    public GameObject Ecat;
    public GameObject Einfsta;
    public GameObject Earcsta;
    public GameObject Ecatsta;
    public GameObject Esta;
    

    // Start is called before the first frame update
    void Start()
    {
        nowturn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ターンをエネミーに渡す
    public void ChangeTurn_Player()
    {
        nowturn = 1;
        //プレイヤー側のユニットの行動をすべて非アクティブにする
        action = GameObject.FindGameObjectsWithTag("act");
        foreach (GameObject act in action)
        {
            Debug.Log("actタグを持ったオブジェクト名：" + act.name);
            act.SetActive(false);
        }
        unitobj = GameObject.FindGameObjectsWithTag("unit");
        foreach (GameObject unit in unitobj)
        {
            NR = unit.GetComponent<New_range_hyouji>();
            SMR = unit.GetComponent<Show_Move_Range>();
            NR.Destroy_Range();
            SMR.Destroy_Move_Range();
        }
        //
        CMobj = GameObject.Find("map");
        CM = CMobj.GetComponent<CreateMap>();
        EAP = CM.Now_EAP;
        ERE = CM.Now_EResource;
        EAP += 5;
        CM.EChange_REAP(EAP, ERE);
        rcobj = GameObject.FindGameObjectsWithTag("resource");
        foreach (GameObject tmp in rcobj)
        {
            RC = tmp.GetComponent<Resource_Controll>();
            RC.GetTurn();
        }
        euo = GameObject.FindGameObjectsWithTag("Eunit");
        foreach (GameObject gobj in euo)
        {
            EUO = gobj.GetComponent<EUnit_Operation>();
            EUO.SetAttackCnt();
        }
        player_turn.SetActive(false);
        enemy_turn.SetActive(true);

        Pcas.SetActive(true);
        Pcas2.SetActive(false);
        Pinf.SetActive(true);
        Parc.SetActive(true);
        Pcat.SetActive(true);
        Pinfsta.SetActive(false);
        Parcsta.SetActive(false);
        Pcatsta.SetActive(false);
        Psta.SetActive(false);
        ccobj = GameObject.Find("CPU");
        CC = ccobj.GetComponent<CPU_Controller>();
        CC.Turn_Here();
    }

    //ターンをプレイヤーに渡す
    public void ChangeTurn_Enemy()
    {
        nowturn = 0;
        //エネミー側のユニットの行動をすべて非アクティブにする
        action = GameObject.FindGameObjectsWithTag("Eact");
        foreach (GameObject act in action)
        {
            Debug.Log("actタグを持ったオブジェクト名：" + act.name);
            act.SetActive(false);
        }
        //
        CMobj = GameObject.Find("map");
        CM = CMobj.GetComponent<CreateMap>();
        PAP = CM.Now_PAP;
        PRE = CM.Now_PResource;
        PAP += 5;
        CM.PChange_REAP(PAP, PRE);
        rcobj = GameObject.FindGameObjectsWithTag("resource");
        foreach (GameObject tmp in rcobj)
        {
            RC = tmp.GetComponent<Resource_Controll>();
            RC.GetTurn();
        }
        uo = GameObject.FindGameObjectsWithTag("unit");
        foreach(GameObject gobj in uo)
        {
            UO = gobj.GetComponent<Unit_Operation>();
            UO.SetAttackCnt();
        }
        player_turn.SetActive(true);
        enemy_turn.SetActive(false);

        Ecas.SetActive(true);
        Ecas2.SetActive(false);
        Einf.SetActive(true);
        Earc.SetActive(true);
        Ecat.SetActive(true);
        Einfsta.SetActive(false);
        Earcsta.SetActive(false);
        Ecatsta.SetActive(false);
        Esta.SetActive(false);
    }

    private void PNot_Click()
    {
        action = GameObject.FindGameObjectsWithTag("noclick");
        foreach (GameObject act in action)
        {
            Destroy(act);
        }
        action = GameObject.FindGameObjectsWithTag("unit");
        foreach (GameObject act in action)
        {
            Instantiate(noclick_tile, new Vector3(act.transform.position.x, act.transform.position.y, act.transform.position.z - 1), Quaternion.identity);
        }
    }

    private void ENot_Click()
    {
        action = GameObject.FindGameObjectsWithTag("noclick");
        foreach (GameObject act in action)
        {
            Destroy(act);
        }
        action = GameObject.FindGameObjectsWithTag("Eunit");
        foreach (GameObject act in action)
        {
            Instantiate(noclick_tile, new Vector3(act.transform.position.x, act.transform.position.y, act.transform.position.z - 1), Quaternion.identity);
        }
    }
}
