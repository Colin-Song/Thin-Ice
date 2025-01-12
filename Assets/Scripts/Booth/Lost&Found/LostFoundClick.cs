using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class LostFoundClick : MonoBehaviour
{
    private float posx, posy, posz;
    public static int item_count = BoothGlobalObjects.lfobjects;
    public  GameObject POPUP;
    public GameObject SHOE, SHIRT, PANTS, PHONE, WALLET;
    public static GameObject hand, popup;
    public static string[] items = { "SHOE", "SHIRT", "PANTS", "PHONE", "WALLET" };
    private GameObject prop;
    public static bool popupdestroy;
    public static bool[] placed = { false, false, false, false, false };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hand = GameObject.Find("Hand");
        BoothGlobalObjects.PopUp = false;
        popupdestroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
        }
    }

    void Popup()
    {
        posx = 0f;
        posy = 0f;
        posz = 0f;

        Vector3 PopupPosition = new Vector3(posx, posy, posz);
        Quaternion spawnRotation = Quaternion.identity;
        popup = Instantiate(POPUP, PopupPosition, spawnRotation);
        popup.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("OpenObject");

        Vector3 position1 = new Vector3(LostFoundObjects.pos1x, LostFoundObjects.pos1y, 0f);
        Vector3 position2 = new Vector3(LostFoundObjects.pos2x, LostFoundObjects.pos2y, 0f);
        Vector3 position3 = new Vector3(LostFoundObjects.pos3x, LostFoundObjects.pos3y, 0f);
        Vector3 position4 = new Vector3(LostFoundObjects.pos4x, LostFoundObjects.pos4y, 0f);
        Vector3 position5 = new Vector3(LostFoundObjects.pos5x, LostFoundObjects.pos5y, 0f);

        Vector3[] positions = {position1, position2, position3, position4, position5};

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
    }
    void PopupDestroy()
    {
        Destroy(popup);
        Destroy(prop);
        */
    }

}
