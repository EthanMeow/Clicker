using UnityEngine;

public class MoneyAdder : MonoBehaviour
{
    public CentralMoneyManager centralMoneyManager; // Reference to the central money manager
    public int amountPerClick = 1; // Amount to increase on button press

    // Method to be called when the button is pressed
    public void AddMoney()
    {
        // Increase the money counter by amountPerClick
        centralMoneyManager.money += amountPerClick;

        // Update the displayed text
        centralMoneyManager.UpdateMoneyText();
    }
}

