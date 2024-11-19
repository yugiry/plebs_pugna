using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Kirikae : MonoBehaviour
{
    public Sprite summon_gazou;

     Image images;
    public int image_num;

    public void Gazou_wo_Kirikaeyo()
    {
        var img = GameObject.Find("kirikae_I").GetComponent<Image>();
        Debug.Log(image_num);
        

        switch (image_num)
        {
            case 0:
                img.sprite = summon_gazou;
                break;
            case 1:
                images.sprite = summon_gazou;
                break;



        }
        Debug.Log("nooooooon....");

    }

    // Start is called before the first frame update
    void Start()
    {
        images = GameObject.Find("kirikae_I").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
