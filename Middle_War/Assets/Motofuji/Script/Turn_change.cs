using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_change : MonoBehaviour
{
    public int nowturn;

    public GameObject player_turn;
    public GameObject enemy_turn;

    private GameObject CMobj;
    CreateMap CM;
    private int PAP;
    private int PRE;
    private int EAP;
    private int ERE;

    GameObject[] action;

    // Start is called before the first frame update
    void Start()
    {
        nowturn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(nowturn)
        {
            case 0:
                player_turn.SetActive(true);
                enemy_turn.SetActive(false);
                break;
            case 1:
                player_turn.SetActive(false);
                enemy_turn.SetActive(true);
                break;
        }
    }

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
        //
        CMobj = GameObject.Find("map");
        CM = CMobj.GetComponent<CreateMap>();
        EAP = CM.Now_EAP;
        ERE = CM.Now_EResource;
        EAP += 5;
        CM.EChange_REAP(EAP, ERE);
    }

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
    }
}
