using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class castlhp : MonoBehaviour
{
    [SerializeField] Text hpText;//HP�e�L�X�g

    int maxhp = 35;//�ő�HP
    float nowhp = 35;//����HP

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();//HP�\������
    }

    // Update is called once per frame
    void Update()
    {
        if(nowhp == 0)
        {

        }
    }
  
    public void HitAttack(int hit)//HP�ύX
    {
        nowhp -= hit;
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();//HP�e�L�X�g�ύX����
    }
}