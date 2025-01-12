using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// HoverHandler that can switch between two different parent RectTransforms 
/// (front vs. bird’s-eye), so the hover display appears in different places.
/// Also switches sprite if you have frontSprite and birdsEyeSprite.
/// </summary>
public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Sprites for Each View")]
    public Sprite frontSprite;      // For Canvas A (front view)
    public Sprite birdsEyeSprite;   // For Canvas B (bird’s-eye view)

    [Header("Two Parents (One for Each View)")]
    public RectTransform frontDisplayParent;     // Under Canvas A
    public RectTransform birdsEyeDisplayParent;  // Under Canvas B

    [Header("Offsets and References")]
    public Vector2 offset;          
    public Button purchaseButton;    // (Optional) If you still allow manual purchase
    public ShopItemSO shopItem;      // (Optional) If referencing item data

    // Runtime objects
    private GameObject displayObject;  
    private Image displayImage;

    // Internal state
    private bool isPurchased = false; 
    private RectTransform currentParent; // Which parent are we currently using?

    private void Start()
    {
        // Default to front display parent if you start in front view
        currentParent = frontDisplayParent;

        // Create the hover display object
        displayObject = new GameObject("HoverDisplay", typeof(RectTransform));
        displayObject.transform.SetParent(currentParent, false);

        // Add Image component
        displayImage = displayObject.AddComponent<Image>();

        // Position & hide initially
        RectTransform rt = displayObject.GetComponent<RectTransform>();
        rt.anchoredPosition = offset;
        displayObject.SetActive(false);

        // If there's a purchase button
        if (purchaseButton != null)
        {
            purchaseButton.onClick.AddListener(PurchaseItem);
        }
    }

    // ======================================================
    //              HOVER LOGIC (Unpurchased Items)
    // ======================================================
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Show the display only if not purchased
        if (!isPurchased)
        {
            Debug.Log("Show");
            displayObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide again if not purchased
        if (!isPurchased)
        {
            Debug.Log("Hide");
            displayObject.SetActive(false);
        }
    }

    // ======================================================
    //           PURCHASE OR GACHA "WIN" LOGIC
    // ======================================================
    private void PurchaseItem()
    {
        if (isPurchased) return;
        isPurchased = true;

        // Permanently show once purchased
        displayObject.SetActive(true);
        if (purchaseButton != null)
        {
            purchaseButton.interactable = false;
        }
    }

    public void GrantItemFromGacha()
    {
        if (isPurchased) return;
        isPurchased = true;

        // Permanently show once won
        displayObject.SetActive(true);
        if (purchaseButton != null)
        {
            purchaseButton.interactable = false;
        }
    }

    // ======================================================
    //    SWITCH VIEWS (AND RE-PARENT + SWAP SPRITES)
    // ======================================================
    public void SwitchToFrontView()
    {
        Debug.Log("In front view");
        // If a front sprite is assigned, use it
        if (displayImage != null && frontSprite != null)
        {
            displayImage.sprite = frontSprite;
        }

        // Move the display object to the front parent
        SetDisplayParent(frontDisplayParent);

        // If item purchased, stay visible
        if (isPurchased)
        {
            displayObject.SetActive(true);
        }
    }

    public void SwitchToBirdsEyeView()
    { 
        Debug.Log("In birds eye");
        
        // If a bird’s-eye sprite is assigned, use it
        if (displayImage != null && birdsEyeSprite != null)
        {
            displayImage.sprite = birdsEyeSprite;
        }

        // Move the display object to the bird's-eye parent
        SetDisplayParent(birdsEyeDisplayParent);

        // If item purchased, stay visible
        if (isPurchased)
        {
            displayObject.SetActive(true);
        }
    }

    // ======================================================
    //          HELPER: SET A NEW PARENT & OFFSET
    // ======================================================
    private void SetDisplayParent(RectTransform newParent)
    {
        if (newParent == null) return;
        if (newParent == currentParent) return;

        currentParent = newParent;
        displayObject.transform.SetParent(currentParent, false);

        // Reapply offset so it has the same local anchored position
        RectTransform rt = displayObject.GetComponent<RectTransform>();
        rt.anchoredPosition = offset;
    }
}
