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
        // SpriteRenderer�R���|�[�l���g���擾���܂�
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �摜��؂�ւ��܂�
            image.sprite = newSprite;
        }
    }
}
