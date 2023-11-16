
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    
    private float daySpeed;
    private float nightSpeed;
    private float totalCycle;
    private float _cycleTime = 0f;
    
    
    void Start()
    {
        
        // Calcula o tempo total do ciclo e a velocidade de rotação
        totalCycle = WorldStatsController.Stats.DayDurationInSeconds + WorldStatsController.Stats.NightDurationInSeconds;
        daySpeed = 180f / WorldStatsController.Stats.DayDurationInSeconds;
        nightSpeed = 180f / WorldStatsController.Stats.NightDurationInSeconds;
    }

    // Atualização é chamada uma vez por frame
    void Update()
    {
        if (!WorldStatsController.Stats.IsPaused)
        {
            _cycleTime += Time.deltaTime;
            float timeInCycle = _cycleTime % totalCycle;
            
            WorldStatsController.Stats.IsDay = timeInCycle < WorldStatsController.Stats.DayDurationInSeconds;
            
            float rotationChange = (WorldStatsController.Stats.IsDay ? daySpeed : nightSpeed) * Time.deltaTime;
            
            WorldStatsController.Stats.Time += rotationChange;
            
            transform.rotation = Quaternion.Euler(new Vector3(WorldStatsController.Stats.Time, 0, 0));
            
            if (timeInCycle < Time.deltaTime)
            {
                WorldStatsController.Stats.DayCounter++;
            }
            
            //Debug.Log("IS DAY: " + WorldStatsController.Stats.IsDay + " || TIME: " + WorldStatsController.Stats.Time);
        }
    }
}