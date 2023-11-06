using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCircleUpdate : MonoBehaviour
{

    private RectTransform rectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localRotation = Quaternion.Euler(0, 0, -(WorldStatsController.Stats.Time - 90));
    }
}
