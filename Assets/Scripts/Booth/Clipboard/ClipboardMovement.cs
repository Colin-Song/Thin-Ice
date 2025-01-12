using UnityEngine;

public class ClipboardMovement : MonoBehaviour
{
    // offset for object position
    private Vector3 offset;
    // dragging object checker
    public GameObject hand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hand = GameObject.Find("Hand");
    }

    // Update is called once per frame
    void Update()
    {
        if (BoothGlobalObjects.AorR == 'n')
        {
            if (!BoothGlobalObjects.IsIDDragging && !BoothGlobalObjects.IsIDOpen && !BoothGlobalObjects.IsFlashlightHolding)
            {
                Collider2D handCollider = hand.GetComponent<Collider2D>();
                Collider2D clipboardCollider = GetComponent<Collider2D>();

                if (handCollider.bounds.Intersects(clipboardCollider.bounds))
                {
                    if (!BoothGlobalObjects.IsClipboardOpen)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            BoothGlobalObjects.Clipboardposx = transform.position.x;
                            BoothGlobalObjects.Clipboardposy = transform.position.y;
                            BoothGlobalObjects.IsClipboardDragging = true;
                            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        }

                        if (Input.GetMouseButton(0))
                        {
                            BoothGlobalObjects.IsClipboardDragging = true;
                        }
                        else if (Input.GetMouseButtonUp(0))
                        {
                            // set dragging to false
                            BoothGlobalObjects.IsClipboardDragging = false;
                        }
                    }
                }

                // if dragging
                if (BoothGlobalObjects.IsClipboardDragging && !BoothGlobalObjects.IsClipboardOpen)
                {
                    // change position to where mouse is + offset
                    transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
                }
            }
        }
    }
}
