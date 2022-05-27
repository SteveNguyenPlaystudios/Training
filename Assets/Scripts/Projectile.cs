using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damge;
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private float distance;
    [SerializeField]
    private LayerMask whatIsSolid;
    [SerializeField]
    private GameObject destroyEffect;
    [SerializeField]
    private ParticleSystem dust;

    Animator cameraAnim;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        CreateDust();
        cameraAnim = Camera.main.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(damge);
                cameraAnim.SetTrigger("Shake");

            }
            DestroyProjectile();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void CreateDust()
    {
        dust.Play();
    }
}
