using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class castlhp : MonoBehaviour
{
    [SerializeField] Text hpText;

    int maxhp = 35;
    float nowhp = 35;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(nowhp == 0)
        {

        }
    }
  
    public void HitAttack(int hit)
    {
        nowhp -= hit;
        hpText.text = nowhp.ToString() + "/" + maxhp.ToString();
    }
}