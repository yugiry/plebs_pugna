using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clearover : MonoBehaviour
{
    public GameObject mainText;//image��ŉ摜�\��
    public Sprite gameOverSpr;
    public Sprite gameClearSpr;
    public GameObject panel;
    public GameObject restartBotton;
    public GameObject nextBotton;
    //���݂̓e�L�X�g�@���Ƃŉ摜�ɕύX����
    Text titleText;

    // Start is called before the first frame update
    void Start()
    {
        //�摜���\���ɂ���i���݃e�L�X�g�\�����j
        Invoke("InactiveText", 1.0f);
        // �{�^���A�p�l�����\���ɂ���
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (PlayerController.gameState == "gameclear")
        //{
        //    //�Q�[���N���A
        //    mainText.SetActive(true); //�摜��\������i���݃e�L�X�g��\�����j
        //    panel.SetActive(true);    //�{�^���i�p�l���j��\������
        //    //RESTRT�{�^���𖳌�������
        //    Button bu = restartBotton.GetComponent<Button>();
        //    bt.interactable = false;
        //    mainText.GetComponent<Text>().sprite = gameClearSpr; //�摜��ݒ肷��
        //    PlayerController.gameState = "gameend";
        //}
        //else if (PlayerController.gameState == "gameover")
        //{
        //    // �Q�[���I�[�o�[
        //    mainText.SetActive(true); //�摜��\������i���݃e�L�X�g��\�����j
        //    panel.SetActive(true);    //�{�^���i�p�l���j��\������
        //    //NEXT�{�^���𖳌�������
        //    Button bt = nextBotton.GetComponent<Button>();
        //    bt.interactable = false;
        //    mainText.GetComponent<Text>().sprite = gameOverSpr; //�摜��ݒ肷��
        //    PlayerController.gameState = "gameend";
        //}
        //else if (PlayerController.gameState == "playing")
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
