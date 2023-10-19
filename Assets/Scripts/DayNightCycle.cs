using System;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Variáveis públicas para a duração do dia e da noite
    public float dayDuration = 120f; // 2 minutos
    public float nightDuration = 210f; // 3 minutos e 30 segundos

    // Variáveis estáticas
    public static bool isDay; // Indica se é dia
    public static int daysPassed = 0; // Conta os dias que passaram
    public static float currentRotation = 0; // Rotação acumulada
    
    // Variáveis internas
    private float daySpeed;
    private float nightSpeed;
    private float totalCycle;

    public static bool paused = false;

    // Inicialização
    void Start()
    {
        // Calcula o tempo total do ciclo e a velocidade de rotação
        totalCycle = dayDuration + nightDuration;
        daySpeed = 180f / dayDuration;
        nightSpeed = 180f / nightDuration;
    }

    // Atualização é chamada uma vez por frame
    void Update()
    {
        if (!paused)
        {
            // Calcula o tempo atual no ciclo
            float timeInCycle = Time.time % totalCycle;

            // Verifica se é dia ou noite
            isDay = timeInCycle < dayDuration;

            // Calcula a mudança na rotação
            float rotationChange = (isDay ? daySpeed : nightSpeed) * Time.deltaTime;

            // Acumula a rotação
            currentRotation += rotationChange;

            // Aplica a rotação
            transform.rotation = Quaternion.Euler(new Vector3(currentRotation, 0, 0));

            // Atualiza o contador de dias
            if (timeInCycle < Time.deltaTime)
            {
                daysPassed++; // Um novo dia começou
            }
        }
    }
}