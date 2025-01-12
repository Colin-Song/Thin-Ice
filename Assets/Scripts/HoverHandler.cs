using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// HoverHandler for switching between pre-defined UI elements in a canvas for front and bird’s-eye views.
/// </summary>
public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Canvas Display Elements")]
    public Image frontViewImage;       // Predefined Image in Canvas for front view
    public Image birdsEyeViewImage;    // Predefined Image in Canvas for bird’s-eye view

    [Header("Shop Item Reference (Optional)")]
    public ShopItemSO shopItem;        // (Optional) If referencing item data

    // Internal state
    private bool isPurchased = false; 
    private bool isFrontView = true;   // Tracks which view is active

    private void Start()
    {
        // Ensure both images are initially hidden
        if (frontViewImage != null)
        {
            frontViewImage.gameObject.SetActive(false);
        }
        if (birdsEyeViewImage != null)
        {
            birdsEyeViewImage.gameObject.SetActive(false);
        }

        // Default to front view
        SwitchToFrontView();
    }

    // ======================================================
    //              HOVER LOGIC (Unpurchased Items)
    // ======================================================
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Show the appropriate image only if not purchased
        if (!isPurchased)
        {
            Debug.Log($"[HoverHandler: {gameObject.name}] Pointer Enter.");
            ShowCurrentViewImage();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide the images again if not purchased
        if (!isPurchased)
        {
            Debug.Log($"[HoverHandler: {gameObject.name}] Pointer Exit.");
            HideAllViewImages();
        }
    }

    // ======================================================
    //           PURCHASE OR GACHA "WIN" LOGIC
    // ======================================================
    public void GrantItemFromGacha()
    {
        if (isPurchased) return;
        isPurchased = true;

        // Permanently show the image for the current view
        ShowCurrentViewImage();
        Debug.Log($"[HoverHandler: {gameObject.name}] Item granted from gacha.");
    }

    // ======================================================
    //    SWITCH VIEWS (ENABLE/DISABLE IMAGES)
    // ======================================================
    public void SwitchToFrontView()
    {
        Debug.Log($"[HoverHandler: {gameObject.name}] Switching to Front View.");
        isFrontView = true;

        // Update the view
        if (isPurchased)
        {
            ShowCurrentViewImage();
        }
    }

    public void SwitchToBirdsEyeView()
    {
        Debug.Log($"[HoverHandler: {gameObject.name}] Switching to Bird’s-Eye View.");
        isFrontView = false;

        // Update the view
        if (isPurchased)
        {
            ShowCurrentViewImage();
        }
    }

    // ======================================================
    //          HELPER: SHOW/HIDE IMAGES
    // ======================================================
    private void ShowCurrentViewImage()
    {
        // Hide both images first
        HideAllViewImages();

        // Show the current view image
        if (isFrontView && frontViewImage != null)
        {
            frontViewImage.gameObject.SetActive(true);
        }
        else if (!isFrontView)
        {
            Debug.Log("setbirdeyeviewactive");
            birdsEyeViewImage.gameObject.SetActive(true);
        }
    }

    private void HideAllViewImages()
    {
        if (frontViewImage != null)
        {
            frontViewImage.gameObject.SetActive(false);
        }
        if (birdsEyeViewImage != null)
        {
            birdsEyeViewImage.gameObject.SetActive(false);
        }
    }
}
