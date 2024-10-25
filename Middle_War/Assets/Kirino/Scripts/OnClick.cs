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
        // SpriteRenderer�R���|�[�l���g���擾���܂�
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // �N���b�N���ꂽ���ɍs����������
        panel.SetActive(true);
        image.sprite = newSprite;
    }
}
