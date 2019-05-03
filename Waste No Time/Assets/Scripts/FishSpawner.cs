using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;
    private float timeBwtSpawn;
    public float startTimeBwtSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeBwtSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Debug.Log(rand);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBwtSpawn = startTimeBwtSpawn;
            if (startTimeBwtSpawn > minTime)
            {
                startTimeBwtSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBwtSpawn -= Time.deltaTime; 
        }
    }
}
