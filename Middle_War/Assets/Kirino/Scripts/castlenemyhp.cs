using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castlenemyhp : MonoBehaviour
{
    [SerializeField] Text hpText;//�GHP�e�L�X�g

    int maxhp = 35;//�GHP�ő�
    float nowhp = 35;//�GHP����
    // Start is called before the first frame update
    void Start()
    {
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();//�GHP�\���ύX����
    }

}
