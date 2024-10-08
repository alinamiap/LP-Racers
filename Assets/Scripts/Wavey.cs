using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavey : MonoBehaviour
{
private Vector3 startAngle; // Reference to the object's original angle values
[SerializeField] private float rotationSpeed = 1f; // Speed variable used to control the animation
[SerializeField] private float rotationOffset = 50f; // Rotate by 50 units
private float finalAngle; // Keeping track of the final angle to keep code cleaner

void Start()
{
startAngle = transform.eulerAngles; // Get the start position
}

void Update()
{
finalAngle = startAngle.y + Mathf.Sin(Time.time * rotationSpeed) * rotationOffset; // Calculate animation angle
transform.eulerAngles = new Vector3(startAngle.x, finalAngle, startAngle.z); // Apply the new angle to the object
}
}
