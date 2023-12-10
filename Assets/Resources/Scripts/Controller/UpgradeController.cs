using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public static UpgradeController Stats;
    
    private void Awake()
    {
        if (Stats == null)
        {
            Stats = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int critMultiplierUpgradePrice { get; set; } = 30;
    public int droneTreeDamageUpgradePrice { get; set; } = 250;
    public int luckyUpgradePrice { get; set; } = 30;
    public int maxHealthUpgradePrice { get; set; } = 20;
    public int rifleDamageUpgradePrice { get; set; } = 10;
    public int shotgunDamageUpgradePrice { get; set; } = 10;
    public int sniperDamageUpgradePrice { get; set; } = 20;
    public int speedUpgradePrice { get; set; } = 20;
    public int strengthUpgradePrice { get; set; } = 35;
}