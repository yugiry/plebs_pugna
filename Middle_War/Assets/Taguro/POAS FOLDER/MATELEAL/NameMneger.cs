using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NameMneger : MonoBehaviour
{
   
    InputField inputField;
    public static string name = "";
    void Start()
    {
        inputField = GetComponent<InputField>();//コンポーネントおよび初期化メソッドの実行

        DontDestroyOnLoad(gameObject);
    }

    public void InputLogger()
    {
        string inputValue = inputField.text;//Log出力用メソッド
        Debug.Log(inputValue);//入力値を取得してLogに出力し、初期化
        
        //</summary>
        name = inputValue;

    }

    //別のシーンから戻ってきても名前が入力した名前が表示されてる
    public void OnEndEdit(string text)
    {
        
    }
    

}

    