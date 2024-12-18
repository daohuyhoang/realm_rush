using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    [Range(0f, 5f)]
    [SerializeField] float speed = 1f;

    Enemy enemy;
    const string PATH_TAG = "Path";
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());    
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag(PATH_TAG);
        
        foreach (Transform child in parent.transform)
        {
            Tile tile = child.GetComponent<Tile>();
            if (tile != null)
            {
                path.Add(tile);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    
    IEnumerator FollowPath()
    {
        foreach (Tile tile in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = tile.transform.position;
            float travelPercent = 0f;
            
            transform.LookAt(endPosition);
            
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.StealGold();
    }
}
