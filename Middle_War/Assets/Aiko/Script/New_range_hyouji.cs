using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_range_hyouji : MonoBehaviour
{
    int range_flag = 0;

    public GameObject unit_click;
    public Transform parent;
    public GameObject base_point_unit;
    private GameObject unitclick;

    UnitTile UT;
    int tilenum_x;
    int tilenum_y;

    CreateMap CM;
    GameObject mapobj;

    GameObject apobj;
    // public APchange AP;

    float masume_size = 4.5f;
    public void Click_unit()
    {
        //unitclick = unit_click as GameObject; 
        if (this.gameObject.name == "Pinfantry(Clone)"/*&&range_flag!=0*/)
        {
            UT = this.gameObject.GetComponent<UnitTile>();
            tilenum_y = UT.Unit_TileNum / 25;
            tilenum_x = UT.Unit_TileNum % 25;
            //range_flag = 1;
            Destroy_Range();
            Destroy_Range();

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0)
                    {

                    }
                    else
                    {
                        unitclick = Instantiate(unit_click, new Vector3(CM.SetTileStart_X + (CM.TILESIZE_X + CM.TILESPACE) * (tilenum_x + x), CM.SetTileStart_Y - (CM.TILESIZE_Y + CM.TILESPACE) * (tilenum_y + y), 15.0f), Quaternion.identity, parent) as GameObject;
                    }
                }
            }

            Debug.Log("クリックされたぞい。");

            // Destroy(unitclick, 1);
        }
        //弓兵処理
        else if (this.gameObject.name == "Parcher(Clone)"/* && range_flag != 0*/)
        {
            UT = this.gameObject.GetComponent<UnitTile>();
            tilenum_y = UT.Unit_TileNum / 25;
            tilenum_x = UT.Unit_TileNum % 25;
            //range_flag = 1;
            Destroy_Range();
            Destroy_Range();

            for (int y = -2; y <= 2; y++)
            {
                for (int x = -2; x <= 2; x++)
                {
                    if (x == 0 && y == 0)
                    {
                        
                    }
                    else
                    {
                        unitclick = Instantiate(unit_click, new Vector3(CM.SetTileStart_X + (CM.TILESIZE_X + CM.TILESPACE) * (tilenum_x + x), CM.SetTileStart_Y - (CM.TILESIZE_Y + CM.TILESPACE) * (tilenum_y + y), 15.0f), Quaternion.identity, parent) as GameObject;
                    }
                }
            }
            Debug.Log("Archer clicked");
        }
        //カタパルト処理
        else if (this.gameObject.name == "Pcatapalt(Clone)"/* && range_flag != 0*/)
        {
            UT = this.gameObject.GetComponent<UnitTile>();
            tilenum_y = UT.Unit_TileNum / 25;
            tilenum_x = UT.Unit_TileNum % 25;
            //range_flag = 1;
            Destroy_Range();
            Destroy_Range();

            for (int y = -4; y <= 4; y++)
            {
                for (int x = -4; x <= 4; x++)
                {
                    if (x < -1 || x > 1 || y < -1 || y > 1)
                    {
                        unitclick = Instantiate(unit_click, new Vector3(CM.SetTileStart_X + (CM.TILESIZE_X + CM.TILESPACE) * (tilenum_x + x), CM.SetTileStart_Y - (CM.TILESIZE_Y + CM.TILESPACE) * (tilenum_y + y), 15.0f), Quaternion.identity, parent) as GameObject;
                    }
                }
            }
            Debug.Log("Catapult clicked");
        }



    }

    public void Destroy_Range()
    {
        GameObject[] unitclick = GameObject.FindGameObjectsWithTag("Respawn");

        if (unit_click.activeSelf)
        {
            //var unitclick = Instantiate(unit_click) as GameObject;
            foreach (GameObject range_child in unitclick)
            {
                Destroy(range_child);
                Debug.Log("destroy");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //unitclick= Instantiate(unit_click)/* as GameObject*/;

        mapobj = GameObject.Find("map");
        CM = mapobj.GetComponent<CreateMap>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    if (range_flag == 0)
        //    {
        //        range_flag = 1;
        //        Debug.Log("flag on!" + range_flag);
        //    }
        //    else if (range_flag == 1)
        //    {
        //        range_flag = 0;
        //        Destroy_Range();
        //        Debug.Log("flag off!" + range_flag);
        //    }
            //エラー発生　フラグオフの状態でユニット以外をクリック→エラー
            //仮説　マップタイルを読み込んでない状態でクリックしたから？
            //オペレーションにはマップタイルクリック時の処理がある
            //こちらのシーンではマップタイルが読み込めなかったためマップなしで実行している。
            //}
        //    if (Input.GetMouseButton(0))
        //    {
        //        Destroy_Range();
        //        //range_flag = 0;
        //    }
        //}
    }
}
