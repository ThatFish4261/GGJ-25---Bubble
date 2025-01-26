using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    [SerializeField] public Canvas nonMenuCanvas;

    public Text text;
    [SerializeField] public Image textHolder;

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

        //------------------------------------//

        string activeScene = SceneManager.GetActiveScene().name;
        print(activeScene);

        text.enabled = false;

        nonMenuCanvas.enabled = true;

        if(activeScene == "Level1 - Train"){
            text.text = "There’s always something eery about coming home\nEverytime I have to pass someon\nIt gives me jitters from skin to bone\nI can’t even remember a time not like this\nOne where I haven’t wanted to be alone";
            text.enabled = true;
            textHolder.enabled = true;
            Cursor.visible = false;
            StartCoroutine(HideIntroText());
            
        }

        else if(activeScene == "Level2 - Mall"){
            text.text = "Even as a teenager, I couldn’t stand crowds\nFrom the kids running amuck to the obnoxious screamers,\nI’d want to put up my own shroud";
            text.enabled = true;
            textHolder.enabled = true;
            StartCoroutine(HideIntroText());
        }


        else if(activeScene == "Level3 - IceRink"){
            text.enabled = false;
            textHolder.enabled = false;
        }

        else if(activeScene == "Game Over" || activeScene == "Game Win" || activeScene == "Main Menu"){
            nonMenuCanvas.enabled = false;
            Cursor.visible = true;
        }

        else{
            text.enabled = false;
            textHolder.enabled = false;
        }
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            #if UNITY_STANDALONE
                    Application.Quit();
            #endif

            #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
    
    public void LoseLife(){
        livesRemaining--;
    }

    public void GameOver(){
        SceneManager.LoadScene("GameOver");
        Cursor.visible = true;
    }

    public IEnumerator HideIntroText(){
        yield return new WaitForSecondsRealtime(7.5f);

        textHolder.enabled = false;
        text.enabled = false;
    }
}
