using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ShopItemSO shopItem;    // Reference to the ScriptableObject
    public RectTransform displayParent; // Parent for the hover display image
    public Vector2 offset;         // Offset position for the hover display
    public Button purchaseButton;  // Button to purchase the item

    private GameObject displayObject;
    private Image displayImage;
    private bool isPurchased = false; // Flag to track if the item has been purchased

    private void Start()
    {
        Debug.Log("HoverHandler Start() called.");

        if (shopItem == null)
        {
            Debug.LogError("ShopItemSO reference is null!");
            return;
        }

        if (shopItem.itemImage == null)
        {
            Debug.LogError($"ShopItemSO {shopItem.name} does not have an itemImage assigned!");
            return;
        }

        Debug.Log($"ShopItemSO {shopItem.name} has an itemImage assigned.");

        // Create a display object for the hover image
        displayObject = new GameObject("HoverDisplay", typeof(RectTransform));
        displayObject.transform.SetParent(displayParent, false);

        Debug.Log("HoverDisplay GameObject created and parented.");

        // Add Image component and assign the item's image
        displayImage = displayObject.AddComponent<Image>();
        displayImage.sprite = shopItem.itemImage;

        Debug.Log($"HoverDisplay Image component assigned with {shopItem.itemImage.name}.");

        // Set initial position and hide the display object
        RectTransform rt = displayObject.GetComponent<RectTransform>();
        rt.anchoredPosition = offset;

        Debug.Log($"HoverDisplay anchored position set to {offset}.");

        displayObject.SetActive(false); // Start hidden
        Debug.Log("HoverDisplay initially set to inactive.");

        // Assign the button callback for purchasing the item
        if (purchaseButton != null)
        {
            purchaseButton.onClick.AddListener(PurchaseItem);
            Debug.Log("PurchaseButton callback assigned.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isPurchased)
        {
            Debug.Log("Pointer enter ignored because the item is already purchased.");
            return; // Ignore hover if the item is purchased
        }

        Debug.Log("Pointer entered UI element.");
        if (displayObject != null)
        {
            displayObject.SetActive(true); // Show the image
            Debug.Log("HoverDisplay GameObject set to active.");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isPurchased)
        {
            Debug.Log("Pointer exit ignored because the item is already purchased.");
            return; // Ignore hover if the item is purchased
        }

        Debug.Log("Pointer exited UI element.");
        if (displayObject != null)
        {
            displayObject.SetActive(false); // Hide the image
            Debug.Log("HoverDisplay GameObject set to inactive.");
        }
    }

    private void PurchaseItem()
    {
        if (isPurchased)
        {
            Debug.LogWarning("PurchaseItem called but the item is already purchased.");
            return; // Prevent multiple purchases
        }

        isPurchased = true; // Mark the item as purchased
        Debug.Log($"Item '{shopItem.title}' purchased!");

        if (displayObject != null)
        {
            displayObject.SetActive(true); // Ensure the image is visible after purchase
            Debug.Log("HoverDisplay GameObject set to active permanently.");
        }

        if (purchaseButton != null)
        {
            purchaseButton.interactable = false; // Disable the button
            Debug.Log("PurchaseButton disabled to prevent repurchase.");
        }
    }
}
