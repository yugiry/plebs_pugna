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

    //��̍�����ς���G���A
    SpriteRenderer SR;
    [SerializeField] Sprite[] enemy_castle_image;

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

        if (SR == null)
        {

            SR = GameObject.Find("castle2(Clone)").GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾
                                                                                  //SR.sprite = enemy_castle_image[2];

        }


        Debug.Log("�����I��");

        switch(Now_Hp/7)
        {
            case 0:
                SR.sprite = enemy_castle_image[3];
                break;
            case 1:
                SR.sprite = enemy_castle_image[3];
                break;
            case 2:
                SR.sprite = enemy_castle_image[2];
                break;
            case 3:
                SR.sprite = enemy_castle_image[1];
                break;
            case 4:
                SR.sprite = enemy_castle_image[0];
                break;
            default:
                SR.sprite = enemy_castle_image[0];
                break;

        }
        if(Now_Hp==0)
        {
            SR.sprite = enemy_castle_image[4];
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
