using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapselection : MonoBehaviour
{
    public GameObject mapsere;//�Q�[���I�u�W�F�N�g���錾
    public GameObject player;
    public GameObject player2;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject map;

    public void click()//�N���b�N�ݒ�
    {
        mapsere.SetActive(false);//�e�Q�[���I�u�W�F�N�g�\���E��\��
        player.SetActive(true);
        player2.SetActive(true);
        enemy.SetActive(true);
        enemy2.SetActive(true);
        map.SetActive(true);
    }
}
