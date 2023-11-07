using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void Update()
    {
        _animator.SetBool("isMoving", PlayerStatsController.Stats.IsMoving);

        // Obtem a velocidade do jogador no espaço do mundo
        Vector3 worldVelocity = PlayerStatsController.Stats.PlayerVelocity;
        
        // Transforma a velocidade do mundo para o espaço local do jogador
        Vector3 localVelocity = transform.InverseTransformDirection(worldVelocity);

        // Agora localVelocity.z reflete a velocidade para frente/para trás em relação à direção que o jogador está olhando
        float forwardSpeed = localVelocity.z / PlayerStatsController.Stats.WalkSpeed;

        // Normalizar a velocidade para uso nas animações (supondo que 1 seja a velocidade máxima para frente e -1 para trás)
        forwardSpeed = Mathf.Clamp(forwardSpeed, -1f, 1f);

        // Configurar as variáveis de animação de acordo
        _animator.SetFloat("VelocityW", forwardSpeed);
        
        // Obtem a velocidade do jogador no espaço do mundo
        worldVelocity = PlayerStatsController.Stats.PlayerVelocity;
        
        // Transforma a velocidade do mundo para o espaço local do jogador
        localVelocity = transform.InverseTransformDirection(worldVelocity);

        // Agora localVelocity.z reflete a velocidade para frente/para trás em relação à direção que o jogador está olhando
        forwardSpeed = localVelocity.x / PlayerStatsController.Stats.WalkSpeed;

        // Normalizar a velocidade para uso nas animações (supondo que 1 seja a velocidade máxima para frente e -1 para trás)
        forwardSpeed = Mathf.Clamp(forwardSpeed, -1f, 1f);

        // Configurar as variáveis de animação de acordo
        _animator.SetFloat("VelocityS", forwardSpeed);


    }
    
}