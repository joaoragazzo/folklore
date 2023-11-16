
using UnityEngine;

public abstract class Upgrade
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public Sprite Image { get; protected set; }
    public int Price { get; protected set; }
    public int Max { get; protected set; }
    public int UpgradeIncrement { get; protected set; }
    
    
    public abstract bool ApplyUpgrade();
    
}
