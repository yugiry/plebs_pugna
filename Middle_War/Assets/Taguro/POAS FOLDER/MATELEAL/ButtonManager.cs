using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject NameButton;
    public GameObject ShowName;
    TextNamemaneger TN;
   
  
    // Start is called before the first frame update
    void Start()
    {
       TN = ShowName.GetComponent<TextNamemaneger>();
    }

  
    public void onClick()
    {
        NameButton.SetActive(true);
        TN.Show_Name();
    }
}
