using System;
using UnityEngine;

public class WorldStatsController : MonoBehaviour
{
    public static WorldStatsController Stats { get; private set; }
    
    public int DayCounter { get; set; } = 0;
    public float Time { get; set; } = 0;
    public bool IsDay { get; set; } = true;
    public bool IsPaused { get; set; } = false;
    public int DayDurationInSeconds { get; set; } = 120;
    public int NightDurationInSeconds { get; set;  } = 210;


    private void Awake()
    {
        if (Stats == null)
        {
            Stats = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Pause()
    {
        IsPaused = true;
        PlayerStatsController.Stats.Freeze();
    }

    public void Unpause()
    {
        IsPaused = false;
        PlayerStatsController.Stats.Unfreeze();
    }
}