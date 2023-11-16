
using UnityEngine;


public class HeathBarUpdate : MonoBehaviour
{
    private float originalHealthSize;
    
    void Start()
    {
        originalHealthSize = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStatsController.Stats.Health >= 0)
        {
            transform.localScale = new Vector3(originalHealthSize * (PlayerStatsController.Stats.Health / PlayerStatsController.Stats.MaxHealth), 
                transform.localScale.y,
                transform.localScale.z
            );    
        }
    }
}
