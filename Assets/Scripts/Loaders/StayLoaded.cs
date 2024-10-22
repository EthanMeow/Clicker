using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // For handling UI components like buttons

public class SceneLoader : MonoBehaviour
{
    public Button loadMinesweeperButton; // Reference to the button in your UI

    void Start()
    {
        // Ensure the button is assigned and subscribe to its onClick event
        if (loadMinesweeperButton != null)
        {
            loadMinesweeperButton.onClick.AddListener(LoadMinesweeperScene);
        }
    }

    // Method to load the Minesweeper scene additively
    public void LoadMinesweeperScene()
    {
        SceneManager.LoadScene("Minesweeper", LoadSceneMode.Additive);
        Debug.Log("Minesweeper scene loaded while keeping the current scene active.");
    }
}
