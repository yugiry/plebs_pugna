using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CreateMap : MonoBehaviour
{
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
    private string csv_place = "Assets/Motofuji/Resources/map.csv";

    //AP�̊Ǘ������鐔�l+�B
    int Maximam_AP = 999;
    public int Now_AP = 0;
    [SerializeField] Text AP_Text;

    //�����̊Ǘ������鐔�l�B
    int Maximam_Resource = 999;
    public int Now_Resource = 0;
    [SerializeField] Text RE_Text;

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
        map = new int[MAPSIZE_X * MAPSIZE_Y];
        smap = Csv_Input(csv_place);

        for (int i = 0; i < MAPSIZE_X * MAPSIZE_Y; i++)
        {
            map[i] = -999;
        }

        for (int i = 0; i < MAPSIZE_X * MAPSIZE_Y; i++)
        {
            map[i] = int.Parse(smap[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !PUSHSPACE)
        {
            PUSHSPACE = true;
            Now_AP += 5;
            Now_Resource = 0;
            AP_Text.text = Now_AP.ToString() + "/" + Maximam_AP.ToString();
            RE_Text.text = Now_Resource.ToString() + "/" + Maximam_Resource.ToString();
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            Vector2 m_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("m_pos(" + m_pos.x.ToString("F2") + "," + m_pos.y.ToString("F2") + ")");
        }

        if (PUSHSPACE)
        {
            if (y < MAPSIZE_Y)
            {
                SET_X = SetTileStart_X + (TILESIZE_X + TILESPACE) * x;
                SET_Y = SetTileStart_Y - (TILESIZE_Y + TILESPACE) * y;
                switch (map[x + y * MAPSIZE_Y])
                {
                    case 0://��
                        Instantiate(grass, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 1://�R
                        Instantiate(mountain, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 2://��
                        Instantiate(water, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 3://����
                        Instantiate(resource, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                }
            }
            else if (y == MAPSIZE_Y && x == 0)
            {
                Instantiate(castle1, new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * 22, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * 22, SetTile_Z - 5), Quaternion.identity);
                Instantiate(castle2, new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * 2, SetTileStart_Y - (TILESIZE_Y + TILESPACE) * 2, SetTile_Z - 5), Quaternion.identity);
                for (int dy = 0; dy < 3; dy++)
                {
                    for (int dx = 0; dx < 3; dx++)
                    {
                        if (dy == 1 && dx == 1)
                        {

                        }
                        else
                        {
                            Instantiate(area1, new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * (21 + dx), SetTileStart_Y - (TILESIZE_Y + TILESPACE) * (21 + dy), SetTile_Z - 5), Quaternion.identity);
                            Instantiate(area2, new Vector3(SetTileStart_X + (TILESIZE_X + TILESPACE) * (1 + dx), SetTileStart_Y - (TILESIZE_Y + TILESPACE) * (1 + dy), SetTile_Z - 5), Quaternion.identity);
                        }
                    }
                }

            }
            x++;
            if (x >= MAPSIZE_X)
            {
                x -= MAPSIZE_X;
                y++;
            }
        }
    }

    public void Change_REAP(int ap, int re)
    {
        Now_AP = ap;
        Now_Resource = re;
        AP_Text.text = Now_AP.ToString() + "/" + Maximam_AP.ToString();
        RE_Text.text = Now_Resource.ToString() + "/" + Maximam_Resource.ToString();
    }
}