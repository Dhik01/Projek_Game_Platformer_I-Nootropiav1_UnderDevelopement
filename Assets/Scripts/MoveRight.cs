using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRight : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public GameObject buttonRight;
    public GameObject player;
    public float movementSpeed = 5f;

    private bool isButtonRightPressed;
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if at least two touch inputs are detected
        if (Input.touchCount >= 2)
        {
            Touch touch1 = Input.GetTouch(0); // Get the first touch detected
            Touch touch2 = Input.GetTouch(1); // Get the second touch detected

            // Check if the touch phase is when the finger is pressed down
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                // Check if both touch positions overlap with the buttonRight GameObject
                if (IsTouchOverButton(touch1.position) && IsTouchOverButton(touch2.position))
                {
                    // Set the buttonRightPressed flag to true
                    isButtonRightPressed = true;
                    MovePlayerRight(1f);
                    // Start the rotating animation
                }
            }
            // Check if the touch phase is when the finger is lifted
            else if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended)
            {
                // Check if both touch positions were previously over the buttonRight GameObject
                if (isButtonRightPressed)
                {
                    // Reset the buttonRightPressed flag to false
                    isButtonRightPressed = false;
                    StopPlayerRight();
                }
            }
        }
    }

    bool IsTouchOverButton(Vector2 touchPosition)
    {
        // Convert the touch position to a screen point
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(touchPosition);

        // Perform a raycast to check if the touch position overlaps with the buttonLeft
        RaycastHit2D hit = Physics2D.Raycast(screenPoint, Vector2.zero);

        // Check if the raycast hits the buttonLeft GameObject
        if (hit.collider != null && hit.collider.gameObject == buttonRight)
        {
            return true;
        }

        return false;
    }

    void MovePlayerRight(float direction)
    {
        rb.velocity = new Vector2(movementSpeed * direction, rb.velocity.y);
    }

    void StopPlayerRight()
    {
        rb.velocity = Vector2.zero;
    }
}
