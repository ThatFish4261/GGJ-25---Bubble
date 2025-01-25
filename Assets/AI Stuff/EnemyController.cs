using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] BubbleController bubbleController;
    [Range (1,5)] [SerializeField] int socLevDecreese;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if (col.tag == "SocialBubble"){
            bubbleController.EntityEnteredBubble(socLevDecreese);
        }
    }
}
