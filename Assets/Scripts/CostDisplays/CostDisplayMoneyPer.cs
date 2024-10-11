using UnityEngine;
using TMPro;

public class CostDisplay : MonoBehaviour
{
    public ClickAmountModifier clickAmountModifier; // Reference to the ClickAmountModifier script
    public TextMeshProUGUI costText; // Reference to the TextMeshProUGUI component for displaying the cost

    void Update()
    {
        UpdateCostDisplay();
    }

    private void UpdateCostDisplay()
    {
        // Calculate the current cost based on the number of purchases
        int currentCostToUpgrade = clickAmountModifier.baseCostToUpgrade * (clickAmountModifier.purchaseCount + 1);

        // Update the cost text
        costText.text = $"Cost: {currentCostToUpgrade}";
    }
}