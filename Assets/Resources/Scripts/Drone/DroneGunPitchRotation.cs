using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneGunPitchRotation : MonoBehaviour
{
    private PlayerInteraction playerIntearction;
    
    
    void Start()
    {
        playerIntearction = new PlayerInteraction();
        playerIntearction.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 hitPosition = playerIntearction.PlayerStats.Mouse3DPosition - transform.position;
        float pitchAngle = Mathf.Atan2(hitPosition.y, hitPosition.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(pitchAngle, transform.eulerAngles.y, transform.eulerAngles.z);
        transform.rotation = targetRotation;
    }
}
