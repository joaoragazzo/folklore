using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;

public class UpgradeListController : MonoBehaviour
{
    public GameObject storeItemPrefab; 
    public Transform storeItemParent;
    public GameObject upgradeListItem;
    private bool isShowing = false;
        
    private List<Upgrade> availableUpgrades = new List<Upgrade>();
    
    private void Start()
    {
        var upgradeTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Upgrade))
                        && t.GetConstructor(Type.EmptyTypes) != null);

        // Instancia cada tipo de upgrade e adiciona à lista
        foreach (var type in upgradeTypes)
        {
            Upgrade upgrade = (Upgrade)Activator.CreateInstance(type);
            availableUpgrades.Add(upgrade);
        }
        
        foreach (var upgrade in availableUpgrades)
        {
            GameObject itemObj = Instantiate(storeItemPrefab, storeItemParent);
            UpgradeItem upgradeItem = itemObj.GetComponent<UpgradeItem>();
            upgradeItem.Setup(upgrade);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isShowing = !isShowing;
        }
        
        upgradeListItem.SetActive(isShowing);
    }
    
}