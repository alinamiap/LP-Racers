using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target; // The target (character) the camera will follow
    public Vector3 offset; // Offset position from the target
    public float smoothSpeed = 0.125f; // Smoothing speed for camera movement
    public float mouseSensitivity = 100f; // Sensitivity of the mouse movement
    private float pitch = 0f; // Rotation around the X axis
    private float yaw = 0f; // Rotation around the Y axis

    void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust the yaw and pitch based on mouse input
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // Clamp the pitch to avoid flipping

        // Calculate the rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        // Desired position is the target's position with the offset, rotated by the current rotation
        Vector3 desiredPosition = target.position + rotation * offset;

        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;

        // Rotate the camera to look at the target
        transform.LookAt(target);
    }
}
