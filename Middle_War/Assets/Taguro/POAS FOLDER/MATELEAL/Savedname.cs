using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Savedname : MonoBehaviour
{
    [SerializeField]
    private Text nameText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = NameMneger.name;//保存した名前を表示する
        //nameText.text = NameMneger.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show_Name()
    {
        
        nameText.text = NameMneger.name;//保存した名前を表示する
        DontDestroyOnLoad(gameObject);
    }
   
}
