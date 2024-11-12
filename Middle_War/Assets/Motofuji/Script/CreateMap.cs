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
    //private string csv_place = "Resources/map.csv";
    private string csv_place = "Assets/alpha/Resources/map.csv";

    //playerAPの管理をする数値。
    int Maximam_PAP = 999;
    public int Now_PAP = 0;
    [SerializeField] Text PAP_Text;

    //player資源の管理をする数値。
    int Maximam_PResource = 999;
    public int Now_PResource = 0;
    [SerializeField] Text PRE_Text;

    //enemyAPの管理をする数値。
    int Maximam_EAP = 999;
    public int Now_EAP = 0;
    [SerializeField] Text EAP_Text;

    //enemy資源の管理をする数値
    int Maximam_EResource = 999;
    public int Now_EResource = 0;
    [SerializeField] Text ERE_Text;

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
        Application.targetFrameRate = 60;

        map = new int[MAPSIZE_X * MAPSIZE_Y];
        smap = Csv_Input(csv_place);

        //マップ情報の初期化
        for (int i = 0; i < MAPSIZE_X * MAPSIZE_Y; i++)
        {
            map[i] = -999;
        }

        //マップ情報の読み込み
        for (int i = 0; i < MAPSIZE_X * MAPSIZE_Y; i++)
        {
            map[i] = int.Parse(smap[i]);
        }

        //APと資源の初期化
        Now_PAP = 999;
        Now_PResource = 999;
        Now_EAP = 999;
        Now_EResource = 999;

        obj = null;

        //マップ生成
        do
        {
            if (y < MAPSIZE_Y)
            {
                SET_X = SetTileStart_X + (TILESIZE_X + TILESPACE) * x;
                SET_Y = SetTileStart_Y - (TILESIZE_Y + TILESPACE) * y;
                switch (map[x + y * MAPSIZE_Y])
                {
                    case 0://草
                        obj = Instantiate(grass, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 1://山
                        obj = Instantiate(mountain, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 2://水
                        obj = Instantiate(water, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 3://資源
                        obj = Instantiate(resource, new Vector3(SET_X, SET_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case 4://PLAYER1の城
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
                    case 5://PLAYER2の城
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

        //APと資源をテキストに表示
        PAP_Text.text = Now_PAP.ToString() + "/" + Maximam_PAP.ToString();
        PRE_Text.text = Now_PResource.ToString() + "/" + Maximam_PResource.ToString();
        EAP_Text.text = Now_EAP.ToString() + "/" + Maximam_EAP.ToString();
        ERE_Text.text = Now_EResource.ToString() + "/" + Maximam_EResource.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //マウスのポジションを表示
        if(Input.GetKeyDown(KeyCode.M))
        {
            Vector2 m_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("m_pos(" + m_pos.x.ToString("F2") + "," + m_pos.y.ToString("F2") + ")");
        }

        //APや資源が上限を超えた場合上限に数値を戻す
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

    //プレイヤー側のAPと資源を変更する関数
    public void PChange_REAP(int ap, int re)
    {
        Now_PAP = ap;
        Now_PResource = re;
        PAP_Text.text = Now_PAP.ToString() + "/" + Maximam_PAP.ToString();
        PRE_Text.text = Now_PResource.ToString() + "/" + Maximam_PResource.ToString();
    }

    //エネミー側のAPと資源を変更する関数
    public void EChange_REAP(int ap,int re)
    {
        Now_EAP = ap;
        Now_EResource = re;
        EAP_Text.text = Now_EAP.ToString() + "/" + Maximam_EAP.ToString();
        ERE_Text.text = Now_EResource.ToString() + "/" + Maximam_EResource.ToString();
    }
}