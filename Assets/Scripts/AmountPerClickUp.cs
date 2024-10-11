using UnityEngine;

public class ClickAmountModifier : MonoBehaviour
{
    public MoneyAdder moneyAdder; // Reference to the MoneyAdder script
    public int increaseAmount = 1; // Amount to increase per click
    public int baseCostToUpgrade = 5; // Base cost to upgrade the amount per click
    public int purchaseCount = 0; // Counter for how many times the upgrade has been purchased

    // Method to be called when the button is pressed
    public void ModifyClickAmount()
    {
        // Calculate the current cost based on the number of purchases
        int currentCostToUpgrade = baseCostToUpgrade * (purchaseCount + 1);

        // Check if there's enough money to make the upgrade
        if (moneyAdder.centralMoneyManager.money >= currentCostToUpgrade)
        {
            // Deduct the specified amount from total money
            moneyAdder.centralMoneyManager.money -= currentCostToUpgrade;

            // Increase the amount gained per click in MoneyAdder
            moneyAdder.amountPerClick += increaseAmount;

            // Increment the purchase count
            purchaseCount++;

            // Update the displayed text in CentralMoneyManager
            moneyAdder.centralMoneyManager.UpdateMoneyText();
        }
        else
        {
            Debug.Log("Not enough money to upgrade amount per click!");
        }
    }
}
