using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // ���̃I�u�W�F�N�g�̌��̈ʒu
    private Vector2 prePos;

    // ���̃I�u�W�F�N�g�̌��̐e
    private GameObject preParent;

    // �h���b�v�\�G���A
    public List<MonoBehaviour> dropArea;

    // �h���b�O�J�n���Ɏ��s����A�N�V����
    public Action beforeBeginDrag;

    // �h���b�v�������Ɏ��s����A�N�V����
    public Action<MonoBehaviour, Action> onDropSuccess;

    // �h���b�v�\�G���A�ȊO�Ƀh���b�v���ꂽ�Ƃ��̏���
    public Action<Action> onDropFail;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // �h���b�O�J�n���Ɏ��s����A�N�V���������s
        if (beforeBeginDrag != null)
        {
            beforeBeginDrag.Invoke();
        }
        // ���̃I�u�W�F�N�g�̌��̈ʒu�Ɛe��\�ߕۑ�
        prePos = transform.position;
        preParent = this.transform.parent.gameObject;
        // �ŏ�ʂɈړ�
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
                // �h���b�v�\�G���A�ɂ��̃I�u�W�F�N�g���܂܂��ꍇ
                onDropSuccess.Invoke(area, resetPos()); // ����1�F�h���b�v�����G���A�A����2�F�ʒu�����Ƃɖ߂��֐�
                isSuccess = true;
            }
        }

        // ���s������
        if (!isSuccess)
        {
            if (onDropFail == null)
            {
                // ���s���A�N�V���������ݒ�̏ꍇ�A�ʒu�����Ƃɖ߂�
                resetPos().Invoke();
            }
            else
            {
                // �A�N�V�����ݒ�ς݂Ȃ炻������s
                onDropFail.Invoke(resetPos());
            }
        }
    }

    private Action resetPos()
    {
        Action ret = () =>
        {
            // �ʒu�����Ƃɖ߂�
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