using UnityEngine;

public class EnemyMovement
{
    private PlayerInteraction playerInteraction;
    
    
    public EnemyMovement()
    {
        playerInteraction = new PlayerInteraction();
        playerInteraction.Initialize();
    }

    public (Vector3, Quaternion) newPosition(Vector3 position, float walkSpeed, float attackDistance)
    {
        Vector3 newPosition = position;
        Quaternion newRotation = new Quaternion();
        
        Vector3 direcao = (playerInteraction.PlayerStats.PlayerPosition - position).normalized;

        newPosition += direcao * walkSpeed * Time.deltaTime;
        newRotation = Quaternion.LookRotation(direcao);
        
        if (Vector3.Distance(position, playerInteraction.PlayerStats.PlayerPosition) <= attackDistance)
        {
            return (position, newRotation);
        }
        
        
        return (newPosition, newRotation);
    }


}
