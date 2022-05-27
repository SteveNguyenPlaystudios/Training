using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private Animator enemyAnim;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float attackSpeed;


    private float attackRate;
    private ReturnEnemyToPool ememyPool;
    private int healthBase;
    private float delayForDeadAnim = 0.5f;
    private CircleCollider2D collider;




    private GameObject player;

    private void Awake()
    {
        healthBase = health;
        enemyAnim = GetComponentInChildren<Animator>();
        ememyPool = GetComponent<ReturnEnemyToPool>();
        collider = GetComponent<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attackSpeed <= attackRate)
            {
                player.GetComponent<PlayerDetail>().TakeDamge(damage);
                attackRate = 0f;
            }
            else
            {
                attackRate += Time.deltaTime;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attackSpeed <= attackRate)
            {
                player.GetComponent<PlayerDetail>().TakeDamge(damage);
                attackRate = 0f;
            }
            else
            {
                attackRate += Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            collider.enabled = false;
            enemyAnim.SetTrigger("Dead");
            this.Wait(delayForDeadAnim, () =>
            {
                health = healthBase;
                collider.enabled = true;
                ememyPool.OnDisable();
            });                     
        }
    }


    
}
