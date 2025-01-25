using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveCounterUI : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] MainManager mainManager;
    string liveString;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = FindAnyObjectByType<MainManager>();
        liveString = mainManager.livesRemaining.ToString();
        text.text = liveString;
    }

    // Update is called once per frame
    void Update()
    {
        liveString = mainManager.livesRemaining.ToString();
        text.text = liveString;
    }
}
