using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlayable;
    public bool IsPlayable {get => isPlayable;}
    void OnMouseDown()
    {
        if (isPlayable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlayable = !isPlaced;
        }
    }
}