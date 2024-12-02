using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Kirikae : MonoBehaviour
{
    public int text_num;
    private Text my_text;

    GameObject button;

    
    //public int mode_change;

    SpriteRenderer test;

    //public Sprite[] summon_gazou;

    [SerializeField] AudioClip[] clips;
    [SerializeField] float pitchRange = 0.1f;
    protected AudioSource source;

    


    /*[SerializeField]*/
    [field: SerializeField] public int text_num_num { get; set; }
   
    

    /*[SerializeField]*/
    [field: SerializeField] public int img { get; set; }

    

    /*[SerializeField]*/
     [field: SerializeField]
    public int gazou_sousu
    { get; set; }
    

    /*[SerializeField]*/
     [field: SerializeField]
    public int gazou_nanmai
    {
        get; set;
    }

    //GameObject Next;
    //GameObject Back;

    public Sprite[] next_gazou;
   

    [SerializeField] GameObject Next;
    [SerializeField] GameObject Back;
    private GameObject button_hyouji1;
    private GameObject button_hyouji2;
    public Transform parent;

    button_color_change BCC;

    [SerializeField] GameObject Mekakusi;


    public AudioClip enter;
    private AudioSource audiosouse;


    

    void Start()
    {
        my_text = GameObject.Find("setumei").GetComponent<Text>();
        my_text.color = new Color(1.0f, 1.0f, 1.0f);

        
        Destroy_Next();
        Destroy_Back();


       
    }

    
    
    void Summon_Next()
    {
        Vector3 pos = parent.transform.localPosition;//�N���b�N���ꂽ���j�b�g�̈ʒu���
        Next = parent.transform.Find("Next_Core").gameObject;
        Next.SetActive(true);
        Next.transform.position = new Vector3( 60, -51, 0.0f);

       

    }
    void Summon_Back()
    {
        Vector3 pos = parent.transform.localPosition;//�N���b�N���ꂽ���j�b�g�̈ʒu���
        Back = parent.transform.Find("Back_Core").gameObject;
        Back.SetActive(true);
        Back.transform.position = new Vector3( 0, -51, 0.0f);
       
        
    }
    
    void Destroy_Next()
    {
        GameObject[] click_next = GameObject.FindGameObjectsWithTag("Next");

      
            foreach (GameObject next_child in click_next)
            {
            
            next_child.SetActive(false);
            }
       
        
    }

    void Destroy_Back()
    {
        GameObject[] click_back = GameObject.FindGameObjectsWithTag("Back");

            foreach (GameObject back_child in click_back)
            {
            
            back_child.SetActive(false);
            }
       
        
    }

    void Kakunou_Mekakusi()
    {
        GameObject[] _mekakusi = GameObject.FindGameObjectsWithTag("Blind");

        foreach (GameObject mekakusi_child in _mekakusi)
        {
            
            mekakusi_child.SetActive(false);
        }

    }

    void Yobidasi_Mekakusi()
    {
        Vector3 pos = parent.transform.localPosition;//�N���b�N���ꂽ���j�b�g�̈ʒu���
        Mekakusi = parent.transform.Find("Blind_Core").gameObject;
        Mekakusi.SetActive(true);
        
    }

    public void Gazou_wo_Kirikaeyo()
    {
        audiosouse = this.gameObject.GetComponent<AudioSource>(); //�I�[�f�B�I�\�[�X�擾

        audiosouse.PlayOneShot(enter);
        text_num_num = 0;
        Text_Kakikae();

        Kakunou_Mekakusi();
        Yobidasi_Mekakusi();
       

        Destroy_Next();
        Destroy_Back();

      

        text_num_num = 0;

        

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai = 0;
        
        
        test.sprite = next_gazou[gazou_nanmai];
       
       
        
       

        if(gazou_sousu>1)
        {
            Summon_Next();
            Destroy_Back();
            


        }
        else
        {
            Destroy_Next();
            Destroy_Back();
               
            
        }

       

    }

    public void next_hyouji()
    {
        audiosouse.PlayOneShot(enter);

        text_num_num++;

        Text_Kakikae();

        

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai++;

        if (gazou_nanmai == gazou_sousu-1)
        {
            gazou_nanmai = gazou_sousu-1;
            
            
            test.sprite = next_gazou[gazou_nanmai];
            
                Destroy_Next();
                Summon_Back();

               
            
        }
        else
        {
            
            
            test.sprite = next_gazou[gazou_nanmai];
            //Back.SetActive(true);
            Summon_Back();
        }
        

        
    }

    public void back_hyouji()
    {
        audiosouse.PlayOneShot(enter);

        text_num_num--;

        if (text_num_num == 0)
        {
            text_num_num = 0;
        }

        Text_Kakikae();

        
       

        test = GameObject.Find("kirikae_I").GetComponent<SpriteRenderer>();

        gazou_nanmai--;

        if (gazou_nanmai == 0)
        {

            gazou_nanmai = 0;
           
            test.sprite = next_gazou[gazou_nanmai];
            
                Destroy_Back();
                Summon_Next();
               
            
        }
        else
        {
            
            test.sprite = next_gazou[gazou_nanmai];
            Summon_Next();
            
        }
        

        Debug.Log(gazou_nanmai);
    }

    public void Text_Kakikae()
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
                        my_text.text = "\n�ړ������������j�b�g�����N���b�N���Ă���s�������}�X�����N���b�N����Έړ��ł���B\n";
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
                        my_text.text = "\n�e���j�b�g�̍U���˒��̓��j�b�g�����N���b�N���Ă���}�E�X�z�C�[���ŃN���b�N����Ɗm�F�ł���B\n";
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
                        my_text.text = "\n�G�R�ɂ���Ď��R�̖{�w��HP��0�ɂ����Δs�k�ƂȂ�B\n";
                        break;
                    default:
                        text_num_num = 0;
                        break;
                }
                break;
            case 6://�t�B�[���h���
                switch (text_num_num) {
                    case 0:
                my_text.text = "\n���c�ǂ̃��j�b�g�����ɏ�Q�Ȃ��ړ����邱�Ƃ��ł���B\n��c�ǂ̃��j�b�g�ł��ʂ邱�Ƃ��ł��邪�ړ����̏���AP�ʂ����ꂼ��1��������B\n�X�c�ǂ�ȃ��j�b�g���ʂ邱�Ƃ��ł��Ȃ��ꏊ�B\n";
                        break;
                    case 1:
                        my_text.text = "\n���ށc�J�^�p���g����������ׂɕK�v�Ȃ��́B�����ŉ�����\�B\n�����͈��^�[�����o�߂���܂ōĉ���ł��Ȃ��Ȃ�B\n";
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
        this.GetComponent<Renderer>().material.color = new Color(0.7f, 0.7f, 0.7f, 1.0f);
      
    }
    public void OnMouseExit()
    {
  
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);


    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
