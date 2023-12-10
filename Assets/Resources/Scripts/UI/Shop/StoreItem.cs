using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI priceText;
    public Image iconImage;
    public Button purchaseButton;

    private Upgrade upgrade;

    public void Setup(Upgrade upgrade)
    {
        this.upgrade = upgrade;

        nameText.text = upgrade.Name;
        descriptionText.text = upgrade.Description;
        iconImage.sprite = upgrade.Image;
        priceText.text = "$ " + upgrade.Price.ToString();
        
        purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);
    }

    public void OnPurchaseButtonClicked()
    {
        upgrade.ApplyUpgrade();
        priceText.text = "$ " + upgrade.Price;
    }

}