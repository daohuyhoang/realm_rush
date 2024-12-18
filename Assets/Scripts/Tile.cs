using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlayable;
    
    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();
    
    public bool IsPlayable {get => isPlayable;}

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if (!isPlayable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }
    void OnMouseDown()
    {
        if (isPlayable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlayable = !isPlaced;
        }
    }
}