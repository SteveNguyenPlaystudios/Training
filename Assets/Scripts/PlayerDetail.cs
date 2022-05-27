using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetail : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;


    private float health;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamge(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Destroy(this.gameObject);            
        }
    }
}
