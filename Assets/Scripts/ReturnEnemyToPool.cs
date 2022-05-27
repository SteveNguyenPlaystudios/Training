using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnEnemyToPool : MonoBehaviour
{
    public EnemyPool enemyPool;
    void Start()
    {
        enemyPool = FindObjectOfType<EnemyPool>();
    }

    public void OnDisable()
    {
        if (enemyPool != null)
        {
            enemyPool.ReturnEnemy(this.gameObject);
        }
    }

}
