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

    // �摜���\���ɂ���
    void InactiveText()
    {
        mainText.SetActive(false);
    }
}
