using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayUpdate : MonoBehaviour
{
    private TextMeshProUGUI dayCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        dayCounter = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        dayCounter.text = "DIA: " + DayNightCycle.daysPassed;
    }
}
