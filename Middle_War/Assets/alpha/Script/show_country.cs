using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_country : MonoBehaviour
{
    public int max_country;//�V�ׂ鍑�̍ő吔
    [SerializeField] GameObject[] country_clear;//�e���̃N���A�t���O��u���Ă����ϐ�

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < max_country; i++)
        {
            //�N���A�t���O�������Ă����玟�̍���\������
            if(country_clear[i - 1].transform.GetChild(0).gameObject.activeSelf)
            {
                country_clear[i].SetActive(true);
            }
        }
    }
}
