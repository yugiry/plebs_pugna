using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private GameObject tileobj;
    GameObject obj;

    //�I�u�W�F�N�g
    public GameObject grass;
    public GameObject mountain;
    public GameObject water;
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

    //csv����}�b�v�������o��
    private List<string> smap = new List<string>();
    public int[] map;
    //csv�t�@�C���̏ꏊ
    //private string csv_place = "Resources/map.csv";
    private string csv_place = "Assets/alpha/Resources/map.csv";

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

        map = new int[MAPSIZE_X * MAPSIZE_Y];
        smap = Csv_Input(csv_place);

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
        Now_PAP = 999;
        Now_PResource = 999;
        Now_EAP = 999;
        Now_EResource = 999;

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
                        for (int i = y - 1; i <= y + 1; i++)
                        {
                            for (int j = x - 1; j <= x + 1; j++)
                            {
                                if (i == y && j == x) { }
                                else
                                {
                                    GameObject tmpobj = null;
                                    SET_X = SetTileStart_X + (TILESIZE_X + TILESPACE) * j;
                                    SET_Y = SetTileStart_Y - (TILESIZE_Y + TILESPACE) * i;
                                    tmpobj = Instantiate(area1, new Vector3(SET_X, SET_Y, SetTile_Z - 1), Quaternion.identity);
                                    tmpobj.transform.parent = tileobj.transform;
                                }
                            }
                        }
                        break;
                    case 5://PLAYER2�̏�
                        obj = Instantiate(castle2, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        for (int i = y - 1; i <= y + 1; i++)
                        {
                            for (int j = x - 1; j <= x + 1; j++)
                            {
                                if (i == y && j == x) { }
                                else
                                {
                                    GameObject tmpobj = null;
                                    SET_X = SetTileStart_X + (TILESIZE_X + TILESPACE) * j;
                                    SET_Y = SetTileStart_Y - (TILESIZE_Y + TILESPACE) * i;
                                    tmpobj = Instantiate(area2, new Vector3(SET_X, SET_Y, SetTile_Z - 1), Quaternion.identity);
                                    tmpobj.transform.parent = tileobj.transform;
                                }
                            }
                        }
                        break;
                }
                obj.transform.parent = tileobj.transform;
            }
            //else if (y == MAPSIZE_Y && x == 0)
            //{
            //    Instantiate(castle1, new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * 22, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * 22, SetTile_Z - 5), Quaternion.identity);
            //    Instantiate(castle2, new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * 2, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * 2, SetTile_Z - 5), Quaternion.identity);
            //    for (int dy = 0; dy < 3; dy++)
            //    {
            //        for (int dx = 0; dx < 3; dx++)
            //        {
            //            if (dy == 1 && dx == 1)
            //            {

            //            }
            //            else
            //            {
            //                Instantiate(area1, new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * (21 + dx), SetTileStart_Y - (TILESIZE_Y + TILESPACE) * (21 + dy), SetTile_Z - 5), Quaternion.identity);
            //                Instantiate(area2, new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * (1 + dx), SetTileStart_Y - (TILESIZE_Y + TILESPACE) * (1 + dy), SetTile_Z - 5), Quaternion.identity);
            //            }
            //        }
            //    }
            //    break;
            //}
            x++;
            if (x >= MAPSIZE_X)
            {
                x -= MAPSIZE_X;
                y++;
            }
            if(y > MAPSIZE_Y)
            {
                break;
            }
        } while (true);

        //AP�Ǝ������e�L�X�g�ɕ\��
        PAP_Text.text = Now_PAP.ToString() + "/" + Maximam_PAP.ToString();
        PRE_Text.text = Now_PResource.ToString() + "/" + Maximam_PResource.ToString();
        EAP_Text.text = Now_EAP.ToString() + "/" + Maximam_EAP.ToString();
        ERE_Text.text = Now_EResource.ToString() + "/" + Maximam_EResource.ToString();
    }

    // Update is called once per frame
    void Update()
    {
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