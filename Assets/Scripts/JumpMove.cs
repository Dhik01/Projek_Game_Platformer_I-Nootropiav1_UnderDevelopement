using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buttonJump;
    Rigidbody2D rb;
    public GameObject player;
    public float jumpForce = 10f;

    bool isButtonJumpPressed;
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if any touch input is detected
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
                    // Set the buttonLeftPressed flag to true
                    isButtonJumpPressed = true;
                    JumpPlayer();
                    // Start the rotating animation
                }
            }
            // Check if the touch phase is when the finger is lifted
            else if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended)
            {
                // Check if the touch position was previously over the buttonLeft GameObject
                if (isButtonJumpPressed)
                {
                    // Reset the buttonLeftPressed flag to false
                    isButtonJumpPressed = false;
                    StopJumpPlayer();
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
        if (hit.collider != null && hit.collider.gameObject == buttonJump)
        {
            return true;
        }

        return false;
    }

    void JumpPlayer()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    void StopJumpPlayer()
    {
        rb.velocity = Vector2.zero;
    }
}
