using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject panel;//������ϐ��ǂݎ��
    //�Q�[���I�u�W�F�N�g���E�ϐ��錾
    public Sprite newSprite;
    private Image image;

    void Start()
    {
        // SpriteRenderer�R���|�[�l���g���擾���܂�
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)//����̏ꏊ���N���b�N����Ə������ɓ���
    {
        panel.SetActive(true); // �N���b�N���ꂽ���v�����\������
        image.sprite = newSprite;//�摜���V�����X�N���v�g
    }
}
