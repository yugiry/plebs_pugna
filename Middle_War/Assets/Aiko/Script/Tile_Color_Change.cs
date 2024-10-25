
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Tile_Color_Change : MonoBehaviour
{

    //マウスが重なったら色を濃くする
    public void OnPointerExit()
    {
        // Imageの取得
        Image image = this.GetComponent<Image>();
        // 0=透明 1=不透明なので、1.0で完全に不透明になる
        image.color = new Color(1.0f, 0.1401087f, 0.0f, 0.3f);
    }

    //マウスが外れたら色を戻す
    public void OnPointerEnter()
    {
        // Imageの取得
        Image image = this.GetComponent<Image>();
        // 0=透明 1=不透明なので、1.0で完全に不透明になる
        image.color = new Color(1.0f, 0.1401087f, 0.0f, 0.8f);
    }


}
