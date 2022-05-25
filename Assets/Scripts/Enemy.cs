using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreOfEnemy;
    public GameObject explosionWithPlayer;
    public GameObject explosionWithGround;
   
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyEnemyWithPlayer();
    
        } else if (collision.gameObject.CompareTag("Ground"))
        {
            DestroyEnemyWithGround();
        }
    }

    void DestroyEnemyWithPlayer()
    {
        Instantiate(explosionWithPlayer, transform.position, Quaternion.identity);
        ScoreIncrease();
        Destroy(gameObject);
    }

    void DestroyEnemyWithGround()
    {
        Instantiate(explosionWithGround, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    

    void ScoreIncrease()
    {
        ScoreScript.scoreValue += scoreOfEnemy;
    }
}
