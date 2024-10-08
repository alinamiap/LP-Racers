using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteSwitch : MonoBehaviour
{
    public Sprite facingCameraSprite; // Sprite for facing the camera
    public Sprite walkingAwaySprite; // Sprite for walking away from the camera
    public Sprite facingRightSprite; // Sprite for facing right
    public Sprite facingLeftSprite; // Sprite for facing left (same as right but flipped)
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    private Vector3 previousPosition; // Store the previous position of the character

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        previousPosition = transform.position; // Initialize the previous position
    }

    void Update()
    {
        // Calculate the movement direction
        Vector3 movementDirection = transform.position - previousPosition;

        // Check if the character is moving towards or away from the camera
        if (movementDirection.z > 0)
        {
            spriteRenderer.sprite = walkingAwaySprite; // Walking away from the camera
        }
        else if (movementDirection.z < 0)
        {
            spriteRenderer.sprite = facingCameraSprite; // Facing the camera
        }
        else if (movementDirection.x > 0)
        {
            spriteRenderer.sprite = facingRightSprite; // Facing right
            spriteRenderer.flipX = false; // Ensure the sprite is not flipped
        }
        else if (movementDirection.x < 0)
        {
            spriteRenderer.sprite = facingRightSprite; // Facing right sprite
            spriteRenderer.flipX = true; // Flip the sprite to face left
        }

        // Update the previous position
        previousPosition = transform.position;
    }
}
