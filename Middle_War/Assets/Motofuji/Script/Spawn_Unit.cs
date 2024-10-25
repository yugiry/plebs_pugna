using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Unit : MonoBehaviour
{
    public GameObject infantry;

    public bool setunit;
    private bool pushmouse;
    private Vector3 mousepos;
    GameObject clickedGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (setunit && !pushmouse)
        {
            //ユニットをマウスの位置のタイルに移動させる
            if (Input.GetMouseButtonDown(0))
            {
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
                                clickedGameObject = hit2d.transform.gameObject;
                                if (clickedGameObject.name == "area1(Clone)")
                                {
                                    Debug.Log(clickedGameObject.name);
                                    Instantiate(infantry, new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 7.0f), Quaternion.identity);
                                    setunit = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        pushmouse = Input.GetMouseButtonDown(0);
        //右クリックしたら選択をキャンセルする
        if (Input.GetMouseButtonDown(1))
        {
            setunit = false;
        }
    }

    public void Set_Unit()
    {
        if(!setunit)
        {
            setunit = true;
            pushmouse = true;
        }
    }
}
