using UnityEngine;
using TMPro;

public class CentralMoneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // Reference to the UI Text component
    public int money = 0; // Initial money value

    void Start()
    {
        UpdateMoneyText(); // Initialize the text at start
    }

    public void UpdateMoneyText()
    {
        moneyText.text = "Money: $" + money; // Update the money display
        Debug.Log("Money updated: " + money); // Debug line
    }
}
