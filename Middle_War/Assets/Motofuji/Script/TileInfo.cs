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

    // Start is called before the first frame update
    void Start()
    {
        TILE_X = tile.transform.position.x + 54;
        TILE_Y = -tile.transform.position.y + 54;

        x = TILE_X / (TILESIZE_X + TILESPACE);
        y = TILE_Y / (TILESIZE_Y + TILESPACE);

        TileNum = y * 25 + x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked()
    {
        Debug.Log(TileNum);
    }
}
