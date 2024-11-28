using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_right : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    AudioSource audioSource;
    public GameObject soundObj;
    void Start()
    {
        //Component‚ðŽæ“¾
        audioSource = soundObj.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("AAA");
            audioSource.PlayOneShot(clips[0]);
        }
    }
}
