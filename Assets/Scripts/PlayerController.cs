using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float desiredDuration = 1f;
    private float elapsedTime;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 currentPosition;
    private bool isMoving = false;
    void Update()
    {
        // Key controls.
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isMoving != true) // You can use WASD or arrow keys!
        {
            isMoving = true; // To prevent player from pressing keys before the movement is complete.
            startPosition = transform.position; // Set current position as start.
            endPosition = transform.position + Vector3.forward; // Set target position 1 meter in the desired direction.
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && isMoving != true)
        {
            isMoving = true;
            startPosition = transform.position;
            endPosition = transform.position + Vector3.back;
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && isMoving != true)
        {
            isMoving = true;
            startPosition = transform.position;
            endPosition = transform.position + Vector3.left;
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isMoving != true)
        {
            isMoving = true;
            startPosition = transform.position;
            endPosition = transform.position + Vector3.right;
        }

        if (isMoving == true)
        {
            elapsedTime += Time.deltaTime; // While the character is moving, start counting how much time passed.
            float percentageComplete = elapsedTime / desiredDuration; // Dividing time passed by desired movement duration, determine where 
            transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete); // the player character should be between the two points
            if (percentageComplete >= 1)
            {
                transform.position = endPosition; // When the time is up, snap to position.
                elapsedTime = 0; // Reset the time counter.
                isMoving = false; // And switch isMoving to false, so that player may move again.
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "WallTile")  // If the player character bumps into a wall . . .
        {
            isMoving = false; // Cancel movement.
            endPosition = startPosition; // Set our original starting position as a destination to return to.
            elapsedTime = 0; // Refresh the time counter.
            startPosition = transform.position; // Set the current position as the starting point.
            isMoving = true; // Restart movement to come back.
        }
    }
}
