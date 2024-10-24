using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    //ポイント格納配列
    public Vector3[] points;

    private void OnDrawGizmos()
    {
        //配列に格納されている数値分処理をする
        for (int i = 0; i < points.Length; i++)
        {
            //色を指定
            Gizmos.color = Color.blue;

            //ポジション、半径
            Gizmos.DrawWireSphere(points[i], 0.5f);
        }
    }

    /// <summary>
    /// 引数で渡された数値と同じポイントの位置を返す
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector3 GetMovePointPosition(int index)
    {
        //敵の移動に必要なので先に記述しておく
        return points[index];
    }
}
