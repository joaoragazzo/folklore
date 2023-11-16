using System;
using UnityEngine;

public class WorldStatsController : MonoBehaviour
{
    public static WorldStatsController Stats { get; private set; }
    
    public int DayCounter { get; set; } = 1;
    public float Time { get; set; } = 0;
    public bool IsDay { get; set; } = true;
    public bool IsPaused { get; set; } = false;
    public int DayDurationInSeconds { get; set; } = 5;
    public int NightDurationInSeconds { get; set;  } = 210;
    public int enemiesExisting { get; set; } = 0; 

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

    private void Start()
    {
        Pause();
        Invoke("Unpause", GameStatsController.Stats.startTimeForPlayerStartPlaying);
    }
    
    public void Pause()
    {
        IsPaused = true;
        Debug.Log("Game is Paused!");
        PlayerStatsController.Stats.Freeze();
    }

    public void Unpause()
    {
        IsPaused = false;
        Debug.Log("Game is Unpaused!");
        PlayerStatsController.Stats.Unfreeze();
    }
}