using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NameMneger : MonoBehaviour
{
    InputField inputField;

    void Start()
    {
        inputField = GetComponent<InputField>();//�R���|�[�l���g����я��������\�b�h�̎��s

        InitInputField();//</summary>

        DontDestroyOnLoad(gameObject);
    }

    public void InputLogger()
    {
        string inputValue = inputField.text;//Log�o�͗p���\�b�h
        Debug.Log(inputValue);//���͒l���擾����Log�ɏo�͂��A������

        InitInputField();//</summary>

    }

    void InitInputField()
    {


        inputField.ActivateInputField();//�t�H�[�J�X

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





