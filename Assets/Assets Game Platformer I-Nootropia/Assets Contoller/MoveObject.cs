using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    public GameObject objectToMove;
    public float moveSpeed = 5f;

    private bool isMovingRight = false;
    private bool isMovingLeft = false;

    private void Update()
    {
        if (isMovingRight)
        {
            objectToMove.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if (isMovingLeft)
        {
            objectToMove.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    public void OnMoveRightButtonPressed()
    {
        isMovingRight = true;
        isMovingLeft = false;
    }

    public void OnMoveRightButtonReleased()
    {
        isMovingRight = false;
    }

    public void OnMoveLeftButtonPressed()
    {
        isMovingLeft = true;
        isMovingRight = false;
    }

    public void OnMoveLeftButtonReleased()
    {
        isMovingLeft = false;
    }
}
