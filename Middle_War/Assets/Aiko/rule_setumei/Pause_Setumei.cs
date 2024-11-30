using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Setumei : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject click;
    private GameObject canvas_all_ps;

    public Transform parent;

    public Sprite When_Open;
    public Sprite When_Close;
    int chan_frag = 0;

    int i=0;
    public void Change_button()
    {
        var img = GetComponent<Image>();

        switch(chan_frag)
        {
            case 0:
                GetComponent<Image>().sprite = When_Open;
                chan_frag++;
                break;
            default:
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
                Debug.Log("bbbb");
                Destroy(canvas_all_ps);
               
                break;
            default:
                canvas_all_ps = Instantiate(click, new Vector3(0, 0, 15.0f), Quaternion.identity, parent) as GameObject;
                Debug.Log("aaaa");
                break;
        }


        //if (click.activeSelf)
        //{
        //    Debug.Log("bbbb");
        //    Destroy(canvas_all_ps);
        //    //click.SetActive(false);
        //    //ResumeGame();
        //}
        //else
        //{

        //    canvas_all_ps = Instantiate(click, new Vector3(0, 0, 15.0f), Quaternion.identity, parent) as GameObject;
        //    Debug.Log("aaaa");
        //}
        
        //else
        //{

        //    //click.SetActive(true);
        //    //PauseGame();
        //}



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

    void Start()
    {
        
    }
    int t = 0;
    // Update is called once per frame
    void Update()
    {
        
        
      //if(Input.GetMouseButtonUp(0)&&this.gameObject.name=="Rule_Button")
      //  {
      //      t++;
      //      if (t > 1) { t = 0; }

               
      //      Debug.Log(t);
      //      switch (t)
      //      {
      //          case 0:
      //              ResumeGame();
      //              break;
                
      //          case 1:
                    
      //              PauseGame();
      //              break;


      //      }


      //  }
        

    }
}
