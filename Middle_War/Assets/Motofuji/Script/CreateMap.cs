using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CreateMap : MonoBehaviour
{
    //オブジェクト
    public GameObject grass;
    public GameObject mountain;
    public GameObject water;
    public GameObject castle1;
    public GameObject area1;
    public GameObject castle2;
    public GameObject area2;
    public GameObject resource;

    //タイル設置の最初の位置
    public float SetTileStart_X;
    public float SetTileStart_Y;
    public float SetTile_Z;
    //タイルの大きさ
    public float TILESIZE_X;
    public float TILESIZE_Y;
    //マップサイズ
    public int MAPSIZE_X;
    public int MAPSIZE_Y;
    //タイル間の長さ
    public float TILESPACE;
    //スペースが押されたかフラグ
    private bool PUSHSPACE;
    //現在設置しているタイルマップのマップ座標
    private int x, y;
    //現在設置しているタイルのワールド座標
    private float SET_X, SET_Y;

    //csvからマップ情報を取り出す
    private List<string> smap = new List<string>();
    public int[] map;
    //csvファイルの場所
    private string csv_place = "Assets/Motofuji/Resources/map.csv";

    //APの管理をする数値+。
    int Maximam_AP = 999;
    public int Now_AP = 0;
    [SerializeField] Text AP_Text;

    //資源の管理をする数値。
    int Maximam_Resource = 999;
    public int Now_Resource = 0;
    [SerializeField] Text RE_Text;

    /// <summary>
    /// csvファイルの読み込み用モジュール
    /// </summary>
    /// <param name = "pass">csvファイルのパス</param>
    /// <returns>csvから分割されたList<string>を返す</string></returns>
    public List<string> Csv_Input(string pass)
    {
        List<string> str_lists = new List<string>();//値格納用リスト
        try
        {
            //パスを指定してcsvファイルを開く
            StreamReader csv = new StreamReader(pass);
            //ファイル末尾まで実行
            while (!csv.EndOfStream)
            {
                string line = csv.ReadLine();//ファイルから1行読み込み
                string[] values = line.Split(',');//","で区切って配列に保存
                str_lists.AddRange(values);// 配列からリストに格納する
            }
            csv.Close();//ファイルを閉じる
            Debug.Log("public List<string> Csv_Input(string pass)での読み込み完了");
        }
        catch
        {
            Debug.Log("public List<string> Csv_Input(string pass)での読み込みエラー");
        }
        return str_lists;//string型リストを戻す
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
                    case 0://草
                        Instantiate(grass, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 1://山
                        Instantiate(mountain, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 2://水
                        Instantiate(water, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 3://資源
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