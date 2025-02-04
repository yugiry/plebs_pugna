using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private GameObject TileObj;    //タイルを召喚した時に子オブジェクトとして配置するためのオブジェクト
    Transform CastleTF;                             //召喚エリアを召喚する時に召喚する位置を調べるための変数
    GameObject Obj;                                 //召喚するオブジェクトを覚えておくための変数

    GameObject CN;              //DontDestroyで置いてあるオブジェクトの情報を取るための変数
    remenber_country_num RCN;   //現在選択されている国の番号を取るための変数

    [SerializeField] CPU_Controller CPUC;//CPUに関するスクリプトを読み取る変数

    [SerializeField] Unit_Tile_Check UTC;//タイルの情報に関するスクリプトを読み取る変数

    //オブジェクト
    //マップに生成するタイルの情報を取得する
    public GameObject Grass;        //草
    public GameObject Mountain;     //山
    public GameObject Water;        //水
    public GameObject Morewater;    //深い水
    public GameObject Castle1;      //城１
    public GameObject Area1;        //エリア１
    public GameObject Castle2;      //城２
    public GameObject Area2;        //エリア２
    public GameObject Resource;     //資源

    //タイル設置の最初の位置
    public float SetTileStart_X;
    public float SetTileStart_Y;
    public float SetTile_Z;
    //タイルの大きさ
    public float TileSize_X;
    public float TileSize_Y;
    //マップサイズ
    public int MapSize_X;
    public int MapSize_Y;
    //タイル間の長さ
    public float TileSpace;
    //現在設置しているタイルマップのマップ座標
    private int x, y;
    //現在設置しているタイルのワールド座標
    private float Set_X, Set_Y;

    //csvからマップ情報を取り出す
    private List<string> smap = new List<string>();
    public int[] map;
    //csvファイルの場所
    private string test_map = "Assets/alpha/Resources/map(stage2).csv";
    public string[] map_info;

    //playerAPの管理をする数値。
    int Maximam_PAP = 999;
    public int Now_PAP = 0;
    [SerializeField] Text PAP_Text;

    //player資源の管理をする数値。
    int Maximam_PResource = 999;
    public int Now_PResource = 0;
    [SerializeField] Text PRE_Text;

    //enemyAPの管理をする数値。
    const int Maximam_EAP = 999;
    public int Now_EAP = 0;
    [SerializeField] Text EAP_Text;

    //enemy資源の管理をする数値
    const int Maximam_EResource = 999;
    public int Now_EResource = 0;
    [SerializeField] Text ERE_Text;

    enum Tile
    {
        GRASS,//草
        MOUNTAIN,//山
        WATER,//水
        RESOURCE,//資源
        CASTLE1,//城１
        CASTLE2,//城２
        DEEP_WATER//深い水
    };

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

    //スタート関数
    void Start()
    {
        Application.targetFrameRate = 60;
        map = new int[MapSize_X * MapSize_Y];

        Load_Map();//マップ情報を読み込む

        Map_Creation();//マップをゲーム上に表示する

        //APと資源の初期化
        Now_PAP = 5;
        Now_PResource = 0;
        Now_EAP = 0;
        Now_EResource = 0;

        Obj = null;

        //APと資源の状況をテキストに表示
        PAP_Text.text = Now_PAP.ToString() + "/" + Maximam_PAP.ToString();
        PRE_Text.text = Now_PResource.ToString() + "/" + Maximam_PResource.ToString();
        EAP_Text.text = Now_EAP.ToString() + "/" + Maximam_EAP.ToString();
        ERE_Text.text = Now_EResource.ToString() + "/" + Maximam_EResource.ToString();

        CPUC.Map_Collect();//初期化が全て終わったことを送る
    }

    /// <summary>
    /// マップの情報をint型配列に読み込むための関数
    /// </summary>
    void Load_Map()
    {
        //ステージセレクトで選択したステージの番号によってマップ読み込みのcsvファイルを変更する
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

        //マップ情報の初期化
        for (int i = 0; i < MapSize_X * MapSize_Y; i++)
        {
            map[i] = -999;
        }

        //マップ情報の読み込み
        for (int i = 0; i < MapSize_X * MapSize_Y; i++)
        {
            map[i] = int.Parse(smap[i]);
        }
    }

    /// <summary>
    /// map配列からマップをゲームワールド上に生成をする関数
    /// </summary>
    void Map_Creation()
    {
        for (y = 0; y < MapSize_Y; y++)
        {
            for (x = 0; x < MapSize_X; x++)
            {
                //配列の位置をワールド座標に変換
                Set_X = SetTileStart_X + (TileSize_X + TileSpace) * x;
                Set_Y = SetTileStart_Y - (TileSize_Y + TileSpace) * y;
                //配列の数字毎にタイルの種類を変えて配置する
                switch (map[x + y * MapSize_Y])
                {
                    case (int)Tile.GRASS://草
                        Obj = Instantiate(Grass, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.MOUNTAIN://山
                        Obj = Instantiate(Mountain, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.WATER://水
                        Obj = Instantiate(Water, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.RESOURCE://資源
                        Obj = Instantiate(Resource, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.CASTLE1://PLAYER1の城
                        Obj = Instantiate(Castle1, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.CASTLE2://PLAYER2の城
                        Obj = Instantiate(Castle2, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                    case (int)Tile.DEEP_WATER://深い水
                        Obj = Instantiate(Morewater, new Vector3(Set_X, Set_Y, SetTile_Z), Quaternion.identity);
                        break;
                }
                Obj.transform.parent = TileObj.transform;
            }
        }
        //PLAYER1の城の周りにユニットの召喚可能エリアを配置する
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
        //PLAYER2の城の周りにユニットの召喚可能エリアを配置する
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

    //アップデート関数
    void Update()
    {
        //APや資源が上限を超えた場合上限に数値を戻す
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
    /// APと資源の変更をする関数<br/>
    /// chが0の時はプレイヤー、1の時はエネミーのAPと資源が変更される
    /// </summary>
    /// <param name="ap">ActionPointを持ってくる変数</param>
    /// <param name="re">Resourceを持ってくる変数</param>
    /// <param name="ch">プレイヤーかエネミーか判別する変数</param>
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