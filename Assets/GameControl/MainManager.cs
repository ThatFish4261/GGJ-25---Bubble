using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int livesRemaining = 5;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (livesRemaining <= 0){
            GameOver();
        }
    }

    public void LoseLife(){
        livesRemaining--;
    }

    public void GameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
