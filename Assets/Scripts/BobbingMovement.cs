using UnityEngine;

public class BobbingMovement : MonoBehaviour
{
    // Adjustable parameters for bobbing
    public float bobbingSpeed = 2f;  // Speed of bobbing
    public float bobbingHeight = 0.5f;  // Height of bobbing

    private Vector3 startPos;

    void Start()
    {
        // Store the starting position of the GameObject
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave for smooth up-and-down motion
        float newY = startPos.y + Mathf.PingPong(Time.time * bobbingSpeed, bobbingHeight);
        // Apply the new position to the GameObject
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}