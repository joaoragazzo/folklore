using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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
    private List<IDamageble> hitObjectsDuringSwing;

    private void Start()
    {
        hitObjectsDuringSwing = new List<IDamageble>();
        initialRotation = transform.localRotation; 
        boxCollider = GetComponent<BoxCollider>(); // Obtenha o BoxCollider no mesmo GameObject.
    }

    private void Update()
    {
        
        rotationSpeed = PlayerStatsController.Stats.AxeRotateSpeed;
        returnSpeed = PlayerStatsController.Stats.AxeRotateSpeed;
        damageAmount = PlayerStatsController.Stats.Strength;



        if (Input.GetButtonDown("Fire1") && !isRotating && !isReturning && PlayerStatsController.Stats.CanFire)
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
            hitObjectsDuringSwing.Clear();
        }
    }

    private void PerformRotation()
    {
        PlayerStatsController.Stats.IsAttacking = true;
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        currentAngle += rotationThisFrame;

        transform.Rotate(Vector3.right, rotationThisFrame, Space.Self); // Gira em torno do eixo Y local.

        if (currentAngle >= 120f) // Pode ajustar este ângulo conforme necessário.
        {
            isRotating = false;
            isReturning = true;
        }
        PlayerStatsController.Stats.IsAttacking = true;
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

        if (damageableEntity != null && isRotating && !hitObjectsDuringSwing.Contains(damageableEntity)) // Se é uma entidade danificável e o machado está girando.
        {
            damageableEntity.TakeDamage(damageAmount);
            hitObjectsDuringSwing.Add(damageableEntity);
        }
    }
}
