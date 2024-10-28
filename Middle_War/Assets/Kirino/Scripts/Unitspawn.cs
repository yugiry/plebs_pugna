//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(SpriteRenderer))]
//public class Unitspawn : MonoBehaviour
//{
//    [SerializeField] private DefenderData defenderData;

//    private void Start()
//    {
//        Initialize(defenderData);

//    }

//    public void Initialize(DefenderData defenderData)
//    {
//        this.defenderData = defenderData;

//        var spriteRenderer = GetComponent<SpriteRenderer>();
//        spriteRenderer.sprite = defenderData.unitSprite;
//    }

//    private void Update()
//    {
//        Vector3 mousePos = Input.mousePosition;
//        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
//        targetPosition.z = 0f;

//        Vector2Int gridPosition = Vector2Int.RoundToInt(targetPosition);

//        transform.position = new Vector3(gridPosition.x, gridPosition.y, 0f);
//    }

//}