using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_SE : MonoBehaviour
{
    public GameObject obj;
    AudioSource button_Audio;
    AudioClip Source;
    bool first_hit = false;

    // Start is called before the first frame update
    public void Start()
    {
        button_Audio = obj.GetComponent<AudioSource>();
    }

    public void OnMouseEnter()
    {
        //マウスカーソルが重なったとき一度だけ音声を鳴らす
        if (first_hit == false) 
        {
           button_Audio.Play();
           first_hit = true;
        }
    }

    public void OnMouseExit()
    {
        //マウスカーソルが離れたら鳴るように戻す
        first_hit = false;
    }

}
