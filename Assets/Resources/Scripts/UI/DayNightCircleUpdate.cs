using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCircleUpdate : MonoBehaviour
{
    private WorldInteraction worldInteraction;
    private RectTransform rectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        worldInteraction = new WorldInteraction();
        worldInteraction.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localRotation = Quaternion.Euler(0, 0, -(worldInteraction.worldStats.Time - 90));
    }
}
