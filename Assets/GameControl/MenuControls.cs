using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    MainManager mainManager;
    public GameObject aboutParent;
    public GameObject homeParent;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = FindAnyObjectByType<MainManager>();
        aboutParent.SetActive(false);
        homeParent.SetActive(true);

        aboutParent.SetActive(false);
    }

    private void Update(){
        Cursor.visible = true;
    }

    public void StartGame(){
        SceneManager.LoadScene("Level1 - Train");
        mainManager.livesRemaining = 1;
        Cursor.visible = false;
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
    }

    public void ToAbout(){
        aboutParent.SetActive(true);
        homeParent.SetActive(false);
    }

    public void Back(){
        aboutParent.SetActive(false);
        homeParent.SetActive(true);
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
