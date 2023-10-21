using System;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public WorldStats worldStats;
    
    private float daySpeed;
    private float nightSpeed;
    private float totalCycle;

   
    private void Awake()
    {
        worldStats = new WorldStats();
        worldStats.playerInteraction.Initialize();
    }

    
    void Start()
    {
        
        // Calcula o tempo total do ciclo e a velocidade de rotação
        totalCycle = worldStats.DayDurationInSeconds + worldStats.NightDurationInSeconds;
        daySpeed = 180f / worldStats.DayDurationInSeconds;
        nightSpeed = 180f / worldStats.NightDurationInSeconds;
    }

    // Atualização é chamada uma vez por frame
    void Update()
    {
        if (!worldStats.IsPaused)
        {
            float timeInCycle = Time.time % totalCycle;
            
            worldStats.IsDay = timeInCycle < worldStats.DayDurationInSeconds;
            
            float rotationChange = (worldStats.IsDay ? daySpeed : nightSpeed) * Time.deltaTime;
            
            worldStats.Time += rotationChange;
            
            transform.rotation = Quaternion.Euler(new Vector3(worldStats.Time, 0, 0));
            
            if (timeInCycle < Time.deltaTime)
            {
                worldStats.DayCounter++;
            }
            
            Debug.Log("IS DAY: " + worldStats.IsDay + " || TIME: " + worldStats.Time);
        }
    }
}