using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // このオブジェクトの元の位置
    private Vector2 prePos;

    // このオブジェクトの元の親
    private GameObject preParent;

    // ドロップ可能エリア
    public List<MonoBehaviour> dropArea;

    // ドラッグ開始時に実行するアクション
    public Action beforeBeginDrag;

    // ドロップ完了時に実行するアクション
    public Action<MonoBehaviour, Action> onDropSuccess;

    // ドロップ可能エリア以外にドロップされたときの処理
    public Action<Action> onDropFail;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // ドラッグ開始時に実行するアクションを実行
        if (beforeBeginDrag != null)
        {
            beforeBeginDrag.Invoke();
        }
        // このオブジェクトの元の位置と親を予め保存
        prePos = transform.position;
        preParent = this.transform.parent.gameObject;
        // 最上位に移動
        this.transform.SetParent(transform.root.gameObject.transform, true);

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool isSuccess = false;
        foreach (MonoBehaviour area in dropArea)
        {
            if (contains(area.GetComponent<RectTransform>(), eventData))
            {
                // ドロップ可能エリアにこのオブジェクトが含まれる場合
                onDropSuccess.Invoke(area, resetPos()); // 引数1：ドロップしたエリア、引数2：位置をもとに戻す関数
                isSuccess = true;
            }
        }

        // 失敗時処理
        if (!isSuccess)
        {
            if (onDropFail == null)
            {
                // 失敗時アクションが未設定の場合、位置をもとに戻す
                resetPos().Invoke();
            }
            else
            {
                // アクション設定済みならそれを実行
                onDropFail.Invoke(resetPos());
            }
        }
    }

    private Action resetPos()
    {
        Action ret = () =>
        {
            // 位置をもとに戻す
            transform.position = prePos;
            this.transform.SetParent(preParent.transform, true);
        };
        return ret;
    }

   
    private bool contains(RectTransform area, PointerEventData target)
    {
        var selfBounds = GetBounds(area);
        var worldPos = Vector3.zero;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            area,
            target.position,
            target.pressEventCamera,
            out worldPos);
        worldPos.z = 0f;
        return selfBounds.Contains(worldPos);
    }

    private Bounds GetBounds(RectTransform target)
    {
        Vector3[] s_Corners = new Vector3[4];
        var min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        var max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
        target.GetWorldCorners(s_Corners);
        for (var index2 = 0; index2 < 4; ++index2)
        {
            min = Vector3.Min(s_Corners[index2], min);
            max = Vector3.Max(s_Corners[index2], max);
        }

        max.z = 0f;
        min.z = 0f;

        Bounds bounds = new Bounds(min, Vector3.zero);
        bounds.Encapsulate(max);
        return bounds;
    }

}