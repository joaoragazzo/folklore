using UnityEngine;

public class DifficultyStatsController: MonoBehaviour
{
    public static DifficultyStatsController instance { get; private set; }

    public int difficulty;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}