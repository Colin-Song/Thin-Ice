using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class ClipboardClick : MonoBehaviour
{
    // clipboard sizes
    private Vector3 bigScale, smallScale;
    public GameObject hand;
    public Sprite newSprite1, newSprite2;
    private SpriteRenderer spriteRenderer;
    Collider2D clipboardCollider;
    BoxCollider2D b_Collider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hand = GameObject.Find("Hand");
        bigScale = new Vector3(0.52f, 0.52f, 1f);
        smallScale = new Vector3(0.34f, 0.4348247f, 1f);    }

    private void Update()
    {
        if (BoothGlobalObjects.AorR == 'n')
        {
            if (!BoothGlobalObjects.IsIDDragging && !BoothGlobalObjects.IsIDOpen && !BoothGlobalObjects.IsFlashlightHolding)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Collider2D handCollider = hand.GetComponent<Collider2D>();
                    clipboardCollider = GetComponent<Collider2D>();
                    if (handCollider.bounds.Intersects(clipboardCollider.bounds))
                    {
                        BoothGlobalObjects.IsClipboardOpen = !BoothGlobalObjects.IsClipboardOpen;

                        if (BoothGlobalObjects.IsClipboardOpen)
                        {
                            spriteRenderer.sprite = newSprite2;
                            BoothGlobalObjects.Clipboardposx = transform.position.x;
                            BoothGlobalObjects.Clipboardposy = transform.position.y;
                            transform.localScale = bigScale;
                            transform.position = new Vector3(0, 0, 0);
                            clipboardCollider.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("OpenObject");
                            b_Collider = clipboardCollider.GetComponent<BoxCollider2D>();
                            b_Collider.size = new Vector2(15.53f, 15.53f);
                        }
                        else
                        {
                            spriteRenderer.sprite = newSprite1;
                            transform.localScale = smallScale;
                            transform.position = new Vector3(BoothGlobalObjects.Clipboardposx, BoothGlobalObjects.Clipboardposy, 0);
                            clipboardCollider.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Clipboard");
                            b_Collider = clipboardCollider.GetComponent<BoxCollider2D>();
                            b_Collider.size = new Vector2(4.01f, 4.01f);
                        }
                    }
                }
            }
        }
    }
}
