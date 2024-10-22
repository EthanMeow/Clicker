using UnityEngine;
using TMPro;

public class AutoIncreaseCostDisplay : MonoBehaviour
{
    public AutoMoneyManager2 autoMoneyManager; // Reference to the AutoMoneyManager2 script
    public TextMeshProUGUI costText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        // Update the cost display at the start
        UpdateCostDisplay();
    }

    void Update()
    {
        // Continuously update the display in case the cost changes
        UpdateCostDisplay();
    }

    public void UpdateCostDisplay()
    {
        if (autoMoneyManager != null && costText != null)
        {
            int currentCost = autoMoneyManager.GetCurrentCost(); // Get the current cost
            costText.text = "Cost: " + currentCost; // Update the UI text
        }
        else
        {
            Debug.LogWarning("AutoMoneyManager2 or costText reference is not set.");
        }
    }
}
