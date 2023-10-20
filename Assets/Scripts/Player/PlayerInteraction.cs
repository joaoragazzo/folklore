using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction
{
    public Player PlayerScript;
    public PlayerStats PlayerStats;

    public void Initialize()
    {
        PlayerScript = GameObject.FindWithTag("Player").GetComponent<Player>();

        if (PlayerScript == null)
        {
            Debug.LogError("Jogador não encontrado!");
        }
        else
        {
            PlayerStats = PlayerScript.Stats;
        }
    }
}
