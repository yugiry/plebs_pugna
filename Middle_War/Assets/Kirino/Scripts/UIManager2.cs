using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager2 : MonoBehaviour
{
    public GameObject castlevalue;//�e�Q�[���I�u�W�F�N�g���錾
    public GameObject infantrystatus;
    public GameObject archerstatus;
    public GameObject catapultstatus;
    public GameObject castlevalue2;

    public void Click()//�N���b�N�ݒ�
    {
        castlevalue.SetActive(false);//�N���b�N���e�Q�[���I�u�W�F�N�g�\���E��\������
        castlevalue2.SetActive(true);
        infantrystatus.SetActive(true);
        archerstatus.SetActive(true);
        catapultstatus.SetActive(true);
    }
}
