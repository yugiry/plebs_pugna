using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public GameObject tile;
    public float TILESIZE_X;
    public float TILESIZE_Y;
    public float TILESPACE;
    public float TileNum;

    private float TILE_X;
    private float TILE_Y;
    private float x, y;

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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("クリックされました。");
            Debug.Log(TileNum);
        }
    }
}
