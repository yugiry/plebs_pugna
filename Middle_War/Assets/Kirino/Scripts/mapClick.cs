using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(AudioSource))]
public class mapClick : MonoBehaviour
{
    public GameObject mapbatoru;
    public int countrynum;//�N���b�N�������ɒl��^����
    public audio_Controller AC;
    public bool clear_flag;
    [SerializeField] mapfaito mapfaito;//�l�𑗂肽���X�N���v�g�̖��O
    //[SerializeField] imagemap imagemap;//�l�𑗂肽���X�N���v�g�̖��O
    [SerializeField] SpriteRenderer change_color;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
        //source = GetComponents<AudioSource>()[0];
    }
    public void PlayFootstepSE()
    {
       // source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        //source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void Cllik()
    {
        if (Input.GetMouseButtonDown(0) && !mapbatoru.activeSelf)
        {
            mapbatoru.SetActive(true);//�}�b�v�{�[�h�\��
            mapfaito.Show_country(countrynum);//mapfaito.cs�X�N���v�g�ɃN���b�N���ꂽcountrynum�̒l�𑗂�
            AC.map_select();
            //imagemap.Shew_island(countrynum);//imagemap.cs�X�N���v�g�ɃN���b�N���ꂽcountrynum�̒l�𑗂�
        }
    }

    public void pointer_enter()
    {
        change_color.color = new Color(1, 1, 0, 1);
    }

    public void pointer_exit()
    {
        change_color.color = new Color(1, 1, 1, 1);
    }
}
