using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackLv : MonoBehaviour
{
    public float health;
    public GameObject gameOver;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

    }
}
