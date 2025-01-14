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
    int APpuls;

    GameObject[] action;

    GameObject[] uo;
    GameObject[] euo;

    Unit_Operation UO;
    EUnit_Operation EUO;

    GameObject[] unitobj;
    Show_Attack_Range NR;
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
        APpuls = 0;
        CMobj = GameObject.Find("map");
        CM = CMobj.GetComponent<CreateMap>();
        ccobj = GameObject.Find("CPU");
        CC = ccobj.GetComponent<CPU_Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�^�[�����G�l�~�[�ɓn��
    public void ChangeTurn_Player()
    {
        nowturn = 1;
        //�v���C���[���̃��j�b�g�̍s�������ׂĔ�A�N�e�B�u�ɂ���
        action = GameObject.FindGameObjectsWithTag("act");
        foreach (GameObject act in action)
        {
            Debug.Log("act�^�O���������I�u�W�F�N�g���F" + act.name);
            act.SetActive(false);
        }
        //�v���C���[���̃��j�b�g�̈ړ��͈͂ƍU���͈͂̕\��������
        unitobj = GameObject.FindGameObjectsWithTag("unit");
        foreach (GameObject unit in unitobj)
        {
            NR = unit.GetComponent<Show_Attack_Range>();
            SMR = unit.GetComponent<Show_Move_Range>();
            NR.Destroy_Range();
            SMR.Destroy_Move_Range();
        }
        //�G�l�~�[��AP��ǉ�����
        EAP = CM.Now_EAP;
        ERE = CM.Now_EResource;
        EAP += 5;
        CM.EChange_REAP(EAP, ERE);
        //�}�b�v���S�Ă̎����̉���s���Ԃ��P���炷
        rcobj = GameObject.FindGameObjectsWithTag("resource");
        foreach (GameObject tmp in rcobj)
        {
            RC = tmp.GetComponent<Resource_Controll>();
            RC.GetTurn();
        }
        //�G�l�~�[���̃��j�b�g�̍U����S�ĉ\�ɂ���
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
        CC.Turn_Here();
    }

    //�^�[�����v���C���[�ɓn��
    public void ChangeTurn_Enemy()
    {
        nowturn = 0;
        //�G�l�~�[���̃��j�b�g�̍s�������ׂĔ�A�N�e�B�u�ɂ���
        action = GameObject.FindGameObjectsWithTag("Eact");
        foreach (GameObject act in action)
        {
            Debug.Log("act�^�O���������I�u�W�F�N�g���F" + act.name);
            act.SetActive(false);
        }
        //�v���C���[��AP��ǉ�����
        PAP = CM.Now_PAP;
        PRE = CM.Now_PResource;
        PAP += 5 + 5 * APpuls;
        CM.PChange_REAP(PAP, PRE);
        //�}�b�v���S�Ă̎����̉���s���Ԃ��P���炷
        rcobj = GameObject.FindGameObjectsWithTag("resource");
        foreach (GameObject tmp in rcobj)
        {
            RC = tmp.GetComponent<Resource_Controll>();
            RC.GetTurn();
        }
        //�v���C���[���̃��j�b�g�̍U����S�ĉ\�ɂ���
        uo = GameObject.FindGameObjectsWithTag("unit");
        foreach (GameObject gobj in uo)
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

    //�v���C���[���������������
    public void Enhance_AP()
    {
        PAP = CM.Now_PAP;
        PRE = CM.Now_PResource;
        PRE -= 50;
        if (PRE >= 0)
        {
            APpuls++;
            if (APpuls >= 5)
            {
                APpuls = 5;
            }
            CM.PChange_REAP(PAP, PRE);
        }
    }
}
