using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infan2 : MonoBehaviour
{
    public GameObject castlevalue;
    public GameObject infantrystatus;

    public GameObject unitstatus1;
    public GameObject unitstatus2;

    private GameObject clickedGameObject;
    public GameObject unit_infantry;

    public int consumed_AP;
    public int consumed_Resource;

    public GameObject unitinfo;

    private GameObject uiobj;
    private GameObject reapobj;

    private CreateMap CMinfo;

    private int unitnum;
    private int apnum;
    private int renum;

    public bool click;
    float tile_x;
    float tile_y;
    Vector3 mousepos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (infantrystatus.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                uiobj = GameObject.Find("map");
                reapobj = GameObject.Find("map");
                unitnum = uiobj.GetComponent<UI_Operate>().EUnit_Num;
                CMinfo = reapobj.GetComponent<CreateMap>();
                apnum = CMinfo.Now_EAP;
                renum = CMinfo.Now_EResource;
                apnum = apnum - consumed_AP;
                renum = renum - consumed_Resource;
                if (unitnum < 20 && apnum >= 0 && renum >= 0)
                {
                    mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                    mousepos.x = mousepos.x + 54;
                    mousepos.y = -mousepos.y + 54;
                    mousepos.z = 7.0f;
                    for (int y = 0; y < 25; y++)
                    {
                        for (int x = 0; x < 25; x++)
                        {
                            if (mousepos.x > (x * 4.5f) - 2 && mousepos.x < (x * 4.5f) + 2)
                            {
                                if (mousepos.y > (y * 4.5f) - 2 && mousepos.y < (y * 4.5f) + 2)
                                {
                                    clickedGameObject = hit2d.transform.gameObject;
                                    if (clickedGameObject.name == "area2(Clone)")
                                    {
                                        //int jougen = 20;
                                        //if(jougen < 20)
                                        //{
                                        // jougen++;
                                        //Instantiate(unit_infantry, new Vector3(-54 + x * 4.5f, 54 - y * 4.5f, 7.0f), Quaternion.identity);
                                        //  }
                                        Instantiate(unit_infantry, new Vector3(-54 + x * 4.5f, 54 - y * 4.5f, 14.0f), Quaternion.identity);
                                        CMinfo.EChange_REAP(apnum, renum);
                                        click = false;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (apnum < 0 || renum < 0)
                {
                    apnum += consumed_AP;
                    renum += consumed_Resource;
                }
            }
        }
    }

    public void Click()
    {
        castlevalue.SetActive(false);
        infantrystatus.SetActive(true);
        unitstatus1.SetActive(false);
        unitstatus2.SetActive(false);
        unitinfo.SetActive(false);
        click = true;
    }
}