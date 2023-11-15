using UnityEngine;

public class DifficultyStatsController: MonoBehaviour
{
    public static DifficultyStatsController Stats { get; private set; }


    /**
     * Quantidade de acréscimo por noite de quanto mobs máximos irão spawnar
     */
    public float DifficultyMaxEntitiesIncrementPerNight { get; private set; } = 1.25f;


    /*
     * Quantidade máxima de inimigos base na primeira noite
     */
    public float maxEntitiesForNightBase { get; private set; } = 10;
    
    
    /*
     * Atraso de spawn entre inimigos no mundo 
     */
    public float entitiesDelaySpawnBase { get; private set; } = 5f;

    /*
     * Diminuição de atraso de spawn entre inimigos no mundo
     */
    public float entitiesDelaySpawnDecrement { get; private set; } = 0.93f;
    
    
    /*
     * Aumento de vida dos inimigos por noite
     */
    public float corpoSecoHealthIncrement { get; private set; } = 1.10f;
    public float cucaHealthIncrement { get; private set; } = 1.025f;
    public float curupiraHealthIncrement { get; private set; } = 1.02f;
    public float mulaHealthIncrement { get; private set; } = 1.07f;
    public float saciHealthIncrement { get; private set; } = 1.05f;
    
    
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