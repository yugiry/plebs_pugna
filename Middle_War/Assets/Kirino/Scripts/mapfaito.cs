using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mapfaito : MonoBehaviour
{
    public int countrynum;
    public GameObject mapbatoru;
    [SerializeField] public Text text1;
    [SerializeField] public Text text2;
    
   public GameObject Button;
    //string countrynum;
    public infan CI;
    //public Sprite newSprite;
    //private Square Square;

    //int number = mapClick.countrynum;

    //// Start is called before the first frame update
    //void Start() 
    //{
       
    //}
    
    public void show_country(int countrynum)
        {/* number = num;*/

            switch (countrynum)
            {
                case 1:
                    text1.text = "����";
                    text2.text = "�ǂ�ǂ�G�����U�ߗ̓y���g�����ēV�������ڎw�����I�I";
                    //Square = GetComponent<Square>();
                    //Square.sprite = newSprite;
                    Button.SetActive(false);
                    mapbatoru.transform.position = new Vector3(0, 0, 50);
                break;
                case 2:
                    text1.text = "�t�X����";
                    text2.text = "�ł����΂���̍��ō����̌��͂��Ⴍ�U�ߓ���₷���I";
                //Square = GetComponent<Square>();
                //Square.sprite = newSprite;
                    Button.SetActive(true);
                    mapbatoru.transform.position = new Vector3(0, 0, 50);
                    break;
                case 3:
                    text1.text = "�A�E�^�C��";
                    text2.text = "�ł����΂���ł͂Ȃ��������̂܂Ƃ܂肪�Ȃ����܂蔭�W���Ă��Ȃ��I";
                //Square = GetComponent<Square>();
                //Square.sprite = newSprite; 
                    Button.SetActive(true);
                    mapbatoru.transform.position = new Vector3(0, 0, 50);
                    break;
                case 4:
                    text1.text = "�A�C�ׂ蔼��";
                    text2.text = "�������W���Ă��菙�X�ɏ@�����L�܂��Ă���!!�i�@����ligare�j";
                //Square = GetComponent<Square>();
                //Square.sprite = newSprite;
                    Button.SetActive(true);
                    mapbatoru.transform.position = new Vector3(0, 0, 50);
                    break;
                default:
                    Debug.Log("Default");
                    break;
            }


    }

   
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //string countrynum;
    //}

    //public void show_country(int num)
    //{
    //int number = 1;

    //switch (num)
    //{
    //    case 1:
    //        text1.text = "";
    //        text2.text = "�ǂ�ǂ�G�����U�ߗ̓y���g�����ēV�������ڎw�����I�I";

    //        Button.SetActive(false);
    //        break;
    //    case 2:
    //        text1.text = "�t�X����";
    //        text2.text = "�ł����΂���̍��ō����̌��͂��Ⴍ�U�ߓ���₷���I";

    //        //Button = ;
    //        mapbatoru.transform.position = new Vector3(20, 0, 0);
    //        break;
    //    case 3:
    //        text1.text = "�A�E�^�C��";
    //        text2.text = "�ł����΂���̍��ł͂Ȃ��������̂܂Ƃ܂肪�Ȃ����܂蔭�W���Ă��Ȃ����I";

    //        //Button = ;
    //        mapbatoru.transform.position = new Vector3(20, 0, 0);
    //        break;
    //    case 4:
    //        text1.text = "�A�C�ׂ蔼��";
    //        text2.text = "�������W���Ă��菙�X�ɏ@�����L�܂��Ă���!�i�@����ligare�j";

    //        //Button = ;
    //        mapbatoru.transform.position = new Vector3(20, 0, 0);
    //        break;
    //    default:
    //        Debug.Log("Default");              
    //        break;
    //}
    //}
}