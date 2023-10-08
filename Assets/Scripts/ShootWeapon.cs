using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint; // O ponto a partir do qual o projétil será disparado. Geralmente na ponta da arma.

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // O botão padrão de "Fire1" é o botão esquerdo do mouse.
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantie o projétil e ele começará a se mover na direção para a qual o jogador está olhando devido ao script de movimento do projétil.
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
