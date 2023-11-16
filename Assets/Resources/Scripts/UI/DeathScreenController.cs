
using UnityEngine;

public class DeathScreenController : MonoBehaviour
{

    public GameObject deathScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameStatsController.Stats.gameOver) Debug.Log("GameOver was successful computed.");
        
        deathScreen.SetActive(GameStatsController.Stats.gameOver);
    }
}
