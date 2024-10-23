using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIchange2 : MonoBehaviour
{
    public GameObject PanelGameObject;
    public Button button;

    private void Start()
    {
        bool isActive = false;

        button.onClick.AddListener(() =>
        {
            isActive = !isActive;
            PanelGameObject.SetActive(isActive);
        });
    }
}
