using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public GameObject storeItemPrefab; // Atribua o prefab do item da loja no editor
    public Transform storeItemParent; // O pai onde os itens da loja serão adicionados no UI.

    private List<Upgrade> availableUpgrades = new List<Upgrade>();

    void Start()
    {
        
        availableUpgrades.Add(new StrengthUpgrade());
        // Preencha a lista 'availableUpgrades' com seus upgrades.
        // Você pode fazer isso manualmente, ou se cada Upgrade é um ScriptableObject,
        // você pode carregá-los de um diretório.

        foreach (var upgrade in availableUpgrades)
        {
            GameObject itemObj = Instantiate(storeItemPrefab, storeItemParent);
            StoreItem storeItem = itemObj.GetComponent<StoreItem>();
            storeItem.Setup(upgrade);
        }
    }
}