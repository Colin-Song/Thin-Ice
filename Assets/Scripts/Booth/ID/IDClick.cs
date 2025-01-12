using UnityEngine;

public class IDClick : MonoBehaviour
{
    private Vector3 bigScale, smallScale;
    public GameObject hand;
    public Sprite newSprite1, newSprite2;
    private SpriteRenderer spriteRenderer;
    Collider2D idCollider;
    BoxCollider2D b_Collider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hand = GameObject.Find("Hand");
        bigScale = new Vector3(0.7f, 0.7f, 1f);
        smallScale = new Vector3(0.64f, 0.3135402f, 1f);
    }

    private void Update()
    {
        if (!BoothGlobalObjects.IsClipboardDragging && !BoothGlobalObjects.IsClipboardOpen && !BoothGlobalObjects.IsFlashlightHolding)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Collider2D handCollider = hand.GetComponent<Collider2D>();
                idCollider = GetComponent<Collider2D>();
                if (handCollider.bounds.Intersects(idCollider.bounds))
                {
                    BoothGlobalObjects.IsIDOpen = !BoothGlobalObjects.IsIDOpen;

                    if (BoothGlobalObjects.IsIDOpen)
                    {
                        spriteRenderer.sprite = newSprite2;
                        BoothGlobalObjects.IDposx = transform.position.x;
                        BoothGlobalObjects.IDposy = transform.position.y;
                        transform.localScale = bigScale;
                        transform.position = new Vector3(0, 0, 0);
                        idCollider.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("OpenObject");
                        b_Collider = idCollider.GetComponent<BoxCollider2D>();
                        b_Collider.size = new Vector2(15.92f, 9.15f);
                    }
                    else
                    {
                        spriteRenderer.sprite = newSprite1;
                        transform.localScale = smallScale;
                        transform.position = new Vector3(BoothGlobalObjects.IDposx, BoothGlobalObjects.IDposy, 0);
                        idCollider.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("ID");
                        b_Collider = idCollider.GetComponent<BoxCollider2D>();
                        b_Collider.size = new Vector2(2.36f, 1.36f);
                    }
                }
            }
        }
    }
}
