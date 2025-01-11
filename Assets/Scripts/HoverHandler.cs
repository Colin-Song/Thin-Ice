using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Sprites for Each View")]
    public Sprite frontSprite;    // For Canvas A
    public Sprite birdsEyeSprite; // For Canvas B

    [Header("Display Setup")]
    public RectTransform displayParent; 
    public Vector2 offset;
    public Button purchaseButton;  // If you still allow manual purchase
    public ShopItemSO shopItem;    // If you need references to the item data

    private GameObject displayObject;
    private Image displayImage;
    private bool isPurchased = false; 

    private void Start()
    {
        // Create a UI object for displaying the sprite
        displayObject = new GameObject("HoverDisplay", typeof(RectTransform));
        displayObject.transform.SetParent(displayParent, false);
        displayImage = displayObject.AddComponent<Image>();

        // Position & hide at first
        RectTransform rt = displayObject.GetComponent<RectTransform>();
        rt.anchoredPosition = offset;
        displayObject.SetActive(false);

        // If you have a button for manual purchase
        if (purchaseButton != null)
        {
            purchaseButton.onClick.AddListener(PurchaseItem);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // If not purchased, show the image on hover
        if (!isPurchased)
        {
            displayObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide again if not purchased
        if (!isPurchased)
        {
            displayObject.SetActive(false);
        }
    }

    // If you allow manual purchases
    private void PurchaseItem()
    {
        if (isPurchased) return;
        isPurchased = true;

        // Show permanently
        displayObject.SetActive(true);
        if (purchaseButton != null)
        {
            purchaseButton.interactable = false;
        }
    }

    // Called by Gacha to "win" this item
    public void GrantItemFromGacha()
    {
        if (isPurchased) return;
        isPurchased = true;

        displayObject.SetActive(true);
        if (purchaseButton != null)
        {
            purchaseButton.interactable = false;
        }
    }

    // ===========================
    //  NEW: Methods to switch
    // ===========================
  public void SwitchToFrontView()
{
    if (displayImage != null && frontSprite != null)
    {
        displayImage.sprite = frontSprite;
    }

    if (isPurchased)
    {
        displayObject.SetActive(true);
    }
    else
    {
        // DO NOT force displayObject.SetActive(false)
        // Let OnPointerEnter/OnPointerExit handle it
    }
}


   public void SwitchToBirdsEyeView()
{
    if (displayImage != null && birdsEyeSprite != null)
    {
        displayImage.sprite = birdsEyeSprite;
    }

    // If purchased, keep it visible. Otherwise, keep it hidden until hovered.
    if (isPurchased)
    {
        displayObject.SetActive(true);
    }
    else
    {
        // DO NOT forcibly hide. Leave it to OnPointerEnter/Exit.
        // displayObject.SetActive(false); // Remove this line
    }
}

}
