using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayUpdate : MonoBehaviour
{
    private WorldInteraction worldInteraction;
    
    private TextMeshProUGUI dayCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        worldInteraction = new WorldInteraction();
        
        worldInteraction.Initialize();
        dayCounter = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        dayCounter.text = "DIA " + worldInteraction.worldStats.DayCounter;
    }
}
