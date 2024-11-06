using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_TileColor_change : MonoBehaviour
{
   public GameObject Tile;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void OnMouseOver()
    {//マウスカーソルが乗ったとき
        //Tile = GameObject.Find("range tile(Clone)");
       
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 0.8f);
        //Tile.GetComponent<Renderer>().material.color = Color.blue;
        Debug.Log("change!");
    }

    public void OnMouseExit()
    {//マウスカーソルが降りたとき
        //Tile = GameObject.Find("range tile(Clone)");
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 0.4f);
        //Tile.GetComponent<Renderer>().material.color = Color.green;
        Debug.Log("not not!");
    }

    
}
