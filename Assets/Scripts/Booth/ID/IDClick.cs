using UnityEngine;

public class IDClick : MonoBehaviour
{
    private Vector3 bigScale, smallScale;
    public GameObject hand;

    void Start()
    {
        hand = GameObject.Find("Hand");
        bigScale = new Vector3(7.936f, 3.8879f, 1f);
        smallScale = new Vector3(1.441091f, 0.706f, 1f);
    }

    private void Update()
    {
        if (!BoothGlobalObjects.IsClipboardDragging && !BoothGlobalObjects.IsClipboardOpen && !BoothGlobalObjects.IsFlashlightHolding)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Collider2D handCollider = hand.GetComponent<Collider2D>();
                Collider2D idCollider = GetComponent<Collider2D>();
                if (handCollider.bounds.Intersects(idCollider.bounds))
                {
                    BoothGlobalObjects.IsIDOpen = !BoothGlobalObjects.IsIDOpen;

                    if (BoothGlobalObjects.IsIDOpen)
                    {
                        BoothGlobalObjects.IDposx = transform.position.x;
                        BoothGlobalObjects.IDposy = transform.position.y;
                        transform.localScale = bigScale;
                        transform.position = new Vector3(0, 0, 0);
                        idCollider.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("OpenObject");
                    }
                    else
                    {
                        transform.localScale = smallScale;
                        transform.position = new Vector3(BoothGlobalObjects.IDposx, BoothGlobalObjects.IDposy, 0);
                        idCollider.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("ID");
                    }
                }
            }
        }
    }
}
