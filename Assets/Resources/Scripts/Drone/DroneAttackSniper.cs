using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DroneAttackSniper : MonoBehaviour
{
    public GameObject projectilePrefab; // O prefab do seu projétil; defina isso no inspetor da Unity.
    public float projectileSpeed = 20f; // A velocidade do seu projétil.
    public float fireRate = 0.5f; // Quantos tiros por segundo.
    private float nextTimeToFire = 0f; // Controla o tempo até o próximo tiro.
    [SerializeField] private LayerMask mouseColliderMask = new LayerMask();
    
    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseColliderMask))
        {
            Vector3 aimDir = (raycastHit.point - transform.position).normalized;
            if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
            {
                Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(aimDir, Vector3.up));
                
                nextTimeToFire = Time.time + 1f/fireRate;
            }
        }
        
    }
}
