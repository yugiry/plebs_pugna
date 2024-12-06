using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject castlevalue;
    public GameObject infantrystatus;
    public GameObject archerstatus;
    public GameObject catapultstatus;
    public GameObject castlevalue2;

    public void Click()
    {
        castlevalue.SetActive(false);
        infantrystatus.SetActive(false);
        archerstatus.SetActive(false);
        catapultstatus.SetActive(false);
        castlevalue2.SetActive(true);
    }
}
