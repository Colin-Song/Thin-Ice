using UnityEngine;

public class FlashlightMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3 offset;
    public GameObject hand;
    public Sprite newSprite;
    UnityEngine.Color color;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        color.a = 1;

        spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!BoothGlobalObjects.IsClipboardDragging && !BoothGlobalObjects.IsClipboardOpen && !BoothGlobalObjects.IsIDDragging && !BoothGlobalObjects.IsIDOpen)
        {
            Collider2D handCollider = hand.GetComponent<Collider2D>();
            Collider2D flashlightCollider = GetComponent<Collider2D>();

            if (handCollider.bounds.Intersects(flashlightCollider.bounds))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    color.a = 0;
                    spriteRenderer.color = color;
                    BoothGlobalObjects.Flashlightposx = transform.position.x;
                    BoothGlobalObjects.Flashlightposy = transform.position.y;
                    BoothGlobalObjects.IsFlashlightHolding = true;
                    offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }

                if (Input.GetMouseButton(0))
                {
                    color.a = 0;
                    spriteRenderer.color = color;
                    BoothGlobalObjects.IsFlashlightHolding = true;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    color.a = 1;
                    spriteRenderer.color = color;
                    BoothGlobalObjects.IsFlashlightHolding = false;
                    BoothGlobalObjects.IsFlashlightOn = false;
                }
            }

            if (BoothGlobalObjects.IsFlashlightHolding)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            }
        }
    }
}