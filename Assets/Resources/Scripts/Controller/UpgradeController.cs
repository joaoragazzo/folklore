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

    public int critMultiplierUpgradePrice = 30;
    public int droneTreeDamageUpgradePrice = 250;
    public int luckyUpgradePrice = 30;
    public int maxHealthUpgradePrice = 20;
    public int rifleDamageUpgradePrice = 10;
    public int shotgunDamageUpgradePrice = 10;
    public int sniperDamageUpgradePrice = 20;
    public int speedUpgradePrice = 20;
    public int strengthUpgradePrice = 35;
}