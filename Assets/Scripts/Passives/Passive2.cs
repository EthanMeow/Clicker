using UnityEngine;
using TMPro;

public class AutoMoneyManager2 : MonoBehaviour
{
    public CentralMoneyManager centralMoneyManager; // Reference to the central money manager
    public int autoIncreaseAmount2 = 0; // Start at 0 so the first purchase increases it by 1
    public int baseCostToBuy2 = 5; // Base cost to buy the automatic money increase
    public float autoIncreaseInterval2 = 5f; // Time in seconds between automatic increases

    private float timer2;
    public int purchaseCount2 = 0; // Counter for how many times it's been bought
    private int totalAutoIncreases2 = 0; // Total amount of automatic increases purchased

    void Start()
    {
        timer2 = autoIncreaseInterval2; // Set the initial timer
    }

    void Update()
    {
        if (purchaseCount2 > 0) // Only run if purchased at least once
        {
            timer2 -= Time.deltaTime; // Decrease the timer by the time passed since last frame
            if (timer2 <= 0f)
            {
                IncreaseMoneyAutomatically2();
                timer2 = autoIncreaseInterval2; // Reset the timer
            }
        }
    }

    public void PurchaseAutoIncrease2()
    {
        // Calculate the current cost based on the number of purchases
        int currentCostToBuy2 = baseCostToBuy2 * (purchaseCount2 + 1);

        // Check if there's enough money to purchase
        if (centralMoneyManager.money >= currentCostToBuy2)
        {
            centralMoneyManager.money -= currentCostToBuy2; // Deduct the purchase cost
            purchaseCount2++; // Increment the purchase counter
            totalAutoIncreases2++; // Increment the total auto increases

            // Only increase autoIncreaseAmount here
            autoIncreaseAmount2 += 1;

            centralMoneyManager.UpdateMoneyText(); // Update the displayed text

            Debug.Log($"Purchased auto increase! Total purchases: {purchaseCount2}, Total auto increases: {totalAutoIncreases2}, Auto Increase Amount: {autoIncreaseAmount2}");
        }
        else
        {
            Debug.Log("Not enough money to purchase!");
        }
    }

    private void IncreaseMoneyAutomatically2()
    {
        centralMoneyManager.money += autoIncreaseAmount2; // Increase money automatically
        centralMoneyManager.UpdateMoneyText(); // Update the displayed text
    }
}