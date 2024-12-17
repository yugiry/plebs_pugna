using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Explanation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject click;
    private GameObject canvas_all_ps;

    public Transform parent;
    
    public Sprite When_Open;
    public Sprite When_Close;
    int chan_frag = 0;
    Vector3 tmp;
    

    int i=0;

    void Start()
    {
        
    }

    public void Change_button()
    {
        Vector3 tmp = GameObject.Find("Rule_Button").transform.position;

        var img = GetComponent<Image>();
        
        switch(chan_frag)
        {
            case 0:

                GameObject.Find("Rule_Button").transform.position = new Vector3(tmp.x - 80, tmp.y-25, tmp.z);

                GetComponent<Image>().sprite = When_Open;
                
                
                chan_frag++;
                break;
            default:

                GameObject.Find("Rule_Button").transform.position = new Vector3(tmp.x+80, tmp.y+25, tmp.z);

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
                canvas_all_ps = Instantiate(click, new Vector3(80, 25, 15.0f), Quaternion.identity, parent) as GameObject;
               
                break;
        }


        



    }

     void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("P");
    }

     void ResumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("R");
    }

    
    int t = 0;
    // Update is called once per frame
    void Update()
    {
        
        
     
        

    }
}
