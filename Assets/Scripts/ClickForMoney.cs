using UnityEngine;

public class MoneyAdder : MonoBehaviour
{
    public CentralMoneyManager centralMoneyManager; // Reference to the central money manager
    public int amountPerClick = 1; // Amount to increase on button press

    void Start()
    {
        // If the CentralMoneyManager is not set in the Inspector, try to find it in the scene
        if (centralMoneyManager == null)
        {
            centralMoneyManager = FindObjectOfType<CentralMoneyManager>();
            if (centralMoneyManager == null)
            {
                Debug.LogError("CentralMoneyManager not found in the scene.");
            }
        }
    }

    // Method to be called when the button is pressed
    public void AddMoney()
    {
        if (centralMoneyManager != null)
        {
            // Increase the money counter by amountPerClick
            centralMoneyManager.AddMoney(amountPerClick); // Call AddMoney method in CentralMoneyManager
        }
        else
        {
            Debug.LogError("CentralMoneyManager reference is missing.");
        }
    }
}

