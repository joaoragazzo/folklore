using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;

public class StoreController : MonoBehaviour
{
    public GameObject storeItemPrefab; 
    public Transform storeItemParent; 
        
    private List<Upgrade> availableUpgrades = new List<Upgrade>();

    void Start()
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
            StoreItem storeItem = itemObj.GetComponent<StoreItem>();
            storeItem.Setup(upgrade);
        }
    }
    
}