using UnityEngine;

public class HandMovement : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = transform.position.z;
        mousePosition.y -= 5.7f;
        mousePosition.x -= 0.6f;

        transform.position = mousePosition;
    }
}
