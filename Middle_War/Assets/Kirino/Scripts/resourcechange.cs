using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;
public class resourcechange : MonoBehaviour
{

    [SerializeField] Text resourceText;//資源テキスト

    int maxresource = 999;//資源最大
    float nowresource = 0;//資源現在

    // Start is called before the first frame update
    void Start()
    {
        resourceText.text = nowresource.ToString() + "/" + maxresource.ToString();//資源テキスト変更処理
    }

}
