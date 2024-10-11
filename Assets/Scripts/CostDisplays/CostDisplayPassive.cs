using UnityEngine;
using TMPro;

public class AutoMoneyCostDisplay : MonoBehaviour
{
    public TextMeshProUGUI costText; // Reference to the TextMeshProUGUI component for displaying the cost
    public AutoMoneyManager autoMoneyManager; // Reference to the AutoMoneyManager script

    void Update()
    {
        UpdateCostDisplay();
    }

    private void UpdateCostDisplay()
    {
        if (autoMoneyManager != null)
        {
            // Get the current cost directly from AutoMoneyManager
            int currentCost = autoMoneyManager.baseCostToBuy * (autoMoneyManager.purchaseCount + 1);
            costText.text = $"Cost: {currentCost}"; // Update the cost text
        }
        else
        {
            costText.text = "No upgrade available"; // Handle null reference
        }
    }
}
