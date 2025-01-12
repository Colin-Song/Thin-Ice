using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LostFoundClick : MonoBehaviour
{
    private float posx, posy, posz;
    public static int item_count;
    public static string[] items;
    public static bool open;
    public GameObject nothing, hand, popup, POPUP, shoe, shirt, pants, phone, wallet, first_item, sec_item, third_item, fourth_item, fifth_item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hand = GameObject.Find("Hand");
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!BoothGlobalObjects.IsClipboardDragging && !BoothGlobalObjects.IsClipboardOpen && !BoothGlobalObjects.IsIDDragging && !BoothGlobalObjects.IsIDOpen && !BoothGlobalObjects.IsFlashlightHolding)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!open)
                {
                    open = true;
                    Popup();
                }
                else
                {
                    open = false;
                    PopupDestroy();
                }
            }
        }
    }

    void Popup()
    {
        posx = -11.8f;
        posy = 0.69f;
        posz = 0f;

        Vector3 PopupPosition = new Vector3(posx, posy, posz);
        Quaternion spawnRotation = Quaternion.identity;
        //popup = Instantiate(POPUP, PopupPosition, spawnRotation);

        Vector3 position1 = new Vector3(LostFoundObjects.pos1x,LostFoundObjects.pos1y, 0f);
        Vector3 position2 = new Vector3(LostFoundObjects.pos2x, LostFoundObjects.pos2y, 0f);
        Vector3 position3 = new Vector3(LostFoundObjects.pos3x, LostFoundObjects.pos3y, 0f);
        Vector3 position4 = new Vector3(LostFoundObjects.pos4x, LostFoundObjects.pos4y, 0f);
        Vector3 position5 = new Vector3(LostFoundObjects.pos5x, LostFoundObjects.pos5y, 0f);

        if (LostFoundObjects.placed[0])
        {
            first_item = Instantiate(shoe, position1, spawnRotation);
        }
        else
        {
            first_item = Instantiate(nothing, position1, spawnRotation);
        }

        if (LostFoundObjects.placed[1])
        {
            sec_item = Instantiate(shirt, position2, spawnRotation);
        }
        else
        {
            sec_item = Instantiate(nothing, position2, spawnRotation);
        }

        if (LostFoundObjects.placed[2])
        {
            third_item = Instantiate(pants, position3, spawnRotation);
        }
        else
        {
            third_item = Instantiate(nothing, position3, spawnRotation);
        }

        if (LostFoundObjects.placed[3])
        {
            fourth_item = Instantiate(phone, position4, spawnRotation);
        }
        else
        {
            fourth_item = Instantiate(nothing, position4, spawnRotation);
        }

        if (LostFoundObjects.placed[4])
        {
            fifth_item = Instantiate(wallet, position5, spawnRotation);
        }
        else
        {
            fifth_item = Instantiate(nothing, position5, spawnRotation);
        }


    }
    void PopupDestroy()
    {
        Destroy(popup);
        Destroy(first_item);
        Destroy(sec_item);
        Destroy(third_item);
        Destroy(fourth_item);
        Destroy(fifth_item);
    }
}
