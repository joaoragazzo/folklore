using UnityEngine;

public class EnemyMovement
{
    private PlayerStatsController _player;
    
    

    public (Vector3, Quaternion, bool) newPosition(Vector3 position, float walkSpeed, float attackDistance)
    {
        Vector3 newPosition = position;
        Quaternion newRotation = new Quaternion();
        
        Vector3 direcao = (PlayerStatsController.Stats.PlayerPosition - position).normalized;

        newPosition += direcao * walkSpeed * Time.deltaTime;
        newRotation = Quaternion.LookRotation(direcao);
        (newRotation.x, newRotation.z) = (0, 0);
        
        if (Vector3.Distance(position, PlayerStatsController.Stats.PlayerPosition) <= attackDistance)
        {
            position.y = 0;
            return (position, newRotation, true);
        }
        
        newPosition.y = 0;
        return (newPosition, newRotation, false);
    }


}
