using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explanation : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>

    // Start is called before the first frame update
    private GameObject click;
    private GameObject canvas_all_ps;

    public Transform parent;

    public Sprite When_Open;
    public Sprite When_Close;
    int chan_frag = 0;

    

    int i = 0;

    public void Change_button()
    {
        click = parent.transform.Find("Canvas_PS_C").gameObject;

        //Vector3 tmp = GameObject.Find("Rule_Button").transform.position;

        var img = GetComponent<Image>();

        switch (chan_frag)
        {
            case 0:

                click.SetActive(true);
                click.transform.position = new Vector3(0, 0, 0.0f);//戻るボタンの位置を変更
                                                                   //GameObject.Find("Rule_Button").transform.position = new Vector3(tmp.x - 80, tmp.y-25, tmp.z);

                img.sprite = When_Open;


                chan_frag++;
                break;
            default:
               
                click.SetActive(false);
                //GameObject.Find("Rule_Button").transform.position = new Vector3(tmp.x+80, tmp.y+25, tmp.z);

                img.sprite = When_Close;


                chan_frag--;
                break;

        }

    }

    //public void Button_Click()
    //{
    //    i++;

    //    if (i > 1)
    //    {
    //        i = 0;

    //    }

    //    switch (i)
    //    {
    //        case 0:

    //            Destroy(canvas_all_ps);

    //            break;
    //        default:
    //            canvas_all_ps = Instantiate(click, new Vector3(0, 0, -25.0f), Quaternion.identity, parent) as GameObject;

    //            click.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    //            break;
    //    }

    //}

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;

    }



}
