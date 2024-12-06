using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager2 : MonoBehaviour
{
    public GameObject castlevalue;
    public GameObject infantrystatus;
    public GameObject archerstatus;
    public GameObject catapultstatus;
    public GameObject castlevalue2;

    public void Click()
    {
        castlevalue.SetActive(false);
        castlevalue2.SetActive(true);
        infantrystatus.SetActive(true);
        archerstatus.SetActive(true);
        catapultstatus.SetActive(true);

    }
}
