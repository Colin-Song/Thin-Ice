using UnityEngine;

public class IDMovement : MonoBehaviour
{
    private Vector3 offset;
    public GameObject hand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hand = GameObject.Find("Hand");
    }

    // Update is called once per frame
    void Update()
    {
        if (!BoothGlobalObjects.IsClipboardDragging && !BoothGlobalObjects.IsClipboardOpen && !BoothGlobalObjects.IsFlashlightHolding)
        {
            Collider2D handCollider = hand.GetComponent<Collider2D>();
            Collider2D idCollider = GetComponent<Collider2D>();

            if (handCollider.bounds.Intersects(idCollider.bounds))
            {
                if (!BoothGlobalObjects.IsIDOpen)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        BoothGlobalObjects.IDposx = transform.position.x;
                        BoothGlobalObjects.IDposy = transform.position.y;
                        BoothGlobalObjects.IsIDDragging = true;
                        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    }

                    if (Input.GetMouseButton(0))
                    {
                        BoothGlobalObjects.IsIDDragging = true;
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        BoothGlobalObjects.IsIDDragging = false;
                    }
                }
            }

            if (BoothGlobalObjects.IsIDDragging && !BoothGlobalObjects.IsIDOpen)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            }
        }
    }
}