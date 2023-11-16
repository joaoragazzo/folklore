
using TMPro;
using UnityEngine;


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
        dayCounter.text = "DIA " + WorldStatsController.Stats.DayCounter;
    }
}
