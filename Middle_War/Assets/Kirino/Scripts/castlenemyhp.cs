using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castlenemyhp : MonoBehaviour
{
    [SerializeField] Text hpText;//�GHP�e�L�X�g

    int maxhp = 35;//�GHP�ő�
    float nowhp = 35;//�GHP����

    GameObject c2;
    SpriteRenderer SR;
    [SerializeField] Sprite[] enemy_castle_image;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();//�GHP�\���ύX����

        //c2 = GameObject.Find("castle2(Clone)");
        //SR = c2.GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾
        //SR.sprite = enemy_castle_image[2];


    }

    // Update is called once per frame
    void Update()
    {
        if (c2 == null)
        {
            c2 = GameObject.Find("castle2(Clone)");
            SR = c2.GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾
                                                   //SR.sprite = enemy_castle_image[2];

        }
        Debug.Log("�����I��");

        if (nowhp > 30)
        {
            SR.sprite = enemy_castle_image[0];
        }
        else if (nowhp > 20)
        {
            SR.sprite = enemy_castle_image[1];
        }

        if (nowhp == 0)
        {

        }
    }
}