using UnityEngine;

public class LostFoundClick : MonoBehaviour
{
    private float posx, posy, posz;
    public static int item_count = BoothGlobalObjects.lfobjects;
    public  GameObject POPUP;
    public GameObject SHOE, SHIRT, PANTS, PHONE, WALLET;
    public static GameObject hand, popup, shoe, shirt, pants, phone, wallet;
    public static bool popupdestroy;

    public static float pos1x, pos1y, pos2x, pos2y, pos3x, pos3y, pos4x, pos4y, pos5x, pos5y;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hand = GameObject.Find("Hand");
        BoothGlobalObjects.PopUp = false;
        popupdestroy = false;

        pos1x = -2.85f;
        pos1y = 1.93f;

        pos2x = -2.85f;
        pos2y = 0.04f;

        pos3x = -2.85f;
        pos3y = -1.91f;

        pos4x = 0.91f;
        pos4y = -1.13f;

        pos5x = 0.91f;
        pos5y = 1.08f;

        posx = 0f;
        posy = 0f;
        posz = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!BoothGlobalObjects.IsClipboardDragging && !BoothGlobalObjects.IsClipboardOpen && !BoothGlobalObjects.IsIDDragging && !BoothGlobalObjects.IsIDOpen && !BoothGlobalObjects.IsFlashlightHolding)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D handCollider = hand.GetComponent<Collider2D>();
                Collider2D lfCollider = GetComponent<Collider2D>();
                if (handCollider.bounds.Intersects(lfCollider.bounds) && !BoothGlobalObjects.PopUp)
                {
                    BoothGlobalObjects.PopUp = true;
                    Popup();
                }
            }
        }

        if (popupdestroy)
        {
            PopupDestroy();
            LostFoundClick.popupdestroy = false;
            BoothGlobalObjects.PopUp = false;
        }
    }

    void Popup()
    {
        Vector3 PopupPosition = new Vector3(posx, posy, posz);
        Quaternion spawnRotation = Quaternion.identity;
        popup = Instantiate(POPUP, PopupPosition, spawnRotation);
        popup.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("OpenObject");

        Vector3 position1 = new Vector3(pos1x, pos1y, 0f);
        Vector3 position2 = new Vector3(pos2x, pos2y, 0f);
        Vector3 position3 = new Vector3(pos3x, pos3y, 0f);
        Vector3 position4 = new Vector3(pos4x, pos4y, 0f);
        Vector3 position5 = new Vector3(pos5x, pos5y, 0f);

        shoe = Instantiate(SHOE, position1, spawnRotation);
        shoe.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Prop");

        shirt = Instantiate(SHIRT, position2, spawnRotation);
        shirt.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Prop");

        phone = Instantiate(PHONE, position3, spawnRotation);
        phone.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Prop");

        wallet = Instantiate(WALLET, position4, spawnRotation);
        wallet.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Prop");

        pants = Instantiate(PANTS, position5, spawnRotation);
        pants.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Prop");

        //Vector3[] positions = {position1, position2, position3, position4, position5};
        /*
        for (int i = 0; i < items.Length; i++)
        {
            placed[i] = true;
        }

        int j = 0, k = 0;
        int[] numbers_drawn = new int[5];
        for (int i = 0; i <= 4; i++)
        {
            if (placed[i])
            {
                j = Random.Range(0, 4);
                while (numbers_drawn.Contains(j))
                {
                    j = Random.Range(0, 4);
                }
                numbers_drawn[k] = j;
                k++;

                if (j == 0)
                {
                    prop = Instantiate(SHOE, positions[j], spawnRotation);
                    prop.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Prop");
                }
                else if (j == 1)
                {
                    prop = Instantiate(SHIRT, positions[j], spawnRotation);
                    prop.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Prop");
                }
                else if (j == 2)
                {
                    prop = Instantiate(PANTS, positions[j], spawnRotation);
                    prop.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Prop");
                }
                else if (j == 3)
                {
                    prop = Instantiate(PHONE, positions[j], spawnRotation);
                    prop.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Prop");
                }
                else if (j == 4)
                {
                    prop = Instantiate(WALLET, positions[j], spawnRotation);
                    prop.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Prop");
                }
            }
        }
        */


    }
    void PopupDestroy()
    {
        Destroy(popup);
        Destroy(shoe);
        Destroy(shirt);
        Destroy(pants);
        Destroy(phone);
        Destroy(wallet);
    }
}
