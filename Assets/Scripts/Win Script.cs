using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionButton : MonoBehaviour
{
    public CentralMoneyManager centralMoneyManager; // Reference to the CentralMoneyManager script
    public int requiredMoneyAmount = 10; // Amount of money required to transition to the new scene
    public string sceneToLoad; // Name of the scene to load

    void Start()
    {
        // Get the Button component and add a listener to call OnButtonClick when clicked
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogWarning("No Button component found on this GameObject.");
        }
    }

    void OnButtonClick()
    {
        // Check if the player has enough money
        if (centralMoneyManager.money >= requiredMoneyAmount)
        {
            // Subtract the required money
            centralMoneyManager.SubtractMoney(requiredMoneyAmount);
            // Load the new scene
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.Log("Not enough money to transition to the new scene!");
        }
    }
}
