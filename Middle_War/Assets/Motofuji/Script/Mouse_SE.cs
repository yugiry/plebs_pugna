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
        if (first_hit == false) 
        {
           button_Audio.Play();
           first_hit = true;
        }
    }

    public void OnMouseExit()
    {
        first_hit = false;
    }

}
