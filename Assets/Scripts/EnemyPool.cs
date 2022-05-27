using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Queue<GameObject> enemyPool = new Queue<GameObject>();
    [SerializeField]
    private int poolStartSize = 10;
    [SerializeField]
    private Transform[] spawnPoints;
    

    public static bool spawnAllowed;
    private float timeSinceSpawn;
    private float timeToSpawn = 3f;

    int randomSpawnpoint;
    private void Start()
    {
        spawnAllowed = true;
        for (int i = 0; i < poolStartSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemyPool.Enqueue(enemy);
            enemy.SetActive(false);
        }


    }

    public GameObject GetEnemy()
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        } 
        else
        {
            GameObject enemy = Instantiate(enemyPrefab);
            return enemy;
        }
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemyPool.Enqueue(enemy);
        enemy.SetActive(false );
    }

    private void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= timeToSpawn)
        {
            GameObject newEnemy = GetEnemy();
            randomSpawnpoint = Random.Range(0, spawnPoints.Length);
            newEnemy.transform.position = spawnPoints[randomSpawnpoint].transform.position;
            timeSinceSpawn = 0;
        }
    }
}
