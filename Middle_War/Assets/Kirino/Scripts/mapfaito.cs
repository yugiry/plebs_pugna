using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(AudioSource))]
public class mapfaito : MonoBehaviour
{
    public int countrynum;//�Q�[���I�u�W�F�N�g�E�֐��錾
    public GameObject mapbatoru;
    [SerializeField] public Text text1;//�P�ڂ̃e�L�X�g�ϊ�
    [SerializeField] public Text text2;//�Q�ڂ̃e�L�X�g�ϊ�
    public Image image; //�摜�\��
    public GameObject Button;//�G�Ƃ̃o�g���{�^��
    public Sprite[] newSprite;//�摜�\���ǉ�
    public string NextScene;
    GameObject rcnobj;
    remenber_country_num RCN;

    private void Awake()
    {
        rcnobj = GameObject.Find("country_info");
        RCN = rcnobj.GetComponent<remenber_country_num>();
    }
   
    public void Show_country(int countrynum)
    { //mapClick����󂯎�����l��ǂݎ��

        image.sprite = newSprite[countrynum - 1]; //�摜�\��

        switch (countrynum) //�󂯎�����l�ʏ���
        {
            case 1:
                text1.text = "����"; //����
                text2.text = "�ǂ�ǂ�G�����U�ߗ̓y���g�����ēV�������ڎw�����I�I"; //������
                Button.SetActive(false); //�{�^���\���i�����̓{�^���\�����Ȃ��j
                mapbatoru.transform.position = new Vector3(0, 0, 50); //�����{�[�h�\���ʒu
                RCN.country_num = countrynum;
                break;
            case 2:
                text1.text = "�t�X����"; //����
                text2.text = "�ł����΂���̍��ō����̌��͂��Ⴍ�U�ߓ���₷���I"; //������            
                Button.SetActive(true); //�G���̓{�^���\������
                mapbatoru.transform.position = new Vector3(0, 0, 50); //�����{�[�h�\���ʒu
                RCN.country_num = countrynum;
                break;
            case 3:
                text1.text = "�A�E�^�C��"; //����
                text2.text = "�ł����΂���ł͂Ȃ��������̂܂Ƃ܂肪�Ȃ����܂蔭�W���Ă��Ȃ��I"; //������             
                Button.SetActive(true); //�G���̓{�^���\������
                mapbatoru.transform.position = new Vector3(0, 0, 50); //�����{�[�h�\���ʒu
                RCN.country_num = countrynum;
                break;
            case 4:
                text1.text = "�A�C�ׂ蔼��"; //����
                text2.text = "�������W���Ă��菙�X�ɏ@�����L�܂��Ă���!!�i�@����ligare�j"; //������          
                Button.SetActive(true); //�G���̓{�^���\������
                mapbatoru.transform.position = new Vector3(0, 0, 50); //�����{�[�h�\���ʒu
                RCN.country_num = countrynum;
                break;
            case 5:
                text1.text = "�A�x�`�l";
                text2.text = "�����̂͋��������Ƃ�����ł����ȍ��Ǝ�����Ă���B";
                Button.SetActive(true); //�G���̓{�^���\������
                mapbatoru.transform.position = new Vector3(0, 0, 50); //�����{�[�h�\���ʒu
                RCN.country_num = countrynum;
                break;
            case 6:
                text1.text = "�i�N�E�C��";
                text2.text = "�ǂ̍�������_���₷�����A�U�߂��炢�B";
                Button.SetActive(true); //�G���̓{�^���\������
                mapbatoru.transform.position = new Vector3(0, 0, 50); //�����{�[�h�\���ʒu
                RCN.country_num = countrynum;
                break;
            case 7:
                text1.text = "�A�u���K��";
                text2.text = "�A�C�ׂ蔼���ƑΗ����Ă��菭�������K�������i�s���Ă���B";
                Button.SetActive(true); //�G���̓{�^���\������
                mapbatoru.transform.position = new Vector3(0, 0, 50); //�����{�[�h�\���ʒu
                RCN.country_num = countrynum;
                break;
            default:
                Debug.Log("Default"); //switch�����̍Ō�
                break;
        }
    }

    public void change_button()//�{�^���ύX
    {
        SceneManager.LoadScene(NextScene);//�{�^���������ꂽ���V�[����ς���
    }
}