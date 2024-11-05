using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnclickMneger : MonoBehaviour
{
    public GameObject panel;
    GameObject infantry;
    RectTransform infantryRect;
    Vector3[] corners = new Vector3[4];
    Vector3 mousePosition = new Vector3();
    bool isCorrectRange = true;
    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        infantry = GameObject.Find("Pinfantry(Clone)");
        if (infantry != null)
        {
            if (Input.GetKeyDown(KeyCode.H))

                if (panel.activeSelf)
                {
                    panel.SetActive(false);
                }
                else if (!panel.activeSelf)
                {
                    panel.SetActive(true);

                }
        }
        }
    }
            //infantry = GameObject.Find("Pinfantry(Clone)");
            //if (infantry != null)
            //{
            //    mousePosition = Input.mousePosition;

            //    infantryRect = infantry.GetComponent<RectTransform>();
            //    infantryRect.GetWorldCorners(corners);

            //    isCorrectRange = true;
            //    if (mousePosition.x < corners[0].x || mousePosition.y < corners[0].y)
            //    {
            //        isCorrectRange = false;
            //    }
            //    if (mousePosition.x < corners[1].x || mousePosition.y > corners[1].y)
            //    {
            //        isCorrectRange = false;
            //    }
            //    if (mousePosition.x > corners[2].x || mousePosition.y > corners[2].y)
            //    {
            //        isCorrectRange = false;
            //    }
            //    if (mousePosition.x > corners[3].x || mousePosition.y < corners[3].y)
            //    {
            //        isCorrectRange = false;
            //    }
            //    if (isCorrectRange)
            //    {
            //        panel.SetActive(!panel.activeSelf);
            //    }


            //}

