using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ecastlehp : MonoBehaviour
{
    [SerializeField] Text HP_TEXT;
    int Max_Hp;
    int Now_Hp;

    public GameObject mainText;//image��ŉ摜�\��
    public GameObject panel;
    public GameObject restartBotton;
    public AudioSource CastleHitAudioSound;

    GameObject country_num;
    remenber_country_num RCN;
    GameObject remenber_falg;
    clear_flag_operation CFO;

    // Start is called before the first frame update
    void Start()
    {
        //���HP��������
        Max_Hp = 35;
        Now_Hp = 35;
        HP_TEXT.text = Now_Hp.ToString() + "/" + Max_Hp.ToString();
        country_num = GameObject.Find("country_info");
        RCN = country_num.GetComponent<remenber_country_num>();
        remenber_falg = GameObject.Find("remenber_clear_flag");
        CFO = remenber_falg.GetComponent<clear_flag_operation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Now_Hp <= 0)
        {
            Debug.Log("Game Clear!");
            CFO.clear_flag[RCN.country_num - 1] = true;
            // �����ɃQ�[���I�[�o�[���̏�����ǉ��i��F�V�[���̃��Z�b�g�⃁�j���[��ʂ̕\���Ȃǁj
            mainText.SetActive(true); //�摜��\������i���݃e�L�X�g��\�����j
            panel.SetActive(true);    //�{�^���i�p�l���j��\������
                                      //NEXT�{�^���𖳌�������
            Button bt = restartBotton.GetComponent<Button>();
            bt.interactable = false;
            //mainText.GetComponent<Text>().sprite = gameOverSpr; //�摜��ݒ肷��
        }
    }

    public void HitAttack(int hit)
    {
        CastleHitAudioSound.Play();
        Now_Hp -= hit;
        if (Now_Hp < 0) Now_Hp = 0;
        HP_TEXT.text = Now_Hp.ToString() + "/" + Max_Hp.ToString();
    }
}
