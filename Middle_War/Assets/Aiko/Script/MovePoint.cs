using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    //�|�C���g�i�[�z��
    public Vector3[] points;

    private void OnDrawGizmos()
    {
        //�z��Ɋi�[����Ă��鐔�l������������
        for (int i = 0; i < points.Length; i++)
        {
            //�F���w��
            Gizmos.color = Color.blue;

            //�|�W�V�����A���a
            Gizmos.DrawWireSphere(points[i], 0.5f);
        }
    }

    /// <summary>
    /// �����œn���ꂽ���l�Ɠ����|�C���g�̈ʒu��Ԃ�
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector3 GetMovePointPosition(int index)
    {
        //�G�̈ړ��ɕK�v�Ȃ̂Ő�ɋL�q���Ă���
        return points[index];
    }
}
