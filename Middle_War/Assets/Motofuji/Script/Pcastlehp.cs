using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pcastlehp : MonoBehaviour
{
    [SerializeField] Text HP_TEXT;
    int Max_Hp;
    int Now_Hp;
    public GameObject mainText;//image��ŉ摜�\��
    public GameObject panel;
    public GameObject nextBotton;

    public AudioSource CastleHitAudioSound;

    //��̍�����ς���G���A
    SpriteRenderer SR;
    [SerializeField] Sprite[] player_castle_image;

    // Start is called before the first frame update
    void Start()
    {
        Max_Hp = 35;
        Now_Hp = 35;
        HP_TEXT.text = Now_Hp.ToString() + "/" + Max_Hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Now_Hp <= 0)
        {
            Debug.Log("Game Over!");
            // �����ɃQ�[���I�[�o�[���̏�����ǉ��i��F�V�[���̃��Z�b�g�⃁�j���[��ʂ̕\���Ȃǁj
            mainText.SetActive(true); //�摜��\������i���݃e�L�X�g��\�����j
            panel.SetActive(true);    //�{�^���i�p�l���j��\������
                                      //NEXT�{�^���𖳌�������
            Button bt = nextBotton.GetComponent<Button>();
            bt.interactable = false;
            //mainText.GetComponent<Text>().sprite = gameOverSpr; //�摜��ݒ肷��
        }

        if (SR == null)
        {

            SR = GameObject.Find("castle1(Clone)").GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾
                                                                                  //SR.sprite = enemy_castle_image[2];
        }


        Debug.Log("�����I��");

        switch (Now_Hp / 7)
        {
            case 0:
                SR.sprite = player_castle_image[4];
                break;
            case 1:
                SR.sprite = player_castle_image[3];
                break;
            case 2:
                SR.sprite = player_castle_image[2];
                break;
            case 3:
                SR.sprite = player_castle_image[1];
                break;
            case 4:
                SR.sprite = player_castle_image[0];
                break;
            default:
                SR.sprite = player_castle_image[0];
                break;

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
