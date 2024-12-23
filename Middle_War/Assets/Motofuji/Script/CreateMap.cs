using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private GameObject tileobj;
    Transform castletf;
    GameObject castleobj;
    GameObject obj;

    GameObject CN;
    remenber_country_num RCN;

    [SerializeField] CPU_Controller CPUC;

    [SerializeField] Unit_Tile_Check UTC;

    //�I�u�W�F�N�g
    public GameObject grass;
    public GameObject mountain;
    public GameObject water;
    public GameObject morewater;
    public GameObject castle1;
    public GameObject area1;
    public GameObject castle2;
    public GameObject area2;
    public GameObject resource;

    //�^�C���ݒu�̍ŏ��̈ʒu
    public float SetTileStart_X;
    public float SetTileStart_Y;
    public float SetTile_Z;
    //�^�C���̑傫��
    public float TILESIZE_X;
    public float TILESIZE_Y;
    //�}�b�v�T�C�Y
    public int MAPSIZE_X;
    public int MAPSIZE_Y;
    //�^�C���Ԃ̒���
    public float TILESPACE;
    //�X�y�[�X�������ꂽ���t���O
    private bool PUSHSPACE;
    //���ݐݒu���Ă���^�C���}�b�v�̃}�b�v���W
    private int x, y;
    //���ݐݒu���Ă���^�C���̃��[���h���W
    private float SET_X, SET_Y;

    int APpuls;

    //csv����}�b�v�������o��
    private List<string> smap = new List<string>();
    public int[] map;
    //csv�t�@�C���̏ꏊ
    private string test_map = "Assets/alpha/Resources/map(stage2).csv";
    public string[] map_info;
    private string map2 = "Resources/map(stage2).csv";
    private string map3 = "Resources/map(stage3).csv";
    private string map4 = "Resources/map(stage4).csv";
    private string map5 = "Resources/map(stage5).csv";
    private string map6 = "Resources/map(stage6).csv";
    private string map7 = "Resources/map(stage7).csv";
    //private string map2 = "Assets/alpha/Resources/map(stage2).csv";
    //private string map3 = "Assets/alpha/Resources/map(stage3).csv";
    //private string map4 = "Assets/alpha/Resources/map(stage4).csv";
    //private string map5 = "Assets/alpha/Resources/map(stage5).csv";
    //private string map6 = "Assets/alpha/Resources/map(stage6).csv";
    //private string map7 = "Assets/alpha/Resources/map(stage7).csv";

    //playerAP�̊Ǘ������鐔�l�B
    int Maximam_PAP = 999;
    public int Now_PAP = 0;
    [SerializeField] Text PAP_Text;

    //player�����̊Ǘ������鐔�l�B
    int Maximam_PResource = 999;
    public int Now_PResource = 0;
    [SerializeField] Text PRE_Text;

    //enemyAP�̊Ǘ������鐔�l�B
    int Maximam_EAP = 999;
    public int Now_EAP = 0;
    [SerializeField] Text EAP_Text;

    //enemy�����̊Ǘ������鐔�l
    int Maximam_EResource = 999;
    public int Now_EResource = 0;
    [SerializeField] Text ERE_Text;

    /// <summary>
    /// csv�t�@�C���̓ǂݍ��ݗp���W���[��
    /// </summary>
    /// <param name = "pass">csv�t�@�C���̃p�X</param>
    /// <returns>csv���番�����ꂽList<string>��Ԃ�</string></returns>
    public List<string> Csv_Input(string pass)
    {
        List<string> str_lists = new List<string>();//�l�i�[�p���X�g
        try
        {
            //�p�X���w�肵��csv�t�@�C�����J��
            StreamReader csv = new StreamReader(pass);
            //�t�@�C�������܂Ŏ��s
            while (!csv.EndOfStream)
            {
                string line = csv.ReadLine();//�t�@�C������1�s�ǂݍ���
                string[] values = line.Split(',');//","�ŋ�؂��Ĕz��ɕۑ�
                str_lists.AddRange(values);// �z�񂩂烊�X�g�Ɋi�[����
            }
            csv.Close();//�t�@�C�������
            Debug.Log("public List<string> Csv_Input(string pass)�ł̓ǂݍ��݊���");
        }
        catch
        {
            Debug.Log("public List<string> Csv_Input(string pass)�ł̓ǂݍ��݃G���[");
        }
        return str_lists;//string�^���X�g��߂�
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        APpuls = 0;
        map = new int[MAPSIZE_X * MAPSIZE_Y];

        //�X�e�[�W�Z���N�g�őI�������X�e�[�W�̔ԍ����Ƀ}�b�v�̓ǂݍ��݂�ύX����
        CN = GameObject.Find("country_info");
        if (CN != null)
        {
            RCN = CN.GetComponent<remenber_country_num>();
            if( RCN != null )
            {
                smap = Csv_Input(map_info[RCN.country_num]);
            }
        }
        else
        {
            smap = Csv_Input(test_map);
        }

        //�}�b�v���̏�����
        for (int i = 0; i < MAPSIZE_X * MAPSIZE_Y; i++)
        {
            map[i] = -999;
        }

        //�}�b�v���̓ǂݍ���
        for (int i = 0; i < MAPSIZE_X * MAPSIZE_Y; i++)
        {
            map[i] = int.Parse(smap[i]);
        }

        //AP�Ǝ����̏�����
        Now_PAP = 5;
        Now_PResource = 0;
        Now_EAP = 0;
        Now_EResource = 0;

        obj = null;

        //�}�b�v����
        do
        {
            if (y < MAPSIZE_Y)
            {
                SET_X = SetTileStart_X + (TILESIZE_X + TILESPACE) * x;
                SET_Y = SetTileStart_Y - (TILESIZE_Y + TILESPACE) * y;
                switch (map[x + y * MAPSIZE_Y])
                {
                    case 0://��
                        obj = Instantiate(grass, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 1://�R
                        obj = Instantiate(mountain, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 2://��
                        obj = Instantiate(water, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 3://����
                        obj = Instantiate(resource, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 4://PLAYER1�̏�
                        obj = Instantiate(castle1, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 5://PLAYER2�̏�
                        obj = Instantiate(castle2, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 6://�[����
                        obj = Instantiate(morewater, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 7://������
                        break;
                }
                obj.transform.parent = tileobj.transform;
            }
            x++;
            if (x >= MAPSIZE_X)
            {
                x -= MAPSIZE_X;
                y++;
            }
            if(y > MAPSIZE_Y)
            {
                //PLAYER1�̏�̎���Ƀ��j�b�g�̏����\�G���A��z�u����
                castletf = tileobj.transform.Find("castle1(Clone)");
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0) { }
                        else
                        {
                            GameObject tmpobj = null;
                            SET_X = castletf.position.x + (TILESIZE_X + TILESPACE) * j;
                            SET_Y = castletf.position.y + (TILESIZE_Y + TILESPACE) * i;
                            tmpobj = Instantiate(area1, new Vector3(SET_X, SET_Y, castletf.position.z - 1), Quaternion.identity);
                            tmpobj.transform.parent = castletf;
                        }
                    }
                }
                //PLAYER2�̏�̎���Ƀ��j�b�g�̏����\�G���A��z�u����
                castletf = tileobj.transform.Find("castle2(Clone)");
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0) { }
                        else
                        {
                            GameObject tmpobj = null;
                            SET_X = castletf.position.x + (TILESIZE_X + TILESPACE) * j;
                            SET_Y = castletf.position.y + (TILESIZE_Y + TILESPACE) * i;
                            tmpobj = Instantiate(area2, new Vector3(SET_X, SET_Y, castletf.position.z - 1), Quaternion.identity);
                            tmpobj.transform.parent = castletf;
                        }
                    }
                }
                break;
            }
        } while (true);

        //AP�Ǝ������e�L�X�g�ɕ\��
        PAP_Text.text = Now_PAP.ToString() + "/" + Maximam_PAP.ToString();
        PRE_Text.text = Now_PResource.ToString() + "/" + Maximam_PResource.ToString();
        EAP_Text.text = Now_EAP.ToString() + "/" + Maximam_EAP.ToString();
        ERE_Text.text = Now_EResource.ToString() + "/" + Maximam_EResource.ToString();

        CPUC.Map_Collect();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Now_EAP = Now_EResource = 999;
        }
        //�}�E�X�̃|�W�V������\��
        if(Input.GetKeyDown(KeyCode.M))
        {
            Vector2 m_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("m_pos(" + m_pos.x.ToString("F2") + "," + m_pos.y.ToString("F2") + ")");
        }

        //AP�⎑��������𒴂����ꍇ����ɐ��l��߂�
        if(Now_PAP > Maximam_PAP)
        {
            Now_PAP = Maximam_PAP;
            PAP_Text.text = Now_PAP.ToString() + "/" + Maximam_PAP.ToString();
        }
        if(Now_PResource > Maximam_PResource)
        {
            Now_PResource = Maximam_PResource;
            PRE_Text.text = Now_PResource.ToString() + "/" + Maximam_PResource.ToString();
        }
        if(Now_EAP > Maximam_EAP)
        {
            Now_EAP = Maximam_EAP;
            EAP_Text.text = Now_EAP.ToString() + "/" + Maximam_EAP.ToString();
        }
        if(Now_EResource > Maximam_EResource)
        {
            Now_EResource = Maximam_EResource;
            ERE_Text.text = Now_EResource.ToString() + "/" + Maximam_EResource.ToString();
        }
    }

    //�v���C���[����AP�Ǝ�����ύX����֐�
    public void PChange_REAP(int ap, int re)
    {
        Now_PAP = ap;
        Now_PResource = re;
        PAP_Text.text = Now_PAP.ToString() + "/" + Maximam_PAP.ToString();
        PRE_Text.text = Now_PResource.ToString() + "/" + Maximam_PResource.ToString();
    }

    //�G�l�~�[����AP�Ǝ�����ύX����֐�
    public void EChange_REAP(int ap,int re)
    {
        Now_EAP = ap;
        Now_EResource = re;
        EAP_Text.text = Now_EAP.ToString() + "/" + Maximam_EAP.ToString();
        ERE_Text.text = Now_EResource.ToString() + "/" + Maximam_EResource.ToString();
    }
}