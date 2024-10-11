using UnityEngine;
using TMPro;

public class AutoMoneyManager : MonoBehaviour
{
    public CentralMoneyManager centralMoneyManager; // Reference to the central money manager
    public int autoIncreaseAmount = 0; // Start at 0 so the first purchase increases it by 1
    public int baseCostToBuy = 5; // Base cost to buy the automatic money increase
    public float autoIncreaseInterval = 5f; // Time in seconds between automatic increases

    private float timer;
    public int purchaseCount = 0; // Counter for how many times it's been bought
    private int totalAutoIncreases = 0; // Total amount of automatic increases purchased

    void Start()
    {
        timer = autoIncreaseInterval; // Set the initial timer
    }

    void Update()
    {
        if (purchaseCount > 0) // Only run if purchased at least once
        {
            timer -= Time.deltaTime; // Decrease the timer by the time passed since last frame
            if (timer <= 0f)
            {
                IncreaseMoneyAutomatically();
                timer = autoIncreaseInterval; // Reset the timer
            }
        }
    }

    public void PurchaseAutoIncrease()
    {
        // Calculate the current cost based on the number of purchases
        int currentCostToBuy = baseCostToBuy * (purchaseCount + 1);

        // Check if there's enough money to purchase
        if (centralMoneyManager.money >= currentCostToBuy)
        {
            centralMoneyManager.money -= currentCostToBuy; // Deduct the purchase cost
            purchaseCount++; // Increment the purchase counter
            totalAutoIncreases++; // Increment the total auto increases

            // Only increase autoIncreaseAmount here
            autoIncreaseAmount += 1;

            centralMoneyManager.UpdateMoneyText(); // Update the displayed text

            Debug.Log($"Purchased auto increase! Total purchases: {purchaseCount}, Total auto increases: {totalAutoIncreases}, Auto Increase Amount: {autoIncreaseAmount}");
        }
        else
        {
            Debug.Log("Not enough money to purchase!");
        }
    }

    private void IncreaseMoneyAutomatically()
    {
        centralMoneyManager.money += autoIncreaseAmount; // Increase money automatically
        centralMoneyManager.UpdateMoneyText(); // Update the displayed text
    }
}