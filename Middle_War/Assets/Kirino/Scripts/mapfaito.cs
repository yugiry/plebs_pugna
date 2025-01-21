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
    public GameObject Map_Batoru;

    [SerializeField] public Text[] text;//�e�L�X�g�ϊ�

    public Image image; //�摜�\��
    public GameObject Button;//�G�Ƃ̃o�g���{�^��
    public Sprite[] newSprite;//�摜�\���ŐV�����}�b�v��ǉ��������ł��ȒP�ɕ\���ł���B
    public string NextScene;//�ϐ��𕶎��ɕς��邱�Ƃłǂ��ł��V�[���̖��O��ύX����΂����ɈႤ�V�[���Ɉړ��ł���B

    //RCN�̋�OBJECT
    GameObject RCNobj;

    //remenber_country_num �� = RCN 
    //�ʃX�N���v�g
    remenber_country_num RCN;

    //�Ăяo���֐�
    //�����@�@start�������Awaek���Ă΂��A�N�e�B�u��Ԃɂ��Ă��Ă�Awake���\�b�h�͌Ă΂��
    //�Q�[��(�G�Ƃ̃o�g�����I�������)
    private void Awake()
    {
        RCNobj = GameObject.Find("country_info");
        RCN = RCNobj.GetComponent<remenber_country_num>();
    }

    //mapClick����󂯎�����l��ǂݎ��
    public void Country_Num(int Country_Num)
    { 
        image.sprite = newSprite[Country_Num - 1]; //�摜�\��

        RCN.country_num = Country_Num;

        Button.SetActive(true); //�G���̓{�^���\������

        switch (Country_Num) //�󂯎�����l�ʃe�L�X�g����
        {
            case 1:
                text[0].text = NameMneger.name+"�̍�"; //����
                text[1].text = "�ǂ�ǂ�G�����U��\n�̓y���g����\n�V�������ڎw�����I"; //������
                Button.SetActive(false); //�{�^���\���i�����̓{�^���\�����Ȃ��j
                break;
            case 2:
                text[0].text = "�t�X����"; //����
                text[1].text = "�ł����΂���̍���\n�����̌��͂��キ\n�U�ߓ���₷��"; //������
                break;
            case 3:
                text[0].text = "�A�E�^�C��"; //����
                text[1].text = "�����O�ɂł���������\n�����̂܂Ƃ܂肪�Ȃ�\n���܂蔭�W���Ă��Ȃ�"; //������        
                break;
            case 4:
                text[0].text = "�A�C�ׂ蔼��"; //����
                text[1].text = "�������W���Ă���\n���X�ɏ@�����L�܂�\n�����̂܂Ƃ܂肪����"; //������     
                break;
            case 5:
                text[0].text = "�A�x�`�l"; //����
                text[1].text = "�����̂͋��������Ƃ�\n����ł����ȍ���\n������Ă���"; //������
                break;
            case 6:
                text[0].text = "�i�N�E�C��"; //����
                text[1].text = "�����ɑ_���₷����\n�n�`������g��ł���\n�U�߂��炢��"; //������
                break;
            case 7:
                text[0].text = "�A�u���K��"; //����
                text[1].text = "�A�C�x�������ƑΗ�\n���Ă���@�������X��\n�i�s���Ă��Ă���"; //������
                break;
            default:
                Debug.Log("Default"); //switch�����m�F�p���O
                break;
        }
    }
    public void Change_Button()//�{�^���ύX
    {
        SceneManager.LoadScene(NextScene);//�{�^���������ꂽ���V�[����ς���
    }
}