using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade
{
    
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public Sprite Image { get; protected set; }
    public int Price { get; protected set; }

    private PlayerInteraction playerInteraction;
    

    public abstract bool ApplyUpgrade(PlayerStats playerstats);

    
}
