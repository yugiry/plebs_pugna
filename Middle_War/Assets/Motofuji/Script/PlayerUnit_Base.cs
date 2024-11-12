using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerUnit_Base : MonoBehaviour
{
    //タイル設置の最初の位置
    [NonSerialized] public float SetTileStart_X = -54;
    [NonSerialized] public float SetTileStart_Y = 54;
    [NonSerialized] public float SetTile_Z = 20;
    //タイルの大きさ
    [NonSerialized] public float TILESIZE_X = 4;
    [NonSerialized] public float TILESIZE_Y = 4;
    //マップサイズ
    [NonSerialized] public int MAPSIZE_X = 25;
    [NonSerialized] public int MAPSIZE_Y = 25;
    //タイル間の長さ
    [NonSerialized] public float TILESPACE = 0.5f;

    //敵ユニットへの攻撃行動(座標１、座標２、攻撃の最大範囲、攻撃の最小範囲、クリックしたオブジェクト)
    public void Attack_Unit(Vector3 p1, Vector3 p2, float max, float min, GameObject obj)
    {
        Vector3 v;
        v.x = p1.x - p2.x;
        v.y = p1.y - p2.y;
        v.x = Mathf.Abs(v.x);
        v.y = Mathf.Abs(v.y);
        if (v.x <= max * (TILESIZE_X + TILESPACE) && v.y <= max * (TILESIZE_Y + TILESPACE))
        {
            if (v.x >= min * (TILESIZE_X + TILESPACE) || v.y >= min * (TILESIZE_Y + TILESPACE))
            {

            }
        }
    }

    //城への攻撃行動()
    public void Attack_Castle()
    {

    }
}
