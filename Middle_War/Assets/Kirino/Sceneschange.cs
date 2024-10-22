using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sceneschange : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite newSprite;
    private Image image;
    void Start()
    {
        // SpriteRendererコンポーネントを取得します
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 画像を切り替えます
            image.sprite = newSprite;
        }
    }
}
