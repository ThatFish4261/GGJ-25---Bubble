using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] BubbleController bubbleController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            #if UNITY_STANDALONE
                    Application.Quit();
            #endif

            #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }

        if (bubbleController.socialLevel <= 0f){
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }
}
