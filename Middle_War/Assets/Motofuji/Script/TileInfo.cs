using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class TileInfo : MonoBehaviour
{
    public GameObject tile;
    public GameObject setunit;

    GameObject clickedGameObject;

    public float TILESIZE_X;
    public float TILESIZE_Y;
    public float TILESPACE;
    public float TileNum;

    private float TILE_X;
    private float TILE_Y;
    private float x, y;

    private bool setUnit;
    private int Unitnum;

    Vector3 mousepos;

    GameObject unitcheckobj;
    Unit_Tile_Check UTC;

    // Start is called before the first frame update
    void Start()
    {
        unitcheckobj = GameObject.Find("map");
        UTC = unitcheckobj.GetComponent<Unit_Tile_Check>();

        //���݂̍��W����}�b�v���W�𒲂ׂ�
        TILE_X = tile.transform.position.x + 54;
        TILE_Y = -tile.transform.position.y + 54;
        x = TILE_X / (TILESIZE_X + TILESPACE);
        y = TILE_Y / (TILESIZE_Y + TILESPACE);
        TileNum = y * 25 + x;
        
        //�ړ��\�̃^�C���Ȃ炻�̃}�b�v���W��false�Ɉړ��s�Ȃ�true�ɂ���
        if (tile.name == "grass(Clone)" || tile.name == "water(Clone)" || tile.name == "area2(Clone)" || tile.name == "resource(Clone)")
        {
            UTC.tile[(int)TileNum] = false;
        }
        else
        {
            UTC.tile[(int)TileNum] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //���w�̃G���A�͂����Ɛi�s�s�\�ɂ���
        if(tile.name == "area1(Clone)" && UTC.tile[(int)TileNum] == false)
        {
            UTC.tile[(int)TileNum] = true;
        }
    }

    public void OnClicked()
    {
        Debug.Log(TileNum);
    }
}
