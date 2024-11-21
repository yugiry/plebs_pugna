using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextNamemaneger : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = NameMneger.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
