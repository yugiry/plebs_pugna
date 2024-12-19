using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject castlevalue;//各ゲームオブジェクト名宣言
    public GameObject infantrystatus;
    public GameObject archerstatus;
    public GameObject catapultstatus;
    public GameObject castlevalue2;

    public void Click()//クリック設定
    {
        castlevalue.SetActive(false);//クリック字各ゲームオブジェクト表示・非表示処理
        infantrystatus.SetActive(false);
        archerstatus.SetActive(false);
        catapultstatus.SetActive(false);
        castlevalue2.SetActive(true);
    }
}
