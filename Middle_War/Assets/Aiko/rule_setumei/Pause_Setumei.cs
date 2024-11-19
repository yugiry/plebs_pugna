using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Setumei : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject click;

    public Sprite When_Open;
    public Sprite When_Close;
    int chan_frag = 0;

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
        if(click.activeSelf)
        {
            click.SetActive(false);
            //ResumeGame();
        }
        else
        {
            click.SetActive(true);
            //PauseGame();
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

    void Start()
    {
        
    }
    int t = 0;
    // Update is called once per frame
    void Update()
    {
        
        
      if(Input.GetMouseButtonUp(0)&&this.gameObject.name=="Rule_Button")
        {
            t++;
            if (t > 1) { t = 0; }

               
            Debug.Log(t);
            switch (t)
            {
                case 0:
                    ResumeGame();
                    break;
                
                case 1:
                    
                    PauseGame();
                    break;


            }


        }
        

    }
}
