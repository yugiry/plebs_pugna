using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject NameButton;
    public GameObject ShowName;
    Savedname TN;//Savedname���Ăяo��
   
  
    // Start is called before the first frame update
    void Start()
    {
       TN = ShowName.GetComponent<Savedname>();//Savedname��I��
    }

  
    public void onClick()
    {
        NameButton.SetActive(true);//�\��
        TN.Show_Name(); //Show_Name���Ăяo��
    }
}
