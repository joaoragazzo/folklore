
using UnityEngine;
using TMPro;

public class DaysSurvivedCounter : MonoBehaviour
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
        int day = WorldStatsController.Stats.DayCounter;
        if (day == 1)
        {
            dayCounter.text = "1 DIA";
        }
        else
        {
            dayCounter.text = day + " DIAS";    
        }
        
    }
}
