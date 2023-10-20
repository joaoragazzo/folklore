using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    public TextMeshPro nameText;
    public TextMeshPro descriptionText;
    public Image iconImage;
    public TextMeshPro priceText;
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

    private void OnPurchaseButtonClicked()
    {
        bool success = upgrade.ApplyUpgrade();

        if (success)
        {
            // Opcionalmente, atualize a UI ou faça outras coisas se o upgrade foi bem-sucedido.
        }
        else
        {
            // Opcionalmente, informe ao jogador que a compra falhou.
        }
    }
}