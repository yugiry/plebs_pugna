using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMneger : MonoBehaviour
{
    public GameObject clickPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        clickPanel.SetActive(false); //��\��
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))//�E�N���b�N�������ꂽ��
        {
            clickPanel.SetActive(!clickPanel.activeSelf);//�A�N�e�B�u��Ԃ𔽓]
        }
    }
}
