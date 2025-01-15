using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Switch : MonoBehaviour
{
    public int text_num;
    private Text my_text;

    GameObject button;

    SpriteRenderer SR;

    [field: SerializeField] public int text_num_num { get; set; }
   
     [field: SerializeField]
    public int all_image
    { get; set; }
    
     [field: SerializeField]
    public int what_number_image
    {
        get; set;
    }

    public Sprite[] next_image;

    [SerializeField] GameObject Next;
    [SerializeField] GameObject Back;
    
    public Transform parent;

    button_color_change BCC;

    [SerializeField] GameObject Blind;

    public AudioClip enter;
    private AudioSource audiosouse;

    void Start()
    {
        my_text = GameObject.Find("explanation").GetComponent<Text>();//�V�[������text�I�u�W�F�N�g���擾
        my_text.color = new Color(1.0f, 1.0f, 1.0f);

        Destroy_Next();//���փ{�^�����\��
        Destroy_Back();//�߂�{�^�����\��

    } 
    void Summon_Next()
    {
        Vector3 pos = parent.transform.localPosition;         //�N���b�N���ꂽ�{�^���̈ʒu���
        Next = parent.transform.Find("Next_Core").gameObject; //�e�I�u�W�F�N�g���擾
        Next.SetActive(true);                                 //���փ{�^����\��
        Next.transform.position = new Vector3( 60, -51, 0.0f);//���փ{�^���̈ʒu��ύX

    }
    void Summon_Back()
    {
        Vector3 pos = parent.transform.localPosition;        //�N���b�N���ꂽ�{�^���̈ʒu���
        Back = parent.transform.Find("Back_Core").gameObject;//�e�I�u�W�F�N�g���擾
        Back.SetActive(true);                                //�߂�{�^����\��
        Back.transform.position = new Vector3( 0, -51, 0.0f);//�߂�{�^���̈ʒu��ύX

    }
    
    void Destroy_Next()
    {
        GameObject[] click_next = GameObject.FindGameObjectsWithTag("Next");//Next�^�O�������S�ẴI�u�W�F�N�g���擾

            foreach (GameObject next_child in click_next)
            {
            
            next_child.SetActive(false);                                   //Next�^�O�������S�ẴI�u�W�F�N�g���\���ɂ���

            }       
        
    }

    void Destroy_Back()
    {
        GameObject[] click_back = GameObject.FindGameObjectsWithTag("Back");//Back�^�O�������S�ẴI�u�W�F�N�g���擾

        foreach (GameObject back_child in click_back)
            {
            
            back_child.SetActive(false);                                   //Back�^�O�������S�ẴI�u�W�F�N�g���\���ɂ���
        }
        
    }

    void Storage_Blind()
    {
        GameObject[] _blind = GameObject.FindGameObjectsWithTag("Blind");//Blind�^�O�������S�ẴI�u�W�F�N�g���擾

        foreach (GameObject blind_child in _blind)
        {
            
            blind_child.SetActive(false);                                   //Blind�^�O�������S�ẴI�u�W�F�N�g���\���ɂ���
        }

    }

    void Summon_Blind()
    {
        Vector3 pos = parent.transform.localPosition;//�N���b�N���ꂽ���j�b�g�̈ʒu���
        Blind = parent.transform.Find("Blind_Core").gameObject;//�e�I�u�W�F�N�g���擾
        Blind.SetActive(true);//�I�u�W�F�N�g��\��

    }

    public void Swith_Over_Image()
    {
        audiosouse = this.gameObject.GetComponent<AudioSource>(); //�I�[�f�B�I�\�[�X�擾

        audiosouse.PlayOneShot(enter);//���ʉ����Đ�����
        text_num_num = 0;
        Text_Rewrite();//text���̕��͂�����������

       Storage_Blind();//�I�u�W�F�N�g���\��
        Summon_Blind();//�I�u�W�F�N�g��\��
       
        Destroy_Next();//���փ{�^�����\��
        Destroy_Back();//�߂�{�^�����\��
      
        text_num_num = 0;

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾

        what_number_image = 0;
                
        SR.sprite = next_image[what_number_image];//�����ɉ������摜��\������

        if(all_image>1)//�摜�̑�����1���傫���Ȃ�
        {
            Summon_Next(); //���փ{�^����\��
            Destroy_Back();//�߂�{�^�����\��
        }
        else
        {
            Destroy_Next();//���փ{�^�����\��
            Destroy_Back();//�߂�{�^�����\��
        }

    }

    public void display_next()
    {
        audiosouse.PlayOneShot(enter);//���ʉ����Đ�����

        text_num_num++;//���₷

        Text_Rewrite();               //text���̕��͂�����������

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾

        what_number_image++;

        if (what_number_image == all_image - 1)//���݂̉摜�ԍ����摜�����Ɠ����l�Ȃ��
        {
            what_number_image = all_image - 1;//���̒l�ɌŒ肷��
            
            
            SR.sprite = next_image[what_number_image];//�������摜����-1�ɉ������摜��\������

            Destroy_Next();//���փ{�^�����\��
            Summon_Back();//�߂�{�^����\��

        }
        else//�����łȂ��Ȃ灁�摜�����Ɠ��l�łȂ��Ȃ�
        {
      
            SR.sprite = next_image[what_number_image];//���݂̐����ɉ������摜��\������

            Summon_Back();//���փ{�^����\��
        }
  
    }

    public void display_back()
    {
        audiosouse.PlayOneShot(enter);//���ʉ����Đ�����

        text_num_num--;//���炷

        if (text_num_num == 0)//�e�L�X�g�ԍ���0�Ȃ�
        {
            text_num_num = 0;//0�̂܂܂ɂ��Ă���
        }

        Text_Rewrite();//text���̕��͂�����������

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾

        what_number_image--;//���炷

        if (what_number_image == 0)//�摜�ԍ���0�Ȃ�
        {

            what_number_image = 0;//0�̂܂܂ɂ���
           
            SR.sprite = next_image[what_number_image];//������0�ɉ������摜��\������

            Destroy_Back();//�߂�{�^�����\��
            Summon_Next(); //���փ{�^����\��

        }
        else//�����łȂ���0�ȊO�Ȃ�
        {
            
            SR.sprite = next_image[what_number_image];//�����ɉ������摜��\������
            Summon_Next();//���փ{�^����\��

        }

    }

    public void Text_Rewrite()//���͂�����������
    {
        switch (text_num)
        {
            case 0://����
                switch (text_num_num)
                {
                    case 0:
                        my_text.text = "\nUI��ʂɂ��郆�j�b�g�����N���b�N���Ă��玩���̐w�n�����N���b�N����Ə����ł���B\n�������A�����ɕK�v��AP�܂��͎���������Ȃ��Ə����ł��Ȃ��B";
                        break;
                    case 1:
                        my_text.text = "\nUI��ʂɂ��郆�j�b�g�����N���b�N���Ă��玩���̐w�n�����N���b�N����Ə����ł���B\n�������A�����ɕK�v��AP�܂��͎���������Ȃ��Ə����ł��Ȃ��B";
                        break;
                    default:
                        text_num_num = 1;
                        break;
                }
                break;

            case 1://�ړ�
                switch (text_num_num)
                {
                    case 0:
                        my_text.text = "\n�ړ������������j�b�g�����N���b�N���Ă���A���̃��j�b�g�̍s�����������̏㉺���E1�}�X�����N���b�N����Έړ��ł���B\n";
                        break;
                    default:
                        text_num_num = 0;
                        break;
                }
                break;
            case 2://�̎�
                switch (text_num_num)
                {
                    case 0:
                        my_text.text = "\n�t�B�[���h�}�b�v��ɂ��鎑�ނ܂�'����'���ړ������Ă��玑�ނ����N���b�N���邱�Ƃŉ�����ł���B\n";
                        break;
                    default:
                        text_num_num = 0;
                        break;
                }
                break;
            case 3://�U��
                switch (text_num_num)
                {
                    case 0:
                my_text.text = "\n�U�������������j�b�g�����N���b�N���āA�U�����������j�b�g�����N���b�N����΍U�����鎖���ł���B\n";
                        break;
                    case 1:
                        my_text.text = "\n�e���j�b�g�̍U���˒��̓��j�b�g�����N���b�N����Ɗm�F�ł���B\n";
                        break;
                    default:
                        text_num_num = 1;
                        break;
                }
                break;
            case 4://��������
                switch (text_num_num)
                {
                    case 0:
                my_text.text = "\n���R���G�̖{�w��HP��0�ɂ���Ώ����ƂȂ�B\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n����΂�I\n";
                break;
                    default:
                        text_num_num = 0;
                        break;
                }
                break;
            case 5://�s�k����
                switch (text_num_num)
                {
                    case 0:
                        my_text.text = "\n�G�̍U���ɂ����\n���R�̖{�w��HP��0�ɂ����Δs�k�ƂȂ�B\n";
                        break;
                    default:
                        text_num_num = 0;
                        break;
                }
                break;
            case 6://�t�B�[���h���
                switch (text_num_num) {
                    case 0:
                my_text.text = "\n���c�ǂ̃��j�b�g�����ɏ�Q�Ȃ��ړ����邱�Ƃ��ł���B\n�X�A�[�����c�S�Ẵ��j�b�g���ʂ邱�Ƃ��ł��Ȃ��ꏊ�B\n���c�ǂ̃��j�b�g�ł��ʂ邱�Ƃ��ł��邪�ړ����̏���AP�ʂ����ꂼ��1��������B\n";
                        break;
                    case 1:
                        my_text.text = "\n���ށc�J�^�p���g����������ׂɕK�v�Ȃ��́B\n�����ł̂݉�����\�����A�����͈��^�[�����o�߂���܂ōĉ���ł��Ȃ��Ȃ�B\n";
                        break;
                    default:
                        text_num_num = 1;
                        break;
                }
                break;
            case 7://���j�b�g���
                switch (text_num_num)
                {
                    case 0:
                        my_text.text = "\n�����c�ߐڍU�������ł��Ȃ��������ɕK�v��AP�����Ȃ����ނ�������鎖���ł���B��̕��m�B\n";
                        break;
                    case 1:
                        my_text.text = "\n�����c�ߐڍU�������ł��Ȃ��������ɕK�v��AP�����Ȃ����ނ�������鎖���ł���B��̕��m�B\n";
                        break;
                    case 2:
                        my_text.text = "�|���c�������U�����\�ȕ��m�B�̗͂��Ⴍ�����ɕK�v��AP�������B\n";
                        break;
                    case 3:
                        my_text.text = "�|���c�������U�����\�ȕ��m�B�̗͂��Ⴍ�����ɕK�v��AP�������B\n";
                        break;
                    case 4:
                        my_text.text = "�J�^�p���g�c�������U�����\�ȍU�镺��B�U���͂������������R�X�g���ړ��Ɏg�p����AP�ʂ���������1�}�X�܂ŋߊ����Ɖ����ł��Ȃ��Ȃ��_������B\n";
                        break;
                    case 5:
                        my_text.text = "�J�^�p���g�c�������U�����\�ȍU�镺��B�U���͂������������R�X�g���ړ��Ɏg�p����AP�ʂ���������1�}�X�܂ŋߊ����Ɖ����ł��Ȃ��Ȃ��_������B\n";
                        break;
                    default:
                        text_num_num = 5;
                        break;
                }
                              break;


        }


    }

    public void OnMouseEnter()
    {
        //�{�^���Ƀ}�E�X�J�[�\����������Ƃ�
        this.GetComponent<Renderer>().material.color = new Color(0.7f, 0.7f, 0.7f, 1.0f);
      
    }
    public void OnMouseExit()
    {
        //�{�^���ɏ�����}�E�X�J�[�\�������ꂽ�Ƃ�
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);


    }

}
