using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Attack_Range : MonoBehaviour
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
    
    float masume_size = 4.5f;
    public void Click_unit(int attack_cnt)
    {
        
        if (this.gameObject.name == "Pinfantry(Clone)")
        {
            UT = this.gameObject.GetComponent<UnitTile>();//UnitTileを取得
            tilenum_y = UT.Unit_TileNum / 25;
            tilenum_x = UT.Unit_TileNum % 25;
            
            Destroy_Range();//呼び出されたタイルの破壊
            Destroy_Range();//呼び出されたタイルの破壊

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0)//ユニットと同じ位置には
                    {
                        //何もしない
                    }
                    else
                    {
                        if (attack_cnt == 0)
                        {
                            unitclick = Instantiate(unit_click, new Vector3(CM.SetTileStart_X + (CM.TileSize_X + CM.TileSpace) * (tilenum_x + x), CM.SetTileStart_Y - (CM.TileSize_Y + CM.TileSpace) * (tilenum_y + y), 15.0f), Quaternion.identity, parent) as GameObject;
                            //指定座標にタイルのクローンを呼び出す
                        }
                    }
                }
            }
           
        }
        //弓兵処理
        else if (this.gameObject.name == "Parcher(Clone)")
        {
            UT = this.gameObject.GetComponent<UnitTile>();//UnitTileを取得
            tilenum_y = UT.Unit_TileNum / 25;
            tilenum_x = UT.Unit_TileNum % 25;
           
            Destroy_Range();//呼び出されたタイルの破壊
            Destroy_Range();//呼び出されたタイルの破壊

            for (int y = -2; y <= 2; y++)
            {
                for (int x = -2; x <= 2; x++)
                {
                    if (x == 0 && y == 0)//ユニットと同じ位置には
                    {
                        //何もしない
                    }
                    else
                    {
                        if (attack_cnt == 0)
                        {
                            unitclick = Instantiate(unit_click, new Vector3(CM.SetTileStart_X + (CM.TileSize_X + CM.TileSpace) * (tilenum_x + x), CM.SetTileStart_Y - (CM.TileSize_Y + CM.TileSpace) * (tilenum_y + y), 15.0f), Quaternion.identity, parent) as GameObject;
                            //指定座標にタイルのクローンを呼び出す
                        }
                    }
                }
            }
           
        }
        //カタパルト処理
        else if (this.gameObject.name == "Pcatapalt(Clone)")
        {
            UT = this.gameObject.GetComponent<UnitTile>();//UnitTileを取得
            tilenum_y = UT.Unit_TileNum / 25;
            tilenum_x = UT.Unit_TileNum % 25;
            
            Destroy_Range();//呼び出されたタイルの破壊
            Destroy_Range();//呼び出されたタイルの破壊

            for (int y = -4; y <= 4; y++)
            {
                for (int x = -4; x <= 4; x++)
                {
                    if (x < -1 || x > 1 || y < -1 || y > 1)
                    {
                        if (attack_cnt == 0)
                        {
                            unitclick = Instantiate(unit_click, new Vector3(CM.SetTileStart_X + (CM.TileSize_X + CM.TileSpace) * (tilenum_x + x), CM.SetTileStart_Y - (CM.TileSize_Y + CM.TileSpace) * (tilenum_y + y), 15.0f), Quaternion.identity, parent) as GameObject;
                            //指定座標にタイルのクローンを呼び出す
                        }

                    }

                }

            }
            
        }

    }

    public void Destroy_Range()
    {
        GameObject[] unitclick = GameObject.FindGameObjectsWithTag("Respawn");

        if (unit_click.activeSelf)
        {
            
            foreach (GameObject range_child in unitclick)//Respawnタグのついたオブジェクトを探し出して
            {
                Destroy(range_child);//破壊する
               
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mapobj = GameObject.Find("map");
        CM = mapobj.GetComponent<CreateMap>();
    }

}
