using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Hyouji : MonoBehaviour
{
    public int text_num;
    private Text my_text;

    public void Text_Kakikae()
    {
        switch(text_num)
        {
            case 0://����
                my_text.text = "\nUI��ʂɂ��郆�j�b�g�����N���b�N���Ă��玩���̐w�n�����N���b�N����Ə����ł���B\n�������A�����ɕK�v��AP�܂��͎���������Ȃ��Ə����ł��Ȃ��B";
            break;

            case 1://�ړ�
                my_text.text = "\n�ړ������������j�b�g�����N���b�N���Ă���s�������}�X�����N���b�N����Έړ��ł���B\n";
                break;

            case 2://�̎�
                my_text.text = "\n�t�B�[���h�}�b�v��ɂ��鎑�ނ܂ŕ������ړ������Ă��玑�ނ����N���b�N���邱�Ƃŉ�����ł���B\n";
                break;

            case 3://�U��
                my_text.text = "\n�U�����������j�b�g���˒����Ȃ�A�U�������������j�b�g�����N���b�N���āA�U�����������j�b�g�����N���b�N���鎖�ōU�����邱�Ƃ��ł���B\n�e���j�b�g�̍U���˒��̓��j�b�g�����N���b�N���Ă���}�E�X�z�C�[���ŃN���b�N����Ɗm�F�ł���B\n";
                break;
            case 4://��������
                my_text.text = "\n���R���G�̖{�w��HP��0�ɂ���Ώ����ƂȂ�B\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n����΂�I\n";
                break;
            case 5://�s�k����
                my_text.text = "\n�G�R�ɂ���Ď��R�̖{�w��HP��0�ɂ����Δs�k�ƂȂ�B\n";
                break;
            case 6://�t�B�[���h���
                my_text.text = "\n���ށc\n��c\n�R�c\n";
                break;
            case 7://���j�b�g���
                my_text.text = "\n�����c\t\n�|���c\t\n�J�^�p���g�c�������U�����\�ȍU�镺��B�U���͂������������R�X�g���ړ��Ɏg�p����AP�ʂ���������1�}�X�܂ŋߊ����Ɖ����ł��Ȃ��Ȃ��_������B\n";
                break;


        }


    }

    // Start is called before the first frame update
    void Start()
    {
        my_text = GameObject.Find("setumei").GetComponent<Text>();
        my_text.color = new Color(1.0f,1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
