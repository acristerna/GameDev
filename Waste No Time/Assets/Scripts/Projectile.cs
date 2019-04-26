using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;


    public GameObject explosionSound;
    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    private void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy MUST TAKE DAMAGE!");
                hitInfo.collider.GetComponent<Boss>().TakeDamage(damage);
            }

            DestroyProjectile();
        }
    

    transform.Translate(Vector2.right* speed * Time.deltaTime);
}

    void DestroyProjectile()
    {
        Instantiate(explosionSound, transform.position, Quaternion.identity);
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
