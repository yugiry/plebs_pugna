using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class uniteClick : MonoBehaviour
{
    
    public GameObject unite;
    [SerializeField] Text Unite_state;
     

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void unite_Serect(int hp)
    {
        unite.SetActive(true);
        Unite_state.text ="ï‡ï∫Å@HP" + hp.ToString();
    }
    public void Dlete()
    {
        unite.SetActive(false); 
    }
}
