using UnityEngine;
using UnityEngine.UI;

public class UIButtonManager : MonoBehaviour
{
    public Button[] buttonsToUnload; // Array to hold buttons to unload
    public Button unloadButton;       // Button that triggers the unload

    void Start()
    {
        // Ensure unloadButton has an onClick listener
        if (unloadButton != null)
        {
            unloadButton.onClick.AddListener(UnloadButtons);
        }
    }

    void UnloadButtons()
    {
        foreach (Button button in buttonsToUnload)
        {
            if (button != null)
            {
                button.gameObject.SetActive(false); // Deactivate the button
            }
        }
    }
}