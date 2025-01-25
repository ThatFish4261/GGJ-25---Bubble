using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    SphereCollider col;
    public int socialLevel = 10;
    private Vector3 targetScale;
    [SerializeField] [Range (1, 10)] float LerpTimeMultiplier = 5f;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SphereCollider>();
        targetScale = new Vector3(socialLevel, socialLevel, socialLevel);  // Set initial target scale
    }

    // Update is called once per frame
    void Update()
    {
        // Smoothly interpolate between current scale and target scale
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * LerpTimeMultiplier);
    }

    public void EntityEnteredBubble(int socLevDecreese){
        socialLevel = socialLevel - socLevDecreese;
        targetScale = new Vector3(socialLevel, socialLevel, socialLevel);  // Update target scale
    }
}
