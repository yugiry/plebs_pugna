using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMneger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MidolWarText;
    // Start is called before the first frame update
    void Start()
    {
        MidolWarText.text = "";
        StartCoroutine("FadeIn");
    }

    // Update is called once per frame
    IEnumerator FadeIn()
    {
        MidolWarText.text = "MidolWar";
        while (true)
        {
            for (int i = 0; i < 255; i++)
            {
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
