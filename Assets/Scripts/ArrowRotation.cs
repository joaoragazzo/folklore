using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    private float previousRotation = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula a mudança na rotação desde a última frame
        float deltaRotation = -(DayNightCycle.currentRotation - previousRotation);

        // Normaliza a mudança na rotação para evitar a reversão após 90 graus
        if (deltaRotation < -180)
            deltaRotation += 360;
        else if (deltaRotation > 180)
            deltaRotation -= 360;

        // Aplica a mudança na rotação à seta
        transform.Rotate(new Vector3(0, 0, deltaRotation));

        // Armazena a rotação atual para a próxima frame
        previousRotation = DayNightCycle.currentRotation;
    }
}
