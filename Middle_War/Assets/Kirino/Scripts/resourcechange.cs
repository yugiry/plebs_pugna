using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;
public class resourcechange : MonoBehaviour
{

    [SerializeField] Text resourceText;//�����e�L�X�g

    int maxresource = 999;//�����ő�
    float nowresource = 0;//��������

    // Start is called before the first frame update
    void Start()
    {
        resourceText.text = nowresource.ToString() + "/" + maxresource.ToString();//�����e�L�X�g�ύX����
    }

}
