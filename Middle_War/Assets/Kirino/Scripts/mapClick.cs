using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(AudioSource))]
public class mapClick : MonoBehaviour
{
    public GameObject mapbatoru;
    public int countrynum;//クリックした時に値を与える
    public audio_Controller AC;

    [SerializeField] mapfaito mapfaito;//値を送りたいスクリプトの名前
    //[SerializeField] imagemap imagemap;//値を送りたいスクリプトの名前

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
        if (Input.GetMouseButtonDown(0))
        {
            mapbatoru.SetActive(true);//マップボード表示
            mapfaito.Show_country(countrynum);//mapfaito.csスクリプトにクリックされたcountrynumの値を送る
            AC.map_select();
            //imagemap.Shew_island(countrynum);//imagemap.csスクリプトにクリックされたcountrynumの値を送る
        }
    }
}
