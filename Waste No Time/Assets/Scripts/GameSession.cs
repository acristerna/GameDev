using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    int score = 0;

    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

     public int GetScore()
    {
        return score;
    }

    public void ProgressScene(int currentScene)
    {

        if(currentScene == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
        if(score >= 25)
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            ProgressScene(y);
            score = 0;
        }


    }
}
