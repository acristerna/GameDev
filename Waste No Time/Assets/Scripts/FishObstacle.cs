using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishObstacle : MonoBehaviour
{

    public int damage = 1;
    [SerializeField] int health = 100;
    [SerializeField] int scoreValue = 1;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // player takes damage !
            other.GetComponent<Player>().health -= damage;
            //Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
        else
        {

            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            health -= damageDealer.GetDamage();
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            if (health <= 0)
            {

                Destroy(gameObject);
            }
            Destroy(other.gameObject);

        }


    }
}
