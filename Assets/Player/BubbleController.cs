using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    SphereCollider col;
    public int socialLevel = 10;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(socialLevel, socialLevel, socialLevel);
    }

    public void EntityEnteredBubble(int socLevDecreese){
        socialLevel = socialLevel - socLevDecreese;
    }
}
