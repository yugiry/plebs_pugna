using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker_Spawn : MonoBehaviour
{
    [SerializeField] GameObject checker;
    [SerializeField] GameObject area;
    GameObject box;
    GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        box = GameObject.Find("Checker_Box");
        spawn = Instantiate(checker, new Vector3(area.transform.position.x, area.transform.position.y, area.transform.position.z - 1), Quaternion.identity);
        spawn.transform.parent = box.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
