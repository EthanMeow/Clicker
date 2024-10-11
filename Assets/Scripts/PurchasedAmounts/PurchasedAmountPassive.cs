using UnityEngine;
using TMPro;

public class PurchasedAmountDisplay : MonoBehaviour
{
    public AutoMoneyManager autoMoneyManager; // Reference to the AutoMoneyManager script
    public TextMeshProUGUI amountText; // Reference to the TextMeshProUGUI component for displaying the amount purchased

    void Update()
    {
        UpdatePurchasedAmountDisplay();
    }

    private void UpdatePurchasedAmountDisplay()
    {
        // Update the amount text to show the current purchase count
        amountText.text = $"Amount: {autoMoneyManager.purchaseCount}";
    }
}
