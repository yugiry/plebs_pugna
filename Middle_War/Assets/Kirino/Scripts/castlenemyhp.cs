using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castlenemyhp : MonoBehaviour
{
    [SerializeField] Text hpText;//�GHP�e�L�X�g

    int maxhp = 35;//�GHP�ő�
    float nowhp = 35;//�GHP����

    SpriteRenderer SR;
    [SerializeField] Sprite[] enemy_castle_image;

    GameObject MAP;
    Ecastlehp ECHP;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();//�GHP�\���ύX����

        //c2 = GameObject.Find("castle2(Clone)");
        //SR = c2.GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾
        //SR.sprite = enemy_castle_image[2];

        
        MAP = GameObject.Find("map");
        ECHP = MAP.GetComponent<Ecastlehp>();
        

    }
    public void HitAttack(int hit)
    {
        nowhp -= hit;
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();//HP�e�L�X�g�ύX����
    }
    // Update is called once per frame
    void Update()
    {
        if (SR == null)
        {
            
            SR = GameObject.Find("castle2(Clone)").GetComponent<SpriteRenderer>();//�I�u�W�F�N�g�̃X�v���C�g�����擾
                                                   //SR.sprite = enemy_castle_image[2];

        }
        

        Debug.Log("�����I��");

        //nowhp = Ecas_hp.Now_Hp;

       /* if (nowhp >= 30 && nowhp <= 35)
        {
            SR.sprite = enemy_castle_image[0];
        }
        else if (nowhp >= 20 && nowhp < 30)
        {
            SR.sprite = enemy_castle_image[1];
        }
        else if (nowhp >= 10 && nowhp < 20)
        {
            SR.sprite = enemy_castle_image[2];
        }*/

        if (nowhp == 0)
        {

        }
            
        
    }

   

}