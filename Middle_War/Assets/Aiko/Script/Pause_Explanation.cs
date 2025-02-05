using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Explanation : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>

    // Start is called before the first frame update
    public GameObject click;
    private GameObject canvas_all_ps;

    public Transform parent;
    
    public Sprite When_Open;
    public Sprite When_Close;
    int chan_frag = 0;
    
    public GameObject canvas;

    public AudioClip click_sound;
    private AudioSource AudioSource;


    int i=0;

    public void Change_button()
    {
        AudioSource = this.gameObject.GetComponent<AudioSource>(); //オーディオソース取得

      

        var img = GetComponent<Image>();
        
        switch(chan_frag)
        {
            case 0:

                

                img.sprite = When_Open;
                
                
                chan_frag++;
                break;
            default:

                

                img.sprite = When_Close;
                
                
                chan_frag--;
                break;

        }

    }

    public void Button_Click()
    {

        AudioSource.PlayOneShot(click_sound);//効果音を再生する

        i++;

        if(i>1)
        {
            i = 0;

        }
        
        switch(i)
        {
            case 0:
               
                Destroy(canvas_all_ps);
               
                break;
            default:
               
                canvas_all_ps = Instantiate(click, new Vector3(0, 0, 1.0f), Quaternion.identity, parent) as GameObject;
                click.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
                canvas_all_ps.transform.SetParent(canvas.transform, false);

                break;
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    

    public void _Pause()
    {
        GetComponent<Image>().sprite = When_Close;
        Destroy(canvas_all_ps);
        i = 0;
        chan_frag = 0;
    }

    

}
