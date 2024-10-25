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
        if (Unitnum == 0)
        {
            setUnit = true;
        }
        else
        {
            setUnit = false;
        }

        if(setUnit)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

                    mousepos.x = mousepos.x + 54;
                    mousepos.y = -mousepos.y + 54;
                    //マウスの位置にあるタイルを探す
                    for (int i = 0; i < 25; i++)
                    {
                        for (int j = 0; j < 25; j++)
                        {
                            if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                            {
                                if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                                {
                                    if (clickedGameObject.name == "area1(Clone)")
                                    {
                                        Debug.Log(clickedGameObject.name);
                                        setunit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 7.0f);
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
}
