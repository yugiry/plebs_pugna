using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infan2 : MonoBehaviour
{
    [SerializeField] GameObject unitobj;
    GameObject obj;

    public GameObject castlevalue;//各オブジェクトの名前宣言
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
    float tile_x;//マップの一マス横座標設定
    float tile_y;//マップの一マス縦座標設定
    Vector3 mousepos;

    // Update is called once per frame
    void Update()
    {
        if (infantrystatus.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                uiobj = GameObject.Find("map");//マップタイル名
                reapobj = GameObject.Find("map");
                unitnum = uiobj.GetComponent<UI_Operate>().EUnit_Num;
                CMinfo = reapobj.GetComponent<CreateMap>();
                apnum = CMinfo.Now_EAP;
                renum = CMinfo.Now_EResource;
                apnum = apnum - consumed_AP;//マップに変更時敵AP消費
                renum = renum - consumed_Resource;
                if (unitnum < 20 && apnum >= 0 && renum >= 0)//条件設定
                {
                    mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//敵マウスポイント設定
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                    mousepos.x = mousepos.x + 54;//マウスポインター反応範囲横
                    mousepos.y = -mousepos.y + 54;//マウスポインター反応範囲縦
                    mousepos.z = 7.0f;
                    for (int y = 0; y < 25; y++)
                    {
                        for (int x = 0; x < 25; x++)
                        {
                            if (mousepos.x > (x * 4.5f) - 2 && mousepos.x < (x * 4.5f) + 2)//マウスポインター横軸升目計算
                            {
                                if (mousepos.y > (y * 4.5f) - 2 && mousepos.y < (y * 4.5f) + 2)//マウスポインター縦軸升目計算
                                {
                                    clickedGameObject = hit2d.transform.gameObject;
                                    if (clickedGameObject.name == "area2(Clone)")//クリック時マップタイトル名の各処理
                                    {
                                        obj = null;
                                        obj = Instantiate(unit_infantry, new Vector3(-54 + x * 4.5f, 54 - y * 4.5f, 14.0f), Quaternion.identity);//マップタイルにユニット召喚処理
                                        CMinfo.Character(apnum, renum, 1);
                                        obj.transform.parent = unitobj.transform;
                                        click = false;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (apnum < 0 || renum < 0)
                {
                    apnum += consumed_AP;// 現在のAP整理
                    renum += consumed_Resource;
                }
            }
        }
    }

    public void Click()//クリック時の処理
    {
        castlevalue.SetActive(false);//クリック時ゲームオブジェクト表示・非表示設定
        infantrystatus.SetActive(true);
        unitstatus1.SetActive(false);
        unitstatus2.SetActive(false);
        unitinfo.SetActive(false);
        click = true;
    }
}