using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class audio_Controller : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] float pitchRange = 0.1f;
    protected AudioSource source;

    bool PlaySound;
    public mapfaito MF;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        PlaySound = false;
    }

    private void Update()
    {
        if(PlaySound && !source.isPlaying)
        {
            MF.change_button();
        }
    }

    public void map_select()
    {
        source.PlayOneShot(clips[0]);
    }

    public void click_fight()
    {
        source.PlayOneShot(clips[1]);
        PlaySound = true;
    }
}
