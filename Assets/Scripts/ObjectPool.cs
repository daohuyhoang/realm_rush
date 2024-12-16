using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [Range(0.1f, 30f)]
    [SerializeField] float spawnTimer = 1f;
    [Range(0, 50)]
    [SerializeField] int poolSize = 5;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return;
            }
        }
    }
    
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
