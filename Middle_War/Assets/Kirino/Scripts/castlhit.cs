using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class castlhit : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g���錾�E�֐��錾
    public int maxHealth = 35;  // �ő�HP
    private int currentHealth = 35;  // ���݂�HP
    public Text healthText;  // HP�\���p�̃e�L�X�g(UI)

    public GameObject mainText;//image��ŉ摜�\��
    public Sprite gameOverSpr;
    public GameObject panel;
    public GameObject restartBotton;
    public GameObject nextBotton;

    //���݂̓e�L�X�g�@���Ƃŉ摜�ɕύX����
    Text titleText;//�e�L�X�g�ݒ�
    void Start()
    {
        // ���݂�HP���ő�HP�ŏ�����
        currentHealth = maxHealth;
        UpdateHealthUI();

        //�摜���\���ɂ���i���݃e�L�X�g�\�����j
        Invoke("InactiveText", 1.0f);
        // �{�^���A�p�l�����\���ɂ���
        panel.SetActive(false);
    }

    // �_���[�W���󂯂�֐�
    public void TakeDamage(int damage)//HP�ύX
    {
        currentHealth -= damage;

        // HP��0�����ɂȂ�Ȃ��悤�ɂ���
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthUI();

        // HP��0�ɂȂ�����Q�[���I�[�o�[����
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    // HP�̕\�����X�V����֐�
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Base HP: " + currentHealth.ToString();//HP�Ǘ�
        }
    }

    // �Q�[���I�[�o�[����
    void GameOver()
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