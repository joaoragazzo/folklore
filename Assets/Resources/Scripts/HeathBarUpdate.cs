using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeathBarUpdate : MonoBehaviour
{
    private PlayerInteraction playerInteraction = new PlayerInteraction(); 
    
    private float health;
    private float originalHealthSize;
    

    void Start()
    {
        playerInteraction.Initialize();
        
        if (playerInteraction.PlayerStats == null)
        {
            Debug.LogError("Erro: jogador não encontrado2");
            return;
        }
        
        originalHealthSize = transform.localScale.x;
        health = transform.localScale.x * (playerInteraction.PlayerStats.Health / playerInteraction.PlayerStats.MaxHealth); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInteraction.PlayerStats.Health >= 0)
        {
            transform.localScale = new Vector3(originalHealthSize * (playerInteraction.PlayerStats.Health / playerInteraction.PlayerStats.MaxHealth), 
                transform.localScale.y,
                transform.localScale.z
            );    
        }
    }
}
