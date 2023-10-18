using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float followDistance = 5.0f;
    public float safeDistance = 2.0f;
    public float moveSpeed = 5.0f;
    public Camera mainCamera; // A câmera principal do jogo, você precisa associar isso no Editor da Unity
    public int height = 20;
    
    private void Update()
    {
        if (playerTransform == null || mainCamera == null)
        {
            Debug.LogWarning("Player Transform ou Main Camera não está definido.");
            return;
        }

        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        // Movendo o drone para frente ou para trás, baseado na distância segura e de seguimento
        if (distanceToPlayer < safeDistance)
        {
            Vector3 newPosition = transform.position - directionToPlayer * moveSpeed * Time.deltaTime;
            newPosition.y = height;
            transform.position = newPosition;
        }
        else if (distanceToPlayer > followDistance)
        {
            Vector3 newPosition = transform.position + directionToPlayer * moveSpeed * Time.deltaTime;
            newPosition.y = height;
            transform.position = newPosition;
        }

        // Fazendo o drone olhar para a posição do mouse
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Se o raio atingir um objeto (supondo que seja o chão ou qualquer objeto em um layer específico), faça o drone olhar para esse ponto
            Vector3 lookAtPoint = hit.point;
            lookAtPoint.y = transform.position.y; // Mantém a altura do drone constante, remove isso se você quer que o drone olhe para cima/baixo
            transform.LookAt(lookAtPoint);
        }
    }
}
