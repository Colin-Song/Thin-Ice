using UnityEngine;

public class RandomLeftRightMovement : MonoBehaviour
{
    public Transform leftEnd; // Transform for the left boundary of the rink
    public Transform rightEnd; // Transform for the right boundary of the rink
    public float glideSpeed = 2f; // Speed of gliding
    private bool movingRight = true; // Direction flag

    void Update()
    {
        Glide();
    }

    void Glide()
    {
        // Determine the target position based on the direction
        Transform target = movingRight ? rightEnd : leftEnd;

        // Move the player toward the target position
        transform.position = Vector3.MoveTowards(transform.position, target.position, glideSpeed * Time.deltaTime);

        // Check if the player has reached the target
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            transform.position = target.position; // Snap to the target to avoid overshooting
            movingRight = !movingRight; // Switch direction
            FlipSprite(); // Flip the sprite visually
        }
    }

    void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x = movingRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x); // Explicitly set scale based on direction
        transform.localScale = scale;
    }
}