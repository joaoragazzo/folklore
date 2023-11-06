using UnityEngine;

public class DifficultySetter: MonoBehaviour
{
    public static DifficultySetter instance { get; private set; }

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