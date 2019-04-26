using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicTransition : MonoBehaviour
{
    public static MusicTransition instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

    }
    public void musicStop(int currentScene)
    {

        if (currentScene == 6)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        musicStop(y);
    }
}
