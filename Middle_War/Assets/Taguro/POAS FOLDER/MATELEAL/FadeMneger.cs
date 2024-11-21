using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeMneger : MonoBehaviour
{
    public GameObject fedePanel;

    [SerializeField] private Image _fadePanel;
    [SerializeField] private float _fedeTime;

    private float _fedeAlpha = 0.0f;
    private bool _isFadeIn = false; 

    // Start is called before the first frame update
    void Start()
    {
        _fedeAlpha = 1.0f;
        _isFadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFadeIn)
        {
            FadeIn();
        }
      
    }
    private void FadeIn()
    {
        _fedeAlpha -= Time.deltaTime / _fedeTime;

        if (_fedeAlpha <= 0.0f)
        {
            _fedeAlpha = 0.0f;
            _isFadeIn = false;
        }

        _fadePanel.color = new Color(_fadePanel.color.r, _fadePanel.color.g, _fadePanel.color.b, _fedeAlpha);
    }

   //フェードインパネルが1になったとき


}
