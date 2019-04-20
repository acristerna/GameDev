using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;
    public GameObject deathEffect;

    public Slider healthBar;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
  

        if (health <=25)
        {
            anim.SetTrigger("stageTwo");
        }
        if (health <= 0)
        {
            anim.SetTrigger("death");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwDamage <= 0)
            {
                other.GetComponent<Player>().health -= damage;
                Debug.Log("Player MUST TAKE DAMAGE!");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

    }
}
