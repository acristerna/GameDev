using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public float speed;
    public int damage;
    private Transform player;
    private Vector2 target;

    public GameObject destroyEffect;
    public GameObject explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            other.GetComponent<PlayerAttackLv>().TakeDamage(damage);
            // Debug.Log(other.GetComponent<PlayerAttackLv>().health);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
