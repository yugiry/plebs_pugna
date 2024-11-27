using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(AudioSource))]
public class mapfaito : MonoBehaviour
{
    //[SerializeField] AudioClip[] clips;
    //[SerializeField] float pitchRange = 0.1f;
    //[SerializeField]GameObject button;
    //protected AudioSource mapselect;
    //protected AudioSource scenechange;
    //public GameObject mapfai;
    public int countrynum;
    public GameObject mapbatoru;
    [SerializeField] public Text text1;//１つ目のテキスト変換
    [SerializeField] public Text text2;//２つ目のテキスト変換
    public Image image; //画像表示
    public GameObject Button;//敵とのバトルボタン
    public Sprite[] newSprite;//画像表示追加
    public string NextScene;
    GameObject rcnobj;
    remenber_country_num RCN;

    //// Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        //mapselect = GetComponents<AudioSource>()[0];
        //scenechange = button.GetComponents<AudioSource>()[0];
        rcnobj = GameObject.Find("country_info");
        RCN = rcnobj.GetComponent<remenber_country_num>();
    }

    public void PlayFootstepSE()
    {
        //mapselect.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        //mapselect.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
    public void Show_country(int countrynum)
    { //mapClickから受け取った値を読み取る

        image.sprite = newSprite[countrynum - 1]; //画像表示

        switch (countrynum) //受け取った値別処理
        {
            case 1:
                text1.text = "自国"; //国名
                text2.text = "どんどん敵国を攻め領土を拡張して天下統一を目指そう！！"; //国説明
                Button.SetActive(false); //ボタン表示（自国はボタン表示しない）
                mapbatoru.transform.position = new Vector3(0, 0, 50); //国情報ボード表示位置
                RCN.country_num = countrynum;
                break;
            case 2:
                text1.text = "フスラン"; //国名
                text2.text = "できたばかりの国で国王の権力が低く攻め入りやすい！"; //国説明            
                Button.SetActive(true); //敵国はボタン表示する
                mapbatoru.transform.position = new Vector3(0, 0, 50); //国情報ボード表示位置
                RCN.country_num = countrynum;
                break;
            case 3:
                text1.text = "ア・タイリ"; //国名
                text2.text = "できたばかりではないが国民のまとまりがなくあまり発展していない！"; //国説明             
                Button.SetActive(true); //敵国はボタン表示する
                mapbatoru.transform.position = new Vector3(0, 0, 50); //国情報ボード表示位置
                RCN.country_num = countrynum;
                break;
            case 4:
                text1.text = "アイべり半島"; //国名
                text2.text = "少し発展しており徐々に宗教が広まっている!!（宗教名ligare）"; //国説明          
                Button.SetActive(true); //敵国はボタン表示する
                mapbatoru.transform.position = new Vector3(0, 0, 50); //国情報ボード表示位置
                RCN.country_num = countrynum;
                break;
            default:
                Debug.Log("Default"); //switch処理の最後
                break;
        }
    }

    public void change_button()
    {
        SceneManager.LoadScene(NextScene);
    }
}