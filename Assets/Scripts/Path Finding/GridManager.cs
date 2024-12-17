using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    
    Dictionary<Vector2Int, Node> gird = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Gird { get { return gird; } } 

    void Awake()
    {
        CreateGird();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (gird.ContainsKey(coordinates))
        {
            return gird[coordinates];
        }

        return null;
    }

    void CreateGird()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                gird.Add(coordinates, new Node(coordinates, true));
                Debug.Log(gird[coordinates].coordinates + "=" + gird[coordinates].isWalkable);
            }
        }
    }
}
