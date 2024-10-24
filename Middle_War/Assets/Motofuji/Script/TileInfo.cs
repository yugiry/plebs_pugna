using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public GameObject tile;
    public GameObject setunit;

    public float TILESIZE_X;
    public float TILESIZE_Y;
    public float TILESPACE;
    public float TileNum;

    private float TILE_X;
    private float TILE_Y;
    private float x, y;

    private bool setUnit;
    private int Unitnum;

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
        if (Unitnum == 0)
        {
            setUnit = true;
        }
        else
        {
            setUnit = false;
        }
    }

    public void OnClicked()
    {
        Debug.Log(TileNum);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Infantry")
        {
            Unitnum++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Infantry")
        {
            Unitnum--;
        }

    }

    public void SetUnit()
    {
        if (setUnit)
        {
            Debug.Log("ê›íuÇ≥ÇÍÇ‹ÇµÇΩÅB");
            Instantiate(setunit, new Vector3(tile.transform.position.x, tile.transform.position.y, 7.0f), Quaternion.identity);
        }
    }
}
