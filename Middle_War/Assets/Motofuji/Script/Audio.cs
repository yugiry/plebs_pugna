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
        //Component���擾
        audioSource = soundObj.GetComponent<AudioSource>();
        audioSource = soundObj1.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//�G�X�P�[�v�������ꂽ��
        {
            audioSource.PlayOneShot(clips[0]);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("AAA");
            audioSource.PlayOneShot(clips[1]);
        }
    }
}