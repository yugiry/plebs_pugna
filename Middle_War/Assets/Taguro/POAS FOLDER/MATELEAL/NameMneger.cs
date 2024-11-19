using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NameMneger : MonoBehaviour
{
    InputField inputField;

    void Start()
    {
        inputField = GetComponent<InputField>();//コンポーネントおよび初期化メソッドの実行

        InitInputField();//</summary>

        DontDestroyOnLoad(gameObject);
    }

    public void InputLogger()
    {
        string inputValue = inputField.text;//Log出力用メソッド
        Debug.Log(inputValue);//入力値を取得してLogに出力し、初期化

        InitInputField();//</summary>

    }

    void InitInputField()
    {


        inputField.ActivateInputField();//フォーカス

    }

}
    // Start is called before the first frame update
    //void Start()
    //{

    //    inputField = GameObject.Find("InputField").GetComponent<InputField>();
    //    DontDestroyOnLoad(gameObject);
    //}

    //public void GetInputName()
    //{
    //    string name = inputField.text;
    //    Debug.Log(name);
    //    DontDestroyOnLoad(gameObject);
    //}





