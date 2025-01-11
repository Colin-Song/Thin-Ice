using UnityEngine;

public class ClipboardPosition : MonoBehaviour
{
    public GameObject hand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!BoothGlobalObjects.IsClipboardOpen && !BoothGlobalObjects.IsClipboardDragging)
        {
            if (BoothGlobalObjects.IsClipboardWall)
            {
                transform.position = new Vector3(BoothGlobalObjects.Clipboardposx, BoothGlobalObjects.Clipboardposy, transform.position.z);
            }
            else if (BoothGlobalObjects.IsClipboardAbove)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.17f, transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Right Wall")
        {
            BoothGlobalObjects.IsClipboardWall = true;
        }
        else if (other.gameObject.name == "Left Wall")
        {
            BoothGlobalObjects.IsClipboardWall = true;
        }
        else if (other.gameObject.name == "Above Desk")
        {
            BoothGlobalObjects.IsClipboardAbove = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Right Wall")
        {
            BoothGlobalObjects.IsClipboardWall = true;
        }
        else if (other.gameObject.name == "Left Wall")
        {
            BoothGlobalObjects.IsClipboardWall = true;
        }
        else if (other.gameObject.name == "Above Desk")
        {
            BoothGlobalObjects.IsClipboardAbove = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Right Wall")
        {
            BoothGlobalObjects.IsClipboardWall = false;
        }
        else if (other.gameObject.name == "Left Wall")
        {
            BoothGlobalObjects.IsClipboardWall = false;
        }
        else if (other.gameObject.name == "Above Desk")
        {
            BoothGlobalObjects.IsClipboardAbove = false;
        }
    }
}
