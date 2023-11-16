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

    public float initialSceneDelayInSeconds { get; private set; } = 3f;
    public float startTimeForPlayerStartPlaying { get; private set; } = 12f;
    public float maxTimeForEntities { get; private set; } = 100f;
}