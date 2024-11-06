using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class uniteClick : MonoBehaviour
{

    public GameObject Player;
    public GameObject Enemy;
    [SerializeField] Text PUnit;
    [SerializeField] Text PUnite_state;
    [SerializeField] Text EUnit;
    [SerializeField] Text EUnite_state;

    public GameObject Pcas;
    public GameObject Pcas2;
    public GameObject Pinf;
    public GameObject Parc;
    public GameObject Pcat;
    public GameObject Pinfsta;
    public GameObject Parcsta;
    public GameObject Pcatsta;

    public GameObject Ecas;
    public GameObject Ecas2;
    public GameObject Einf;
    public GameObject Earc;
    public GameObject Ecat;
    public GameObject Einfsta;
    public GameObject Earcsta;
    public GameObject Ecatsta;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //ユニットの情報をテキストに表示
    public void Punite_Serect(GameObject unit, int hp)
    {
        Player.SetActive(true);
        Pcas.SetActive(false);
        Pcas2.SetActive(false);
        Pinf.SetActive(true);
        Parc.SetActive(true);
        Pcat.SetActive(true);
        Pinfsta.SetActive(false);
        Parcsta.SetActive(false);
        Pcatsta.SetActive(false);
        switch (unit.name)
        {
            case "Pinfantry(Clone)":
                PUnit.text = "歩兵";
                break;
            case "Parcher(Clone)":
                PUnit.text = "弓兵";
                break;
            case "Pcatapalt(Clone)":
                PUnit.text = "カタパルト";
                break;
        }
        PUnite_state.text = "HP：" + hp;
    }

    public void Eunite_Serect(GameObject unit, int hp)
    {
        Enemy.SetActive(true);
        Ecas.SetActive(false);
        Ecas2.SetActive(false);
        Einf.SetActive(true);
        Earc.SetActive(true);
        Ecat.SetActive(true);
        Einfsta.SetActive(false);
        Earcsta.SetActive(false);
        Ecatsta.SetActive(false);
        switch (unit.name)
        {
            case "Einfantry(Clone)":
                EUnit.text = "歩兵";
                break;
            case "Earcher(Clone)":
                EUnit.text = "弓兵";
                break;
            case "Ecatapalt(Clone)":
                EUnit.text = "カタパルト";
                break;
        }
        EUnite_state.text = "HP：" + hp;
    }

    //ユニットの情報を消す
    public void PDlete()
    {
        Player.SetActive(false);
        Pcas.SetActive(true);
    }

    public void EDlete()
    {
        Enemy.SetActive(false);
        Ecas.SetActive(true);
    }
}
