using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker_Spawn : MonoBehaviour
{
    [SerializeField] GameObject checker;
    [SerializeField] GameObject area;
    GameObject box;
    GameObject spawn;
    Unit_Check UC;
    TileInfo TI;

    void Start()
    {
        //ユニットが召喚可能か調べるオブジェクトを配置する
        box = GameObject.Find("Checker_Box");
        spawn = Instantiate(checker, new Vector3(area.transform.position.x, area.transform.position.y, area.transform.position.z - 1), Quaternion.identity);
        spawn.transform.parent = box.transform;
        UC = spawn.GetComponent<Unit_Check>();
        TI = area.GetComponent<TileInfo>();
        UC.tilenum = (int)TI.TileNum;
    }
}
