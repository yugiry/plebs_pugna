using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class nemaplate : MonoBehaviour
{
    [SerializeField] public Text text1;

    public int name;
    private Text nameText;

    void Start()
    {
         text1.text = NameMneger.name;
    }

    public void Show_Name()
    {

        nameText.text = NameMneger.name;//•Û‘¶‚µ‚½–¼‘O‚ð•\Ž¦‚·‚é
        DontDestroyOnLoad(gameObject);
    }
}
