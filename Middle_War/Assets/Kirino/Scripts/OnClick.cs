using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject panel;

    public Sprite newSprite;
    private Image image;

    void Start()
    {
        // SpriteRendererコンポーネントを取得します
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // クリックされた時に行いたい処理
        panel.SetActive(true);
        image.sprite = newSprite;
    }
}
