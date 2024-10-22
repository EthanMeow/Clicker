using UnityEngine;
using UnityEngine.UI;

public class ResetMoneyButton : MonoBehaviour
{
    public CentralMoneyManager centralMoneyManager; // Reference to the CentralMoneyManager script
    public ClickAmountModifier clickAmountModifier; // Reference to ClickAmountModifier script
    public AutoMoneyManager autoMoneyManager; // Reference to AutoMoneyManager script
    public AutoMoneyManager2 autoMoneyManager2; // Reference to AutoMoneyManager2 script
    public MoneyAdder moneyAdder; // Reference to the MoneyAdder script

    void Start()
    {
        // Get the Button component and add a listener to call ResetData when clicked
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ResetData);
        }
        else
        {
            Debug.LogWarning("No Button component found on this GameObject.");
        }

        // Ensure that all references are assigned
        if (centralMoneyManager == null)
        {
            Debug.LogError("CentralMoneyManager reference is missing!");
        }
        if (clickAmountModifier == null)
        {
            Debug.LogError("ClickAmountModifier reference is missing!");
        }
        if (autoMoneyManager == null)
        {
            Debug.LogError("AutoMoneyManager reference is missing!");
        }
        if (autoMoneyManager2 == null)
        {
            Debug.LogError("AutoMoneyManager2 reference is missing!");
        }
        if (moneyAdder == null)
        {
            Debug.LogError("MoneyAdder reference is missing!");
        }
    }

    void ResetData()
    {
        // Reset money to 0
        if (centralMoneyManager != null)
        {
            centralMoneyManager.money = 0;
            centralMoneyManager.SaveMoney(); // Save the new money value
            centralMoneyManager.UpdateMoneyText(); // Update the UI text
            Debug.Log("Money has been reset to 0.");
        }

        // Reset purchaseCount and increaseAmount for ClickAmountModifier
        if (clickAmountModifier != null)
        {
            clickAmountModifier.purchaseCount = 0;
            clickAmountModifier.increaseAmount = 1; // Reset increaseAmount to its default value
            clickAmountModifier.SaveUpgradeData(); // Save the reset purchase count and amount
            Debug.Log("ClickAmountModifier purchase count and increase amount have been reset.");
        }

        // Reset amountPerClick for MoneyAdder
        if (moneyAdder != null)
        {
            moneyAdder.amountPerClick = 1; // Reset amountPerClick to 1
            Debug.Log("MoneyAdder amountPerClick has been reset to 1.");
        }

        // Reset purchaseCount and autoIncreaseAmount for AutoMoneyManager
        if (autoMoneyManager != null)
        {
            autoMoneyManager.purchaseCount = 0;
            autoMoneyManager.autoIncreaseAmount = 0; // Reset autoIncreaseAmount
            autoMoneyManager.SaveAutoIncreaseData(); // Save the reset purchase count
            Debug.Log("AutoMoneyManager purchase count and autoIncreaseAmount have been reset.");
        }

        // Reset purchaseCount and autoIncreaseAmount for AutoMoneyManager2
        if (autoMoneyManager2 != null)
        {
            autoMoneyManager2.purchaseCount2 = 0;
            autoMoneyManager2.autoIncreaseAmount2 = 0; // Reset autoIncreaseAmount2
            PlayerPrefs.SetInt("AutoIncreasePurchaseCount2", 0); // Directly reset PlayerPrefs value
            PlayerPrefs.SetInt("AutoIncreaseAmount2", 0); // Reset autoIncreaseAmount2 in PlayerPrefs
            PlayerPrefs.Save(); // Save the PlayerPrefs changes
            Debug.Log("AutoMoneyManager2 purchase count and autoIncreaseAmount have been reset.");
        }
    }
}
