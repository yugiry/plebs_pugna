using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapClick : MonoBehaviour
{
    public GameObject mapbatoru;
    public int countrynum;//�N���b�N�������ɒl��^����

    [SerializeField] mapfaito mapfaito;//�l�𑗂肽���X�N���v�g�̖��O
    //[SerializeField] imagemap imagemap;//�l�𑗂肽���X�N���v�g�̖��O

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Cllik()
    {
        mapbatoru.SetActive(true);//�}�b�v�{�[�h�\��
        mapfaito.Show_country(countrynum);//mapfaito.cs�X�N���v�g�ɃN���b�N���ꂽcountrynum�̒l�𑗂�
        //imagemap.Shew_island(countrynum);//imagemap.cs�X�N���v�g�ɃN���b�N���ꂽcountrynum�̒l�𑗂�
    }
}
