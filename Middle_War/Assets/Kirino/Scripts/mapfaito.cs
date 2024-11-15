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
                    text1.text = "自国";
                    text2.text = "どんどん敵国を攻め領土を拡張して天下統一を目指そう！！";
                    //Square = GetComponent<Square>();
                    //Square.sprite = newSprite;
                    Button.SetActive(false);
                    mapbatoru.transform.position = new Vector3(0, 0, 50);
                break;
                case 2:
                    text1.text = "フスラン";
                    text2.text = "できたばかりの国で国王の権力が低く攻め入りやすい！";
                //Square = GetComponent<Square>();
                //Square.sprite = newSprite;
                    Button.SetActive(true);
                    mapbatoru.transform.position = new Vector3(0, 0, 50);
                    break;
                case 3:
                    text1.text = "ア・タイリ";
                    text2.text = "できたばかりではないが国民のまとまりがなくあまり発展していない！";
                //Square = GetComponent<Square>();
                //Square.sprite = newSprite; 
                    Button.SetActive(true);
                    mapbatoru.transform.position = new Vector3(0, 0, 50);
                    break;
                case 4:
                    text1.text = "アイべり半島";
                    text2.text = "少し発展しており徐々に宗教が広まっている!!（宗教名ligare）";
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
    //        text2.text = "どんどん敵国を攻め領土を拡張して天下統一を目指そう！！";

    //        Button.SetActive(false);
    //        break;
    //    case 2:
    //        text1.text = "フスラン";
    //        text2.text = "できたばかりの国で国王の権力が低く攻め入りやすい！";

    //        //Button = ;
    //        mapbatoru.transform.position = new Vector3(20, 0, 0);
    //        break;
    //    case 3:
    //        text1.text = "ア・タイリ";
    //        text2.text = "できたばかりの国ではないが国民のまとまりがなくあまり発展していない国！";

    //        //Button = ;
    //        mapbatoru.transform.position = new Vector3(20, 0, 0);
    //        break;
    //    case 4:
    //        text1.text = "アイべり半島";
    //        text2.text = "少し発展しており徐々に宗教が広まっている!（宗教名ligare）";

    //        //Button = ;
    //        mapbatoru.transform.position = new Vector3(20, 0, 0);
    //        break;
    //    default:
    //        Debug.Log("Default");              
    //        break;
    //}
    //}
}