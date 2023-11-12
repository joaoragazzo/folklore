using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI amount;
    
    private Upgrade upgrade;

    public void Setup(Upgrade upgrade)
    {
        this.upgrade = upgrade;
        nameText.text = upgrade.Name;
        amount.text = "+0";
    }
    
    void Update()
    {
        amount.text = "+" + PlayerStatsController.Stats.CountAcressByName(upgrade.Name);
    }
    
}