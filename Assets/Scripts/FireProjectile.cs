using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    
       //public Vector2 mousePosition = Input.mousePosition;
       public GameObject ammo;
       public GameObject gun;
       public GameObject player;
       public float spawnRate = 2;
       private float timer = 0;
    
    void spawnAmmo()
    {
        Instantiate(ammo, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }

    void fireAmmo()
    {
        
    }
}
