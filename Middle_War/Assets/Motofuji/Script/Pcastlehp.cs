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
        if (Now_Hp == 0)
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
    }

    public void HitAttack(int hit)
    {
        CastleHitAudioSound.Play();
        Now_Hp -= hit;
        HP_TEXT.text = Now_Hp.ToString() + "/" + Max_Hp.ToString();
    }
}
