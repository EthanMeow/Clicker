using UnityEngine;

public class ClickAmountModifier : MonoBehaviour
{
    public MoneyAdder moneyAdder; // Reference to the MoneyAdder script
    public int increaseAmount = 1; // Amount to increase per click
    public int baseCostToUpgrade = 5; // Base cost to upgrade the amount per click
    public int purchaseCount = 0; // Counter for how many times the upgrade has been purchased

    private void Start()
    {
        // Load the saved purchase count and amount per click
        LoadUpgradeData();
    }

    // Method to be called when the button is pressed
    public void ModifyClickAmount()
    {
        // Calculate the current cost based on the number of purchases
        int currentCostToUpgrade = baseCostToUpgrade * (purchaseCount + 1);

        // Check if there's enough money to make the upgrade
        if (moneyAdder.centralMoneyManager.money >= currentCostToUpgrade)
        {
            // Deduct the specified amount from total money
            moneyAdder.centralMoneyManager.SubtractMoney(currentCostToUpgrade);

            // Increase the amount gained per click in MoneyAdder
            moneyAdder.amountPerClick += increaseAmount;

            // Increment the purchase count
            purchaseCount++;

            // Save the upgrade data (purchase count and amount per click)
            SaveUpgradeData();

            // Update the displayed text in CentralMoneyManager
            moneyAdder.centralMoneyManager.UpdateMoneyText();
        }
        else
        {
            Debug.Log("Not enough money to upgrade amount per click!");
        }
    }

    // Save the purchase count and amount per click
    public void SaveUpgradeData()
    {
        PlayerPrefs.SetInt("PurchaseCount", purchaseCount);
        PlayerPrefs.SetInt("AmountPerClick", moneyAdder.amountPerClick);
        PlayerPrefs.Save();
        Debug.Log("Upgrade data saved: PurchaseCount = " + purchaseCount + ", AmountPerClick = " + moneyAdder.amountPerClick);
    }

    // Load the purchase count and amount per click
    public void LoadUpgradeData()
    {
        if (PlayerPrefs.HasKey("PurchaseCount"))
        {
            purchaseCount = PlayerPrefs.GetInt("PurchaseCount");
            moneyAdder.amountPerClick = PlayerPrefs.GetInt("AmountPerClick", moneyAdder.amountPerClick); // Default to current if none saved
            Debug.Log("Upgrade data loaded: PurchaseCount = " + purchaseCount + ", AmountPerClick = " + moneyAdder.amountPerClick);
        }
        else
        {
            Debug.Log("No upgrade data found. Using default values.");
        }
    }
}