using UnityEngine;

public class EnemyMovement
{
    private PlayerInteraction playerInteraction;
    
    
    public EnemyMovement()
    {
        playerInteraction = new PlayerInteraction();
        playerInteraction.Initialize();
    }

    public (Vector3, Quaternion, bool) newPosition(Vector3 position, float walkSpeed, float attackDistance, bool isAttacking)
    {
        Vector3 newPosition = position;
        Quaternion newRotation = new Quaternion();
        
        Vector3 direcao = (playerInteraction.PlayerStats.PlayerPosition - position).normalized;

        newPosition += direcao * walkSpeed * Time.deltaTime;
        newRotation = Quaternion.LookRotation(direcao);
        (newRotation.x, newRotation.z) = (0, 0);
        
        if (Vector3.Distance(position, playerInteraction.PlayerStats.PlayerPosition) <= attackDistance)
        {
            isAttacking = true;
            position.y = 0;
            return (position, newRotation, isAttacking);
        }

        isAttacking = false;
        newPosition.y = 0;
        return (newPosition, newRotation, isAttacking);
    }


}
