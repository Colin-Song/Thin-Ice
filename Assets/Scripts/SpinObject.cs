using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SpinObject : MonoBehaviour
{
    [Tooltip("Reference to the child object to rotate.")]
    public Transform child1; // Assign via Inspector
    public Transform child2; // Assign via Inspector
    public Transform child3; // Assign via Inspector
    public Transform child4; // Assign via Inspector
    public Transform child5; // Assign via Inspector

    [Tooltip("Rotation speed in degrees per second.")]
    public float rotationSpeed = 90f; // Degrees per second

    void Update()
    {
        child1.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        child2.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        child3.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        child4.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        child5.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
