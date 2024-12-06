using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapselection : MonoBehaviour
{
    public GameObject mapsere;
    public GameObject player;
    public GameObject player2;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject map;

    public void click()
    {
        mapsere.SetActive(false);
        player.SetActive(true);
        player2.SetActive(true);
        enemy.SetActive(true);
        enemy2.SetActive(true);
        map.SetActive(true);
    }
}
