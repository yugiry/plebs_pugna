using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject NameButton;
    public GameObject ShowName;
    Savedname TN;//Savednameを呼び出す
   
  
    // Start is called before the first frame update
    void Start()
    {
       TN = ShowName.GetComponent<Savedname>();//Savednameを選択
    }

  
    public void onClick()
    {
        NameButton.SetActive(true);//表示
        TN.Show_Name(); //Show_Nameを呼び出す
    }
}
