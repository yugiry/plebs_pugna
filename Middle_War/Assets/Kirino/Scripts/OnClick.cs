using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject panel;//他から変数読み取り
    //ゲームオブジェクト名・変数宣言
    public Sprite newSprite;
    private Image image;

    void Start()
    {
        // SpriteRendererコンポーネントを取得します
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)//特定の場所をクリックすると条件内に入る
    {
        panel.SetActive(true); // クリックされた時プラン表示処理
        image.sprite = newSprite;//画像＝新しいスクリプト
    }
}
