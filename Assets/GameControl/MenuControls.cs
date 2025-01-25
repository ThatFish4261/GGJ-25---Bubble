using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    MainManager mainManager;
    
    // Start is called before the first frame update
    void Start()
    {
        mainManager = FindAnyObjectByType<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene("Level1 - Train");
        mainManager.livesRemaining = 5;
    }

    public void QuitGame(){
        #if UNITY_STANDALONE
                Application.Quit();
        #endif

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
