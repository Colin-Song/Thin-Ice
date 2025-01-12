using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class LostFoundClick : MonoBehaviour
{
    public Canvas canvas; // Reference to the Canvas in the scene
    private GameObject textBox1, textBox2, textBox3, textBox4, textBox5,;
    private float posx, posy, posz;
    public static int item_count = BoothGlobalObjects.lfobjects;
    public  GameObject POPUP;
    public GameObject SHOE, SHIRT, PANTS, PHONE, WALLET;
    public static GameObject hand, popup, shoe, shirt, pants, phone, wallet;
    private GameObject prop;
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
        posx = 0f;
        posy = 0f;
        posz = 0f;

        Vector3 PopupPosition = new Vector3(posx, posy, posz);
        Quaternion spawnRotation = Quaternion.identity;
        popup = Instantiate(POPUP, PopupPosition, spawnRotation);
        popup.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("OpenObject");

        Vector3 position1 = new Vector3(pos1x, pos1y, 0f);
        Vector3 position2 = new Vector3(pos2x, pos2y, 0f);
        Vector3 position3 = new Vector3(pos3x, pos3y, 0f);
        Vector3 position4 = new Vector3(pos4x, pos4y, 0f);
        Vector3 position5 = new Vector3(pos5x, pos5y, 0f);

        GameObject textObject1 = new GameObject("TextBox");
        TextMeshProUGUI textComponent1 = textObject1.AddComponent<TextMeshProUGUI>();
        textComponent1.text = "x1";
        textComponent1.fontSize = 12;
        textComponent1.color = Color.black;
        textObject1.transform.SetParent(canvas.transform, false);
        RectTransform rectTransform1 = textObject1.GetComponent<RectTransform>();
        rectTransform1.anchoredPosition = new Vector2(pos1x + 0.3f, pos1y);

        GameObject textObject2 = new GameObject("TextBox");
        TextMeshProUGUI textComponent2 = textObject2.AddComponent<TextMeshProUGUI>();
        textComponent2.text = "x1";
        textComponent2.fontSize = 12;
        textComponent2.color = Color.black;
        textObject2.transform.SetParent(canvas.transform, false);
        RectTransform rectTransform2 = textObject2.GetComponent<RectTransform>();
        rectTransform2.anchoredPosition = new Vector2(pos2x + 0.3f, pos2y);

        GameObject textObject3 = new GameObject("TextBox");
        TextMeshProUGUI textComponent3 = textObject3.AddComponent<TextMeshProUGUI>();
        textComponent3.text = "x1";
        textComponent3.fontSize = 12;
        textComponent3.color = Color.black;
        textObject3.transform.SetParent(canvas.transform, false);
        RectTransform rectTransform3 = textObject3.GetComponent<RectTransform>();
        rectTransform3.anchoredPosition = new Vector2(pos3x + 0.3f, pos3y);

        GameObject textObject4 = new GameObject("TextBox");
        TextMeshProUGUI textComponent4 = textObject4.AddComponent<TextMeshProUGUI>();
        textComponent4.text = "x1";
        textComponent4.fontSize = 12;
        textComponent4.color = Color.black;
        textObject4.transform.SetParent(canvas.transform, false);
        RectTransform rectTransform4 = textObject4.GetComponent<RectTransform>();
        rectTransform4.anchoredPosition = new Vector2(pos4x + 0.3f, pos4y);

        GameObject textObject5 = new GameObject("TextBox");
        TextMeshProUGUI textComponent5 = textObject3.AddComponent<TextMeshProUGUI>();
        textComponent5.text = "x1";
        textComponent5.fontSize = 12;
        textComponent5.color = Color.black;
        textObject5.transform.SetParent(canvas.transform, false);
        RectTransform rectTransform5 = textObject5.GetComponent<RectTransform>();
        rectTransform5.anchoredPosition = new Vector2(pos5x + 0.3f, pos5y);

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

        Destroy(textObject1);
        Destroy(textObject1);
        Destroy(textObject1);
        Destroy(textObject1);
        Destroy(textObject1);
    }
}
