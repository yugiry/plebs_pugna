using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private GameObject TileObj;    //�^�C���������������Ɏq�I�u�W�F�N�g�Ƃ��Ĕz�u���邽�߂̃I�u�W�F�N�g
    Transform CastleTF;                             //�����G���A���������鎞�ɏ�������ʒu�𒲂ׂ邽�߂̕ϐ�
    GameObject Obj;                                 //��������I�u�W�F�N�g���o���Ă������߂̕ϐ�

    GameObject CN;              //DontDestroy�Œu���Ă���I�u�W�F�N�g�̏�����邽�߂̕ϐ�
    remenber_country_num RCN;   //���ݑI������Ă��鍑�̔ԍ�����邽�߂̕ϐ�

    [SerializeField] CPU_Controller CPUC;//CPU�Ɋւ���X�N���v�g��ǂݎ��ϐ�

    [SerializeField] Unit_Tile_Check UTC;//�^�C���̏��Ɋւ���X�N���v�g��ǂݎ��ϐ�

    //�I�u�W�F�N�g
    //�}�b�v�ɐ�������^�C���̏����擾����
    public GameObject Grass;        //��
    public GameObject Mountain;     //�R
    public GameObject Water;        //��
    public GameObject Morewater;    //�[����
    public GameObject Castle1;      //��P
    public GameObject Area1;        //�G���A�P
    public GameObject Castle2;      //��Q
    public GameObject Area2;        //�G���A�Q
    public GameObject Resource;     //����

    //�^�C���ݒu�̍ŏ��̈ʒu
    public float SetTileStart_X;
    public float SetTileStart_Y;
    public float SetTile_Z;
    //�^�C���̑傫��
    public float TileSize_X;
    public float TileSize_Y;
    //�}�b�v�T�C�Y
    public int MapSize_X;
    public int MapSize_Y;
    //�^�C���Ԃ̒���
    public float TileSpace;
    //���ݐݒu���Ă���^�C���}�b�v�̃}�b�v���W
    private int x, y;
    //���ݐݒu���Ă���^�C���̃��[���h���W
    private float Set_X, Set_Y;

    //csv����}�b�v�������o��
    private List<string> smap = new List<string>();
    public int[] map;
    //csv�t�@�C���̏ꏊ
    private string test_map = "Assets/alpha/Resources/map(stage2).csv";
    public string[] map_info;

    //playerAP�̊Ǘ������鐔�l�B
    int Maximam_PAP = 999;
    public int Now_PAP = 0;
    [SerializeField] Text PAP_Text;

    //player�����̊Ǘ������鐔�l�B
    int Maximam_PResource = 999;
    public int Now_PResource = 0;
    [SerializeField] Text PRE_Text;

    //enemyAP�̊Ǘ������鐔�l�B
    const int Maximam_EAP = 999;
    public int Now_EAP = 0;
    [SerializeField] Text EAP_Text;

    //enemy�����̊Ǘ������鐔�l
    const int Maximam_EResource = 999;
    public int Now_EResource = 0;
    [SerializeField] Text ERE_Text;

    enum Tile
    {
        GRASS,//��
        MOUNTAIN,//�R
        WATER,//��
        RESOURCE,//����
        CASTLE1,//��P
        CASTLE2,//��Q
        DEEP_WATER//�[����
    };

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

    //�X�^�[�g�֐�
    void Start()
    {
        Application.targetFrameRate = 60;
        map = new int[MapSize_X * MapSize_Y];

        Load_Map();//�}�b�v����ǂݍ���

        Map_Creation();//�}�b�v���Q�[����ɕ\������

        //AP�Ǝ����̏�����
        Now_PAP = 5;
        Now_PResource = 0;
        Now_EAP = 0;
        Now_EResource = 0;

        Obj = null;

        //AP�Ǝ����̏󋵂��e�L�X�g�ɕ\��
        PAP_Text.text = Now_PAP.ToString() + "/" + Maximam_PAP.ToString();
        PRE_Text.text = Now_PResource.ToString() + "/" + Maximam_PResource.ToString();
        EAP_Text.text = Now_EAP.ToString() + "/" + Maximam_EAP.ToString();
        ERE_Text.text = Now_EResource.ToString() + "/" + Maximam_EResource.ToString();

        CPUC.Map_Collect();//���������S�ďI��������Ƃ𑗂�
    }

    /// <summary>
    /// �}�b�v�̏���int�^�z��ɓǂݍ��ނ��߂̊֐�
    /// </summary>
    void Load_Map()
    {
        //�X�e�[�W�Z���N�g�őI�������X�e�[�W�̔ԍ��ɂ���ă}�b�v�ǂݍ��݂�csv�t�@�C����ύX����
        CN = GameObject.Find("country_info");
        if (CN != null)
        {
            RCN = CN.GetComponent<remenber_country_num>();
            if (RCN != null)
            {
                smap = Csv_Input(map_info[RCN.country_num]);
            }
        }
        else
        {
            smap = Csv_Input(test_map);
        }

        //�}�b�v���̏�����
        for (int i = 0; i < MapSize_X * MapSize_Y; i++)
        {
            map[i] = -999;
        }

        //�}�b�v���̓ǂݍ���
        for (int i = 0; i < MapSize_X * MapSize_Y; i++)
        {
            map[i] = int.Parse(smap[i]);
        }
    }

    /// <summary>
    /// map�z�񂩂�}�b�v���Q�[�����[���h��ɐ���������֐�
    /// </summary>
    void Map_Creation()
    {
        for (y = 0; y < MapSize_Y; y++)
        {
            for (x = 0; x < MapSize_X; x++)
            {
                //�z��̈ʒu�����[���h���W�ɕϊ�
                Set_X = SetTileStart_X + (TileSize_X + TileSpace) * x;
                Set_Y = SetTileStart_Y - (TileSize_Y + TileSpace) * y;
                //�z��̐������Ƀ^�C���̎�ނ�ς��Ĕz�u����
                switch (map[x + y * MapSize_Y])
                {
                    case (int)Tile.GRASS://��
                        Obj = Instantiate(Grass, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.MOUNTAIN://�R
                        Obj = Instantiate(Mountain, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.WATER://��
                        Obj = Instantiate(Water, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.RESOURCE://����
                        Obj = Instantiate(Resource, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.CASTLE1://PLAYER1�̏�
                        Obj = Instantiate(Castle1, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.CASTLE2://PLAYER2�̏�
                        Obj = Instantiate(Castle2, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.DEEP_WATER://�[����
                        Obj = Instantiate(Morewater, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                }
                Obj.transform.parent = TileObj.transform;
            }
        }
        //PLAYER1�̏�̎���Ƀ��j�b�g�̏����\�G���A��z�u����
        CastleTF = TileObj.transform.Find("castle1(Clone)");
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) { }
                else
                {
                    GameObject tmpobj = null;
                    Set_X = CastleTF.position.x + (TileSize_X + TileSpace) * j;
                    Set_Y = CastleTF.position.y + (TileSize_Y + TileSpace) * i;
                    tmpobj = Instantiate(Area1, new Vector3(Set_X, Set_Y, CastleTF.position.z - 1), Quaternion.identity);
                    tmpobj.transform.parent = CastleTF;
                }
            }
        }
        //PLAYER2�̏�̎���Ƀ��j�b�g�̏����\�G���A��z�u����
        CastleTF = TileObj.transform.Find("castle2(Clone)");
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) { }
                else
                {
                    GameObject tmpobj = null;
                    Set_X = CastleTF.position.x + (TileSize_X + TileSpace) * j;
                    Set_Y = CastleTF.position.y + (TileSize_Y + TileSpace) * i;
                    tmpobj = Instantiate(Area2, new Vector3(Set_X, Set_Y, CastleTF.position.z - 1), Quaternion.identity);
                    tmpobj.transform.parent = CastleTF;
                }
            }
        }
    }

    //�A�b�v�f�[�g�֐�
    void Update()
    {
        //AP�⎑��������𒴂����ꍇ����ɐ��l��߂�
        if (Now_PAP > Maximam_PAP)
        {
            Now_PAP = Maximam_PAP;
            PAP_Text.text = Now_PAP.ToString() + "/" + Maximam_PAP.ToString();
        }
        if (Now_PResource > Maximam_PResource)
        {
            Now_PResource = Maximam_PResource;
            PRE_Text.text = Now_PResource.ToString() + "/" + Maximam_PResource.ToString();
        }
        if (Now_EAP > Maximam_EAP)
        {
            Now_EAP = Maximam_EAP;
            EAP_Text.text = Now_EAP.ToString() + "/" + Maximam_EAP.ToString();
        }
        if (Now_EResource > Maximam_EResource)
        {
            Now_EResource = Maximam_EResource;
            ERE_Text.text = Now_EResource.ToString() + "/" + Maximam_EResource.ToString();
        }
    }
    /// <summary>
    /// AP�Ǝ����̕ύX������֐�<br/>
    /// ch��0�̎��̓v���C���[�A1�̎��̓G�l�~�[��AP�Ǝ������ύX�����
    /// </summary>
    /// <param name="ap">ActionPoint�������Ă���ϐ�</param>
    /// <param name="re">Resource�������Ă���ϐ�</param>
    /// <param name="ch">�v���C���[���G�l�~�[�����ʂ���ϐ�</param>
    public void Character(int ap, int re, int ch)
    {
        if (ch == 0)
        {
            Now_PAP = ap;
            Now_PResource = re;
            PAP_Text.text = Now_PAP.ToString() + "/" + Maximam_PAP.ToString();
            PRE_Text.text = Now_PResource.ToString() + "/" + Maximam_PResource.ToString();
        }
        else
        {
            Now_EAP = ap;
            Now_EResource = re;
            EAP_Text.text = Now_EAP.ToString() + "/" + Maximam_EAP.ToString();
            ERE_Text.text = Now_EResource.ToString() + "/" + Maximam_EResource.ToString();
        }
    }
}