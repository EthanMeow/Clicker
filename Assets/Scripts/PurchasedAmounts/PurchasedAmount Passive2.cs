using UnityEngine;
using TMPro;

public class AutoIncreasePurchaseCountDisplay : MonoBehaviour
{
    public AutoMoneyManager2 autoMoneyManager; // Reference to the AutoMoneyManager2 script
    public TextMeshProUGUI purchaseCountText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        // Update the purchase count display at the start
        UpdatePurchaseCountDisplay();
    }

    void Update()
    {
        // Continuously update the display in case the purchase count changes
        UpdatePurchaseCountDisplay();
    }

    public void UpdatePurchaseCountDisplay()
    {
        if (autoMoneyManager != null && purchaseCountText != null)
        {
            int currentPurchaseCount = autoMoneyManager.purchaseCount2; // Get the current purchase count
            purchaseCountText.text = "Amount: " + currentPurchaseCount; // Update the UI text
        }
        else
        {
            Debug.LogWarning("AutoMoneyManager2 or purchaseCountText reference is not set.");
        }
    }
}
