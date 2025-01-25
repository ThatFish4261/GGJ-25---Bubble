using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GameController gameController;

    void OnTriggerEnter(Collider col){
        if (col.tag == "SocialBubble"){
            gameController.StartCoroutine(gameController.NextLevel());
        }
    }
}
