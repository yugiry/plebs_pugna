using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Operation : MonoBehaviour
{
    public GameObject unit;
    public GameObject act1;
    public GameObject act2;
    public GameObject act3;
    public float Unit_X;
    public float Unit_Y;
    private bool pushmouse;

    public int hp;
    public int attack;
    public int spawn_ap;
    public int spawn_resource;
    public int move_ap;
    public int choice_move;

    GameObject clickedGameObject;

    private bool followmouse;
    private int tilenum;

    private float tile_x;
    private float tile_y;

    Vector3 mousepos;
    Vector3 vec;

    // Start is called before the first frame update
    void Start()
    {
        Unit_X = unit.transform.position.x;
        Unit_Y = unit.transform.position.y;
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = unit.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (act1.activeSelf)
        {
            //�U�����ړ����ύX
            if (Input.GetKeyDown(KeyCode.C))
            {
                choice_move++;
                if (choice_move > 1)
                {
                    choice_move = 0;
                }
            }
            switch (choice_move)
            {
                case 0://�ړ�
                    //���j�b�g���}�E�X�̈ʒu�̃^�C���Ɉړ�������
                    if (Input.GetMouseButtonDown(0))
                    {
                        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                        mousepos.x = mousepos.x + 54;
                        mousepos.y = -mousepos.y + 54;
                        mousepos.z = unit.transform.position.z;
                        tile_x = (unit.transform.position.x + 54) / (4.0f + 0.5f);
                        tile_y = (-unit.transform.position.y + 54) / (4.0f + 0.5f);
                        //�}�E�X�̈ʒu�ɂ���^�C����T��
                        for (float i = tile_y - 1; i <= tile_y + 1; i++)
                        {
                            for (float j = tile_x - 1; j <= tile_x + 1; j++)
                            {
                                if (((i == tile_y - 1 || i == tile_y + 1) && j == tile_x) || (i == tile_y && (j == tile_x - 1 || j == tile_x + 1)))
                                {
                                    if (mousepos.x > (j * 4.5f) - 2 && mousepos.x < (j * 4.5f) + 2)
                                    {
                                        if (mousepos.y > (i * 4.5f) - 2 && mousepos.y < (i * 4.5f) + 2)
                                        {
                                            clickedGameObject = hit2d.transform.gameObject;
                                            if (clickedGameObject.name != "mountain(Clone)" 
                                                && clickedGameObject.name != "resource(Clone)" 
                                                && clickedGameObject.name != "castle1(Clone)" 
                                                && clickedGameObject.name != "castle2(Clone)" 
                                                && clickedGameObject.name != "area2(Clone)"
                                                && clickedGameObject.name != "Pinfantry"
                                                && clickedGameObject.name != "Parcher"
                                                && clickedGameObject.name != "Pcatapalt")
                                            {
                                                //AP�̗ʂ𒲂ׂđ����Ȃ�ړ�
                                                Debug.Log(clickedGameObject.name);
                                                unit.transform.position = new Vector3(-54 + j * 4.5f, 54 - i * 4.5f, 7.0f);
                                                //clickmove = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    pushmouse = Input.GetMouseButtonDown(0);
                    break;
                case 1://�U��
                    if (Input.GetMouseButton(0))
                    {

                    }
                    break;
            }
            if (Input.GetMouseButtonDown(1))
            {
                act1.SetActive(false);
            }
        }
    }

    //���j�b�g��I������
    public void Unit_Serect()
    {
        if (!act1.activeSelf && !act2.activeSelf && !act3.activeSelf)
        {
            act1.SetActive(true);
        }
    }
}

