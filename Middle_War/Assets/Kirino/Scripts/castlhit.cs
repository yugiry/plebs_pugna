using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class castlhit : MonoBehaviour
{
    [SerializeField] Text hpText;

    int maxhp = 35;
    float nowhp = 35;

    public GameObject mainText;//image��ŉ摜�\��
    public Sprite gameOverSpr;
    public GameObject panel;
    public GameObject restartBotton;
    public GameObject nextBotton;

    //���݂̓e�L�X�g�@���Ƃŉ摜�ɕύX����
    Text titleText;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();

        //�摜���\���ɂ���i���݃e�L�X�g�\�����j
        Invoke("InactiveText", 1.0f);
        // �{�^���A�p�l�����\���ɂ���
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //if (hpText.text = nowhp.ToString())
        //{
        //    // �Q�[���I�[�o�[
        //    mainText.SetActive(true); //�摜��\������i���݃e�L�X�g��\�����j
        //    panel.SetActive(true);    //�{�^���i�p�l���j��\������
        //    //NEXT�{�^���𖳌�������
        //    Button bt = nextBotton.GetComponent<Button>();
        //    bt.interactable = false;
        //    mainText.GetComponent<Text>().sprite = gameOverSpr; //�摜��ݒ肷��
        //    //castleController.gameState = "gameend";
        //}
        //else if (castleController.gameState == "playing")
        //{
        //    //�Q�[����
        //}

    }
    // �摜���\���ɂ���
    void InactiveText()
    {
        mainText.SetActive(false);
    }
}