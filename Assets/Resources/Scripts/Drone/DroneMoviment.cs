using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class DroneFollow : MonoBehaviour
{
    private PlayerInteraction playerInteraction = new PlayerInteraction();
    
    public Transform playerTransform;
    public float followDistance = 3.0f;
    public float safeDistance = 2.0f;
    public float droneAvoidanceDistance = 2.0f; 
    public float moveSpeed = 5.0f;
    public Camera mainCamera; // A câmera principal do jogo, você precisa associar isso no Editor da Unity
    public int height = 5;
    private float verticalAmplitude = 0.5f;
    private float vertialFrequency = 1f;
    private float initialPhase;
    
    public float repulsionForce = 50.0f;

    
    private static List<DroneFollow> allDrones; // lista estática contendo todas as instâncias de drones

    private void Awake()
    {
        initialPhase = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
        
        if (allDrones == null)
        {
            allDrones = new List<DroneFollow>();
        }
        allDrones.Add(this); // adicionar este drone à lista quando é criado/inicializado
    }

    private void Start()
    {
        playerInteraction.Initialize();
        
    }

    private void Update()
    {
        float deltaTime = Time.timeSinceLevelLoad;
        float verticalMovement = Mathf.Sin(deltaTime * vertialFrequency + initialPhase) * verticalAmplitude;
        
        
        if (playerTransform == null || mainCamera == null)
        {
            Debug.LogWarning("Player Transform ou Main Camera não está definido.");
            return;
        }


        if (!playerInteraction.PlayerStats.IsRunning)
            moveSpeed = playerInteraction.PlayerStats.WalkSpeed * playerInteraction.PlayerStats.RunSpeedMultiplier - 3f;
        else
            moveSpeed = playerInteraction.PlayerStats.WalkSpeed * playerInteraction.PlayerStats.RunSpeedMultiplier - 1f;

        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        
        

        // Movendo o drone para frente ou para trás, baseado na distância segura e de seguimento
        if (distanceToPlayer < safeDistance)
        {
            Vector3 newPosition = transform.position - directionToPlayer * moveSpeed * Time.deltaTime;
            newPosition.y = height + verticalMovement;
            transform.position = newPosition;
        }
        else if (distanceToPlayer >= followDistance)
        {
            Vector3 newPosition = transform.position + directionToPlayer * moveSpeed * Time.deltaTime;
            newPosition.y = height + verticalMovement;
            transform.position = newPosition;
        }
        
        
        
        // Verifica a proximidade de outros drones e ajusta a posição para evitar colisão
        
        Vector3 totalRepulsionVector = Vector3.zero;
        foreach (var otherDrone in allDrones)
        {
            if (otherDrone != this)
            {
                float distanceToDrone = Vector3.Distance(transform.position, otherDrone.transform.position);

                if (distanceToDrone < droneAvoidanceDistance)
                {
                    // Calcula o vetor de repulsão. Quanto mais próximo o drone, maior a força.
                    Vector3 repulsionVector = (transform.position - otherDrone.transform.position).normalized;
                    repulsionVector /= distanceToDrone; // Aumenta a força à medida que a distância diminui
                    
                    totalRepulsionVector += repulsionVector;
                }
            }
        }
        
        GetComponent<Rigidbody>().AddForce(totalRepulsionVector * repulsionForce);
        
        
        // Fazendo o drone olhar para a posição do mouse

        if (playerInteraction.PlayerStats.CanTurn)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Se o raio atingir um objeto (supondo que seja o chão ou qualquer objeto em um layer específico), faça o drone olhar para esse ponto
                Vector3 lookAtPoint = hit.point;
                //lookAtPoint.y = transform.position.y; // Mantém a altura do drone constante, remove isso se você quer que o drone olhe para cima/baixo
              
                
                transform.LookAt(lookAtPoint);
            }
        }
    }
}
