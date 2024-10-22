using UnityEngine;
using TMPro;

public class CentralMoneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // Reference to the UI Text component
    public int money = 0; // Initial money value

    void Start()
    {
        LoadMoney(); // Load the money value when the game starts
        UpdateMoneyText(); // Initialize the text with loaded money
    }

    // Method to update the money text
    public void UpdateMoneyText()
    {
        moneyText.text = "Money: $" + money; // Update the money display
        Debug.Log("Money updated: " + money); // Debug line
    }

    // Method to add money (can be called by other scripts)
    public void AddMoney(int amount)
    {
        money += amount;
        SaveMoney(); // Save the new money value
        UpdateMoneyText(); // Update the UI text
    }

    // Method to subtract money (can be called by other scripts)
    public void SubtractMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            SaveMoney(); // Save the new money value
            UpdateMoneyText(); // Update the UI text
        }
        else
        {
            Debug.LogWarning("Not enough money to subtract");
        }
    }

    // Save the money value using PlayerPrefs
    public void SaveMoney()
    {
        PlayerPrefs.SetInt("PlayerMoney", money);
        PlayerPrefs.Save(); // Ensure the value is written to storage
        Debug.Log("Money saved: " + money);
    }

    // Load the money value from PlayerPrefs
    public void LoadMoney()
    {
        if (PlayerPrefs.HasKey("PlayerMoney"))
        {
            money = PlayerPrefs.GetInt("PlayerMoney");
            Debug.Log("Money loaded: " + money);
        }
        else
        {
            money = 0; // Default value if no saved money is found
            Debug.Log("No saved money found. Defaulting to 0.");
        }
    }
}