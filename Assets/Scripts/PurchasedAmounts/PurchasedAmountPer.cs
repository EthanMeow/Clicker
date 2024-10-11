using UnityEngine;
using TMPro;

public class PurchaseCountDisplay : MonoBehaviour
{
    public ClickAmountModifier clickAmountModifier; // Reference to the ClickAmountModifier script
    public TextMeshProUGUI purchaseCountText; // Reference to the TextMeshProUGUI component for displaying the purchase count

    void Update()
    {
        UpdatePurchaseCountDisplay();
    }

    private void UpdatePurchaseCountDisplay()
    {
        // Update the text to show the current purchase count
        purchaseCountText.text = $"Purchases: {clickAmountModifier.purchaseCount}";
    }
}
