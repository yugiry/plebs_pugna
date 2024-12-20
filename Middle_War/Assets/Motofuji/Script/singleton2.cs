using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton2 : MonoBehaviour
{
    public static singleton2 instance
    {
        get; private set;
    }

    private void Awake()
    {
        //同じオブジェクトがあれば消す
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
