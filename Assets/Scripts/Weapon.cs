using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem spark;
    public float offset;

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;
   

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        transform.rotation = rotation;

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                CreateSpark();
                timeBtwShots = startTimeBtwShots;
            }
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }

    void Shoot()
    {
        Instantiate(projectile, shotPoint.position, transform.rotation);
    }

    void CreateSpark()
    {
        spark.Play();
    }

    
}
