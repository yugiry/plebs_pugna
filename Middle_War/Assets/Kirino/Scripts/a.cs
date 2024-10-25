using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class a: MonoBehaviour
{
    public GameObject circlePrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0f;

            GameObject newCircle = Instantiate(circlePrefab, position, Quaternion.identity);
            // Do something with newCircle here, if needed
        }
    }
}