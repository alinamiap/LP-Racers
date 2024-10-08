using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the character
    private Vector3 moveDirection; // Direction of movement
    public Transform cameraTransform; // Reference to the camera's transform

    void Update()
    {
        // Get input from arrow keys or WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Get the camera's forward and right vectors
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Project forward and right vectors onto the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calculate the movement direction based on the camera's orientation
        moveDirection = forward * moveZ + right * moveX;

        // Move the character
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        // Optional: Draw a line in the editor to show movement direction
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + moveDirection);
    }
}
