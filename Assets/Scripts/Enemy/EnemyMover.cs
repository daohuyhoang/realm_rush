using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
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
            WayPoint wayPoint = child.GetComponent<WayPoint>();
            if (wayPoint != null)
            {
                path.Add(wayPoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    
    IEnumerator FollowPath()
    {
        foreach (WayPoint wayPoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = wayPoint.transform.position;
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
