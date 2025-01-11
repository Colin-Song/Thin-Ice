using UnityEngine;
using static UnityEditor.Progress;

public class ClipboardClick : MonoBehaviour
{
    // clipboard sizes
    private Vector3 bigScale, smallScale;
    public GameObject hand;

    void Start()
    {
        hand = GameObject.Find("Hand");
        bigScale = new Vector3(9f, 8.8f, 1f);
        smallScale = new Vector3(1.6343f, 2.0901f, 1f);
    }

    private void Update()
    {
        if (CharacterInfo.AorR == 'n')
        {
            if (!BoothGlobalObjects.IsIDDragging && !BoothGlobalObjects.IsIDOpen && !BoothGlobalObjects.IsFlashlightHolding)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Collider2D handCollider = hand.GetComponent<Collider2D>();
                    Collider2D clipboardCollider = GetComponent<Collider2D>();
                    if (handCollider.bounds.Intersects(clipboardCollider.bounds))
                    {
                        BoothGlobalObjects.IsClipboardOpen = !BoothGlobalObjects.IsClipboardOpen;

                        if (BoothGlobalObjects.IsClipboardOpen)
                        {
                            BoothGlobalObjects.Clipboardposx = transform.position.x;
                            BoothGlobalObjects.Clipboardposy = transform.position.y;
                            transform.localScale = bigScale;
                            transform.position = new Vector3(0, 0, 0);
                            clipboardCollider.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("OpenObject");
                        }
                        else
                        {
                            transform.localScale = smallScale;
                            transform.position = new Vector3(BoothGlobalObjects.Clipboardposx, BoothGlobalObjects.Clipboardposy, 0);
                            clipboardCollider.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Clipboard");
                        }
                    }
                }
            }
        }
    }
}
