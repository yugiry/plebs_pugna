using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouseManager : MonoBehaviour
{
    public GameObject pausePanel;
   
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);//��\��
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//�G�X�P�[�v�������ꂽ��
        {
            pausePanel.SetActive(!pausePanel.activeSelf);//�A�N�e�B�u��Ԃ𔽓]������
        }
 
    }
   
}
