using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject castlevalue;//�e�Q�[���I�u�W�F�N�g���錾
    public GameObject infantrystatus;
    public GameObject archerstatus;
    public GameObject catapultstatus;
    public GameObject castlevalue2;

    public void Click()//�N���b�N�ݒ�
    {
        castlevalue.SetActive(false);//�N���b�N���e�Q�[���I�u�W�F�N�g�\���E��\������
        infantrystatus.SetActive(false);
        archerstatus.SetActive(false);
        catapultstatus.SetActive(false);
        castlevalue2.SetActive(true);
    }
}
