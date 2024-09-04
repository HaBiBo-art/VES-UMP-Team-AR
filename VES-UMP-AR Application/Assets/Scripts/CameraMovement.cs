using UnityEngine;

public class ARPlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        // Get input from keyboard
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow keys

        // Create a movement vector based on input
        Vector3 move = new Vector3(moveX, 0, moveZ);

        // Move the player
        transform.Translate(move * speed * Time.deltaTime);
    }
}
