using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Switch : MonoBehaviour
{
    public int Text_Num;
    private Text My_Text;//�ύX����e�L�X�g

    SpriteRenderer SR;//�ύX����摜�̃X�v���C�g���

    [field: SerializeField] public int Text_Num_Num { get; set; }
   
     [field: SerializeField]
    public int Total_Image
    { get; set; }
    
     [field: SerializeField]
    public int What_Num_Image
    {
        get; set;
    }

    public Sprite[] Next_Image;

    [SerializeField] GameObject Next;
    [SerializeField] GameObject Back;
    
    public Transform parent;

    [SerializeField] GameObject Blind;

    public AudioClip Enter;//�J�[�\����������Ƃ��ɖ炷��
    public AudioClip Push;//�}�E�X���������Ƃ��ɖ炷��
    private AudioSource AudioSource;

    private Color DarkGray = new Color(0.3f, 0.3f, 0.3f);

    private GameObject next_back;
    private string NEXT_BACK;
    private enum Rule_Number
    {
        Summon,
        Move,
        Harvest,
        Attack,
        Victory,
        Lose,
        Field,
        Unit_Information,
    };

    private enum Text_Number
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
    }

    //�X�^�[�g�֐�
    //����
    void Start()
    {
        My_Text = GameObject.Find("Explanation").GetComponent<Text>();//�V�[������text�I�u�W�F�N�g���擾

        Hidden_Next_Or_Back();

    } 
    void Summon_Next()
    {
        Next = parent.transform.Find("Next_Core").gameObject; //�e�I�u�W�F�N�g���擾
        Next.SetActive(true);                                 //���փ{�^����\��
        Next.transform.position = new Vector3( 60, -51, 0.0f);//���փ{�^���̈ʒu��ύX

    }
    void Summon_Back()
    {
        Back = parent.transform.Find("Back_Core").gameObject;//�e�I�u�W�F�N�g���擾
        Back.SetActive(true);                                //�߂�{�^����\��
        Back.transform.position = new Vector3( 0, -51, 0.0f);//�߂�{�^���̈ʒu��ύX

    }

  public void Indication_Next_Or_Back(string a)
    {
        
        NEXT_BACK = a;
        Debug.Log(NEXT_BACK);
        if(NEXT_BACK=="back"&& What_Num_Image != (int)Text_Number.Zero)
        {
            next_back = parent.transform.Find("Back_Core").gameObject;//�e�I�u�W�F�N�g���擾
            next_back.transform.position = new Vector3(0, -51, 0.0f);//�߂�{�^���̈ʒu��ύX
            next_back.SetActive(true);
        }
        else
        {
            Hidden_Next_Or_Back();
        }
         if(NEXT_BACK=="next" && Total_Image!=What_Num_Image-(int)Text_Number.One)
        {
            next_back = parent.transform.Find("Next_Core").gameObject;//�e�I�u�W�F�N�g���擾
            next_back.transform.position = new Vector3(60, -51, 0.0f);//�߂�{�^���̈ʒu��ύX
            next_back.SetActive(true);
        }
        else
        {
            Hidden_Next_Or_Back();
        }
       
    }
 
    void Hidden_Next_Or_Back()//���փ{�^���Ɩ߂�{�^�����\���ɂ���
    {
        if(Back.activeSelf)//�߂�{�^�����\������Ă���Ȃ�
        {
            GameObject[] Click_Back = GameObject.FindGameObjectsWithTag("Back");//Back�^�O�������S�ẴI�u�W�F�N�g���擾

            foreach (GameObject Back_Child in Click_Back)
            {
                Back_Child.SetActive(false); //Back�^�O�������S�ẴI�u�W�F�N�g���\���ɂ���
            }
        }
        if(Next.activeSelf)//���փ{�^�����\������Ă���Ȃ�
        {
            GameObject[] Click_Next = GameObject.FindGameObjectsWithTag("Next");//Next�^�O�������S�ẴI�u�W�F�N�g���擾

            foreach (GameObject Next_Child in Click_Next)
            {
                Next_Child.SetActive(false);  //Next�^�O�������S�ẴI�u�W�F�N�g���\���ɂ���
            }
        }
    }

    void Color_Change_White()//�{�^���̐F�𔒐F�ɕς���
    {
        GameObject[] _blind = GameObject.FindGameObjectsWithTag("Blind");//Blind�^�O�������S�ẴI�u�W�F�N�g���擾

        foreach (GameObject blind_child in _blind)
        {
            //Blind�^�O�������S�ẴI�u�W�F�N�g���\���ɂ���
            blind_child.GetComponent<Renderer>().material.color = Color.white;
            
        }

    }
    
    void Color_Change_DarkGray()//�{�^���̐F��Z���D�F�ɕς���
    {
        this.GetComponent<Renderer>().material.color = DarkGray;
    }

    public void Swith_Over_Image()//�\������摜��؂�ւ���
    {
        AudioSource = this.gameObject.GetComponent<AudioSource>(); //�I�[�f�B�I�\�[�X�擾

        AudioSource.PlayOneShot(Push);//���ʉ����Đ�����
        Text_Num_Num = (int)Text_Number.Zero;
        Text_Rewrite();//text���̕��͂�����������

        Color_Change_White();//�f�t�H���g�̔��F�ɖ߂�
        Color_Change_DarkGray();//�Z���D�F�ɂ���


        Hidden_Next_Or_Back();

        Text_Num_Num = (int)Text_Number.Zero;

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾

        What_Num_Image = (int)Text_Number.Zero;
                
        SR.sprite = Next_Image[What_Num_Image];//�����ɉ������摜��\������

        if(Total_Image > (int)Text_Number.One)//�摜�̑�����1���傫���Ȃ�
        {
            Hidden_Next_Or_Back();
            //Indication_Next_Or_Back(NEXT_BACK);
            Summon_Next(); //���փ{�^����\��

            
        }
        else
        {
 
            Hidden_Next_Or_Back();
        }

    }

    public void Display_Next_Image_And_Text()
    {
        AudioSource.PlayOneShot(Push);//���ʉ����Đ�����

        Text_Num_Num++;               //���₷

        Text_Rewrite();               //text���̕��͂�����������

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾

        What_Num_Image++;

        if (What_Num_Image == Total_Image - (int)Text_Number.One)//���݂̉摜�ԍ����摜�����Ɠ����l�Ȃ��
        {
            What_Num_Image = Total_Image - (int)Text_Number.One;//���̒l�ɌŒ肷��
            
            
            SR.sprite = Next_Image[What_Num_Image];//�������摜����-1�ɉ������摜��\������

            Hidden_Next_Or_Back();
            //Indication_Next_Or_Back(NEXT_BACK);
            Summon_Back();//�߂�{�^����\��

        }
        else//�����łȂ��Ȃ灁�摜�����Ɠ��l�łȂ��Ȃ�
        {
      
            SR.sprite = Next_Image[What_Num_Image];//���݂̐����ɉ������摜��\������

            Summon_Back();//���փ{�^����\��
            //Indication_Next_Or_Back(NEXT_BACK);
        }
  
    }

    public void Display_Back_Image_And_Text()
    {
        AudioSource.PlayOneShot(Push);//���ʉ����Đ�����

        Text_Num_Num--;//���炷

        if (Text_Num_Num == (int)Text_Number.Zero)//�e�L�X�g�ԍ���0�Ȃ�
        {
            Text_Num_Num = (int)Text_Number.Zero;//0�̂܂܂ɂ��Ă���
        }

        Text_Rewrite();//text���̕��͂�����������

        SR = GameObject.Find("switch_image").GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾

        What_Num_Image--;//���炷

        if (What_Num_Image == (int)Text_Number.Zero)//�摜�ԍ���0�Ȃ�
        {

            What_Num_Image = (int)Text_Number.Zero;//0�̂܂܂ɂ���
           
            SR.sprite = Next_Image[What_Num_Image];//������0�ɉ������摜��\������

            Hidden_Next_Or_Back();
            //Indication_Next_Or_Back(NEXT_BACK);
            Summon_Next(); //���փ{�^����\��

        }
        else//�����łȂ���0�ȊO�Ȃ�
        {
            
            SR.sprite = Next_Image[What_Num_Image];//�����ɉ������摜��\������
            Summon_Next();//���փ{�^����\��
            //Indication_Next_Or_Back(NEXT_BACK);
        }

    }

    public void Text_Rewrite()//���͂�����������
    {
        switch (Text_Num)
        {
            case (int)Rule_Number.Summon://����
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\nUI��ʂɂ��郆�j�b�g�����N���b�N���Ă��玩���̐w�n�����N���b�N����Ə����ł���B\n�������A�����ɕK�v��AP�܂��͎���������Ȃ��Ə����ł��Ȃ��B";
                        break;
                    case (int)Text_Number.One:
                        My_Text.text = "\nUI��ʂɂ��郆�j�b�g�����N���b�N���Ă��玩���̐w�n�����N���b�N����Ə����ł���B\n�������A�����ɕK�v��AP�܂��͎���������Ȃ��Ə����ł��Ȃ��B";
                        break;
                    default:
                        Text_Num_Num = (int)Text_Number.One;
                        break;
                }
                break;

            case (int)Rule_Number.Move://�ړ�
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n�ړ������������j�b�g�����N���b�N���Ă���A���̃��j�b�g�̍s�����������̏㉺���E1�}�X�����N���b�N����Έړ��ł���B\n";
                        break;
                    default:
                        Text_Num_Num = (int)Text_Number.Zero;
                        break;
                }
                break;
            case (int)Rule_Number.Harvest://�̎�
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n�t�B�[���h�}�b�v��ɂ��鎑�ނ܂�'����'���ړ������Ă��玑�ނ����N���b�N���邱�Ƃŉ�����ł���B\n";
                        break;
                    default:
                        Text_Num_Num = (int)Text_Number.Zero;
                        break;
                }
                break;
            case (int)Rule_Number.Attack://�U��
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n�U�������������j�b�g�����N���b�N���āA�U�����������j�b�g�����N���b�N����΍U�����鎖���ł���B\n";
                        break;
                    case (int)Text_Number.One:
                        My_Text.text = "\n�e���j�b�g�̍U���˒��̓��j�b�g�����N���b�N����Ɗm�F�ł���B\n";
                        break;
                    default:
                        Text_Num_Num = (int)Text_Number.One;
                        break;
                }
                break;
            case (int)Rule_Number.Victory://��������
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n���R���G�̖{�w��HP��0�ɂ���Ώ����ƂȂ�B\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n����΂�I\n";
                break;
                    default:
                        Text_Num_Num = (int)Text_Number.Zero;
                        break;
                }
                break;
            case (int)Rule_Number.Lose://�s�k����
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n�G�̍U���ɂ����\n���R�̖{�w��HP��0�ɂ����Δs�k�ƂȂ�B\n";
                        break;
                    default:
                        Text_Num_Num = (int)Text_Number.Zero;
                        break;
                }
                break;
            case (int)Rule_Number.Field://�t�B�[���h���
                switch (Text_Num_Num) {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n���c�ǂ̃��j�b�g�����ɏ�Q�Ȃ��ړ����邱�Ƃ��ł���\n\n���c�ǂ̃��j�b�g�ł��ʂ邱�Ƃ��ł��邪�ړ����̏���AP�ʂ����ꂼ��1��������B\n";
                        break;
                    case (int)Text_Number.One:
                        My_Text.text = "\n�X�A�[�����c�S�Ẵ��j�b�g���ʂ邱�Ƃ��ł��Ȃ��ꏊ\n";
                        break;
                    case (int)Text_Number.Two:
                        My_Text.text = "\n���ށc�J�^�p���g����������ׂɕK�v�Ȃ��́B\n�����ł̂݉�����\�����A�����͈��^�[�����o�߂���܂ōĉ���ł��Ȃ��Ȃ�B\n";
                        break;
                    default:
                        Text_Num_Num = (int)Text_Number.Two;
                        break;
                }
                break;
            case (int)Rule_Number.Unit_Information://���j�b�g���
                switch (Text_Num_Num)
                {
                    case (int)Text_Number.Zero:
                        My_Text.text = "\n�����c�ߐڍU�������ł��Ȃ��������ɕK�v��AP�����Ȃ����ނ�������鎖���ł���B��̕��m�B\n";
                        break;
                    case (int)Text_Number.One:
                        My_Text.text = "\n�����c�ߐڍU�������ł��Ȃ��������ɕK�v��AP�����Ȃ����ނ�������鎖���ł���B��̕��m�B\n";
                        break;
                    case (int)Text_Number.Two:
                        My_Text.text = "\n�|���c�������U�����\�ȕ��m�B�̗͂��Ⴍ�����ɕK�v��AP�������B\n";
                        break;
                    case (int)Text_Number.Three:
                        My_Text.text = "\n�|���c�������U�����\�ȕ��m�B�̗͂��Ⴍ�����ɕK�v��AP�������B\n";
                        break;
                    case (int)Text_Number.Four:
                        My_Text.text = "\n�J�^�p���g�c�������U�����\�ȍU�镺��B�U���͂������������R�X�g���ړ��Ɏg�p����AP�ʂ���������1�}�X�܂ŋߊ����Ɖ����ł��Ȃ��Ȃ��_������B\n";
                        break;
                    case (int)Text_Number.Five:
                        My_Text.text = "\n�J�^�p���g�c�������U�����\�ȍU�镺��B�U���͂������������R�X�g���ړ��Ɏg�p����AP�ʂ���������1�}�X�܂ŋߊ����Ɖ����ł��Ȃ��Ȃ��_������B\n";
                        break;
                    default:
                        Text_Num_Num = (int)Text_Number.Five;
                        break;
                }
                  break;
        }
    }

    public void OnMouseEnter()
    {
        //�{�^���Ƀ}�E�X�J�[�\����������Ƃ�

        if (this.GetComponent<Renderer>().material.color ==Color.white)//�{�^���̐F�����F�Ȃ�
        {
            this.GetComponent<Renderer>().material.color = Color.gray;//�{�^���̐F���D�F�ɕς���
        }

        AudioSource = this.gameObject.GetComponent<AudioSource>(); //�I�[�f�B�I�\�[�X�擾

        AudioSource.PlayOneShot(Enter);//���ʉ����Đ�����

    }
    public void OnMouseExit()
    {
        //�{�^���ɏ�����}�E�X�J�[�\�������ꂽ�Ƃ�
       
        if (this.GetComponent<Renderer>().material.color == DarkGray)//�}�E�X�J�[�\����������{�^���̐F��DarkGray�������ꍇ
        {
            this.GetComponent<Renderer>().material.color = DarkGray;//�F��DarkGray�ɕς���
        }
        else //�����łȂ��Ȃ灁�{�^���̐F�����F�܂��͊D�F�̏ꍇ
        {
            this.GetComponent<Renderer>().material.color = Color.white;//�{�^���̐F�𔒐F�ɕς���
        }

    }

   

}
