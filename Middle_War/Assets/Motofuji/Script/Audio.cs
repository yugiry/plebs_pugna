using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioClip []clips;
    AudioSource audioSource;
    public GameObject soundObj;
    public GameObject soundObj1;
    void Start()
    {
        //Componentを取得
        audioSource = soundObj.GetComponent<AudioSource>();
        audioSource = soundObj1.GetComponent<AudioSource>();
    }
    void Update()
    {
        //エスケープが押されたら
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.PlayOneShot(clips[0]);
        }

        //右クリックが押されたら
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("AAA");
            audioSource.PlayOneShot(clips[1]);
        }
    }
}