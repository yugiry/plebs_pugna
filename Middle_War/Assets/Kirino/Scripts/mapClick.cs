using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//[RequireComponent(typeof(AudioSource))]
public class mapClick : MonoBehaviour
{
    public static mapClick instance;

    public GameObject mapbatoru;
    public  int countrynum;//�N���b�N�������ɒl��^����
    public audio_Controller AC;
    public bool clear_flag;
    [SerializeField] mapfaito mapfaito;//�l�𑗂肽���X�N���v�g�̖��O
    [SerializeField] enemynemaplate enemynemaplate;//�l�𑗂肽���X�N���v�g�̖��O
    [SerializeField] SpriteRenderer change_color;
    PolygonCollider2D PColl;
    

    public static class Gamecountrynum
    {
       public static int countrynum;
    }



    private void Start()
    {
        PColl = this.GetComponent<PolygonCollider2D>();//�|���S�����擾
        instance = this;
    }

    private void Update()
    {
        if(mapbatoru.activeSelf)
        {
            PColl.enabled = false;//�Q�[���I�u�W�F�N�g��\��
            change_color.color = new Color(1, 1, 1, 1);//���݂̒l
        }
        else
        {
            PColl.enabled = true;//�Q�[���I�u�W�F�N�g�\��
        }
    }
   
    public void Cllik()
    {
        if (Input.GetMouseButtonDown(0) && !mapbatoru.activeSelf)//�{�^���ݒ�
        {
            mapbatoru.SetActive(true);//�}�b�v�{�[�h�\��
            mapfaito.Country_Num(countrynum);//mapfaito.cs�X�N���v�g�ɃN���b�N���ꂽcountrynum�̒l�𑗂�
            AC.map_select();
        }
    }

    public void pointer_enter()//�L�[�ݒ�
    {
        if (!mapbatoru.activeSelf)
        {
            change_color.color = new Color(1, 1, 0, 1);//�V�����l
        }
    }
  
    public void pointer_exit()//�L�[�ݒ�
    {
        if (!mapbatoru.activeSelf)
        {
            change_color.color = new Color(1, 1, 1, 1);//�V�����l
        }
    }
}
