
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Tile_Color_Change : MonoBehaviour
{

    //�}�E�X���d�Ȃ�����F��Z������
    public void OnPointerExit()
    {
        // Image�̎擾
        Image image = this.GetComponent<Image>();
        // 0=���� 1=�s�����Ȃ̂ŁA1.0�Ŋ��S�ɕs�����ɂȂ�
        image.color = new Color(1.0f, 0.1401087f, 0.0f, 0.3f);
    }

    //�}�E�X���O�ꂽ��F��߂�
    public void OnPointerEnter()
    {
        // Image�̎擾
        Image image = this.GetComponent<Image>();
        // 0=���� 1=�s�����Ȃ̂ŁA1.0�Ŋ��S�ɕs�����ɂȂ�
        image.color = new Color(1.0f, 0.1401087f, 0.0f, 0.8f);
    }


}
