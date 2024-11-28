using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class on_mouse : MonoBehaviour
{
    public GameObject obj;
    AudioSource GameObject_Audio;
    AudioClip Source;
    bool first_hit = false;

    // Start is called before the first frame update
    public void Start()
    {
        GameObject_Audio = obj.GetComponent<AudioSource>();
    }

    public void OnMouseEnter()
    {
        if (first_hit == false)
        {
            GameObject_Audio.Play();
            first_hit = true;
        }
    }

    public void OnMouseExit()
    {
        first_hit = false;
    }
}
