using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] BubbleController bubbleController;
    [SerializeField] MainManager mainManager;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = FindAnyObjectByType<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

        }

        if (bubbleController.socialLevel <= 0f){
            StartCoroutine(LevelRestart());
        }
    }

    IEnumerator LevelRestart(){
        yield return new WaitForSecondsRealtime(0.75f);
        mainManager.LoseLife();
        
        if (mainManager.livesRemaining <= 0){
            mainManager.GameOver();
        }

        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public IEnumerator NextLevel(){
        yield return new WaitForSecondsRealtime(0.75f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
