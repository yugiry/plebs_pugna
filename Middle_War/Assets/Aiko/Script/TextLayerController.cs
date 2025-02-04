using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLayerController : MonoBehaviour
{
    //public string LayerName;
    //public int SortingOrder;

    public string LayerName;
    //public int SortingOrder;


    // Start is called before the first frame update
    void Start()
    {
        


        //レイヤーの名前

        //Order in Layerの数値
        this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 25;
    }

    // Update is called once per frame
    void Update()
    {

    }
}