using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class APchange : MonoBehaviour
{
    [SerializeField] Text apText;

    int maxAp = 999;//�ő��AP�\��
    float nowAp = 0;//�ŏ���AP�\��

    // Start is called before the first frame update
    void Start()
    {//�e�L�X�g�ύX
        apText.text = nowAp.ToString() + "/" + maxAp.ToString();
    }

}
