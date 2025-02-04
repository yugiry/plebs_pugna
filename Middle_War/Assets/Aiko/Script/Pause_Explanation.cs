using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Explanation : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>

    // Start is called before the first frame update
    public GameObject click;
    private GameObject canvas_all_ps;

    public Transform parent;
    
    public Sprite When_Open;
    public Sprite When_Close;
    int chan_frag = 0;

    
    public GameObject canvas;

    int i=0;

    public void Change_button()
    {
        //Vector3 tmp = GameObject.Find("Rule_Button").transform.position;

        //canvas = GameObject.Find("Canvas");
        Debug.Log(canvas.name);

        var img = GetComponent<Image>();
        
        switch(chan_frag)
        {
            case 0:

                //GameObject.Find("Rule_Button").transform.position = new Vector3(tmp.x - 80, tmp.y-25, tmp.z);

                img.sprite = When_Open;
                
                
                chan_frag++;
                break;
            default:

                //GameObject.Find("Rule_Button").transform.position = new Vector3(tmp.x+80, tmp.y+25, tmp.z);

                img.sprite = When_Close;
                
                
                chan_frag--;
                break;

        }

    }

    public void Button_Click()
    {
       

        i++;

        if(i>1)
        {
            i = 0;

        }
        
        switch(i)
        {
            case 0:
               
                Destroy(canvas_all_ps);
               
                break;
            default:
                //canvas_all_ps = Instantiate(click, new Vector3(44, 36, 1.0f), Quaternion.identity, parent) as GameObject;
                //canvas_all_ps = Instantiate(click, new Vector3(138, 86, 1.0f), Quaternion.identity, parent) as GameObject;350,250
                canvas_all_ps = Instantiate(click, new Vector3(170, 86, 1.0f), Quaternion.identity, parent) as GameObject;
                click.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
                canvas_all_ps.transform.SetParent(canvas.transform, false);

                break;
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

     void ResumeGame()
    {
        Time.timeScale = 1f;
       
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Destroy(canvas_all_ps);
            GetComponent<Image>().sprite = When_Close;
            i = 0;
            chan_frag = 0;
        }
    }

}
