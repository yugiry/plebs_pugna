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
        inputField = GetComponent<InputField>();//�R���|�[�l���g����я��������\�b�h�̎��s

        DontDestroyOnLoad(gameObject);
    }

    public void InputLogger()
    {
        string inputValue = inputField.text;//Log�o�͗p���\�b�h
        Debug.Log(inputValue);//���͒l���擾����Log�ɏo�͂��A������
        
        //</summary>
        name = inputValue;

    }

    //�ʂ̃V�[������߂��Ă��Ă����O�����͂������O���\������Ă�
    public void OnEndEdit(string text)
    {
        
    }
    

}

    