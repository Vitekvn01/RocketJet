using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    public void LoadNextLeveL()
    {
        int currentlevelIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        int nextlevelIndex = currentlevelIndex + 1;
    
        if (nextlevelIndex == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            nextlevelIndex = 0;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextlevelIndex);
    }
    public void LoadFirstLeveL()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    
    }
