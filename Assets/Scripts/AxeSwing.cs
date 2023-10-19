using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSwing : MonoBehaviour
{
    private float rotationSpeed = 120f;
    private float returnSpeed = 120f;
    public int damageAmount = 1;

    private bool isRotating = false;
    private bool isReturning = false;
    private float currentAngle = 0f;
    private Quaternion initialRotation;
    private BoxCollider boxCollider; // Referência para o BoxCollider.

    private void Start()
    {
        initialRotation = transform.localRotation; 
        boxCollider = GetComponent<BoxCollider>(); // Obtenha o BoxCollider no mesmo GameObject.
    }

    private void Update()
    {
        rotationSpeed = Player.axeRotationSpeed;
        returnSpeed = Player.axeRotationSpeed;
        damageAmount = Player.axeDamage;
        
        
        
        if (Input.GetButtonDown("Fire1") && !isRotating && !isReturning && Player.canShoot)
        {
            isRotating = true;
            currentAngle = 0f;
        }

        if (isRotating)
        {
            PerformRotation();
        }

        if (isReturning)
        {
            ReturnToInitialRotation();
        }
    }

    private void PerformRotation()
    {
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        currentAngle += rotationThisFrame;

        transform.Rotate(Vector3.right, rotationThisFrame, Space.Self); // Gira em torno do eixo Y local.

        if (currentAngle >= 120f) // Pode ajustar este ângulo conforme necessário.
        {
            isRotating = false;
            isReturning = true;
        }
    }

    private void ReturnToInitialRotation()
    {
        float rotationThisFrame = returnSpeed * Time.deltaTime;

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, initialRotation, rotationThisFrame);

        if (Quaternion.Angle(transform.localRotation, initialRotation) < 0.1f)
        {
            isReturning = false;
            transform.localRotation = initialRotation;
            currentAngle = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        IDamageble damageableEntity = other.GetComponent<IDamageble>();

        if (damageableEntity != null && isRotating) // Se é uma entidade danificável e o machado está girando.
        {
            
            damageableEntity.TakeDamage(damageAmount);
        }
        
    }
}
