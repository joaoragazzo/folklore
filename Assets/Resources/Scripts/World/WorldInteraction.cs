using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class WorldInteraction
{
    public DayNightCycle worldObject;
    public WorldStats worldStats;

    public void Initialize()
    {
        worldObject = GameObject.FindWithTag("World").GetComponent<DayNightCycle>();

        if (worldObject == null)
        {
            Debug.LogError("Mundo não encontrado!");
            return;
        }

        worldStats = worldObject.worldStats;
    }


}
