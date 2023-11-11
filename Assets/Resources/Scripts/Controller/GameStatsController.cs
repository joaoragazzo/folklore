using UnityEngine;

public class GameStatsController: MonoBehaviour
{
    public static GameStatsController Stats { get; private set; }

    public bool gameOver { get; set; } = false;

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
}