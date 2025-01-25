using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnMenuReturn : MonoBehaviour
{
    GameObject removeObjs;

    // Start is called before the first frame update
    void Start()
    {
        removeObjs = GameObject.FindWithTag("RemoveOnFinish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
