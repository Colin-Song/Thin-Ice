using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;

    public TMP_Text coinUI1;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    public HoverHandler[] hoverHandlers;

    private bool[] purchasedItems; // To track purchased items

    // Gacha System
    public int gachaCost = 15;           // Cost for one gacha spin
   // public GameObject postProcessVolume; // Reference to the Post-Processing Volume (blur effect)
   // public Animator gachaAnimator;       // Animator for the gacha animation
    public GameObject gachaPopup;        // Pop-up window to display the gacha result
    public Image rewardImage;            // Image for the reward
    public TMP_Text rewardText;          // Text for the reward name
    public Button gachaButton;           // Button to trigger the gacha spin

    public Button openGatchaButton;

    public GameObject insufficientFundsPopup; // Reference to the insufficient funds popup


    private bool isGachaActive = false;  // Prevents multiple spins during an active gacha process

    /*
    Stuff required to switch scenes
    */
    public Button toggleCanvasButton;
    public Canvas canvasA; 
    public Canvas canvasB;

    private bool showingCanvasA = true;

    void Start()
    {
        purchasedItems = new bool[shopItemsSO.Length]; // Initialize purchased items tracking

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }

        coinUI.text = "Coins: " + coins.ToString();
        coinUI1.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();

        if (coinUI1 == null)
    {
        Debug.LogWarning("coinUI1 is not assigned!");
    }
    else
    {
        Debug.Log("coinUI1 is assigned successfully.");
    }
    }

    void Update()
    {
    }

    public void OpenGachaWindow()
    {
        // Show the gacha window
        gachaPopup.SetActive(true);
        openGatchaButton.gameObject.SetActive(false);
    }

    public void CloseGachaWindow()
{
    gachaPopup.SetActive(false); // Hide the Gacha window
    openGatchaButton.gameObject.SetActive(true); // Show the Open Gacha button
    isGachaActive = false; // Reset Gacha active state
}

      public void AddCoins()
    {
        coins++;
        coinUI.text = "Coins: " + coins.ToString();
        coinUI1.text = "Coins: " + coins.ToString();
        CheckPurchaseable(); 
    }

    public void CheckPurchaseable(){
        for(int i = 0; i < shopItemsSO.Length; i++) {
            if (coins >= shopItemsSO[i].baseCost){
                myPurchaseBtns[i].interactable = true;
            } else {
                myPurchaseBtns[i].interactable = false; 
            }
        }
    }

    public void PurchaseItem(int btnNo){
        Debug.Log(btnNo);
        Debug.Log(shopItemsSO.Length); 
        if (coins >= shopItemsSO[btnNo].baseCost){
            coins = coins - shopItemsSO[btnNo].baseCost;
            coinUI.text = "Coins: " + coins.ToString();
            coinUI1.text = "Coins: " + coins.ToString();
            CheckPurchaseable(); 
        }
    }

   public void LoadPanels() {
    for (int i = 0; i < shopItemsSO.Length; i++) { 
        shopPanels[i].titleTxt.text = shopItemsSO[i].title;
        shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
        shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString(); 
    }
}

    // Gacha System Logic
public void StartGacha()
{
    Debug.Log("StartGacha triggered");



    if (isGachaActive || coins < gachaCost || coins < gachaCost) 
    {
        Debug.Log("Insufficient funds for gacha spin.");
        ShowInsufficientFundsPopup();
        return;
    }

    isGachaActive = true;

    // Deduct coins for the gacha spin
    coins -= gachaCost;
    coinUI.text = "Coins: " + coins.ToString();
    coinUI1.text = "Coins: " + coins.ToString();
    CheckPurchaseable();

    Debug.Log("Gacha spin started.");
    gachaPopup.SetActive(true); // Open the popup immediately, even if reward is hidden.

    // Hide reward image and text
    if (rewardImage != null) rewardImage.gameObject.SetActive(false);
    if (rewardText != null) rewardText.gameObject.SetActive(false);

    Invoke("OnGachaAnimationComplete", 1.0f); // 2-second delay
}



    // Called at the end of the gacha animation (via Animation Event)
public void OnGachaAnimationComplete()
{
    Debug.Log("OnGachaAnimationComplete called");

    int maxAttempts = 50;
    int attempts = 0;
    int rewardIndex = -1;

    // Attempt to find a random unpurchased item
    while (attempts < maxAttempts)
    {
        if (AllItemsPurchased())
        {
            Debug.Log("All items purchased!");
            rewardIndex = -1;
            break;
        }

        int randomIndex = Random.Range(0, shopItemsSO.Length);

        if (!purchasedItems[randomIndex])
        {
            rewardIndex = randomIndex;
            Debug.Log($"Reward chosen: {shopItemsSO[randomIndex].title}");
            break;
        }

        attempts++;
    }

    if (rewardIndex == -1)
    {
        rewardText.text = "All items have been purchased!";
        rewardImage.sprite = null; // No reward image
    }
    else
    {
        // Mark the item as purchased
        purchasedItems[rewardIndex] = true;

        // Update reward UI
        rewardImage.sprite = shopItemsSO[rewardIndex].itemImage;
        rewardText.text = $"You received: {shopItemsSO[rewardIndex].title}";

        // Disable the item’s purchase button if you still use it
        myPurchaseBtns[rewardIndex].interactable = false;
        myPurchaseBtns[rewardIndex].GetComponentInChildren<TMP_Text>().text = "Purchased";

        // ======================
        //      NEW CODE
        // ======================
        // If you use a parallel array approach:
        hoverHandlers[rewardIndex].GrantItemFromGacha();

        



       if (showingCanvasA){
        hoverHandlers[rewardIndex].SwitchToFrontView();
       } else {
        hoverHandlers[rewardIndex].SwitchToBirdsEyeView();
       }


        // OR, if searching for the matching HoverHandler:
        /*
        HoverHandler[] allHandlers = FindObjectsOfType<HoverHandler>();
        foreach (HoverHandler handler in allHandlers)
        {
            if (handler.shopItem == shopItemsSO[rewardIndex])
            {
                handler.GrantItemFromGacha();
                break;
            }
        }
        */
    }

    // Show the reward popup
    rewardImage.gameObject.SetActive(true);
    rewardText.gameObject.SetActive(true);

    Debug.Log("Reward displayed, popup is visible.");
    isGachaActive = false;
}


public void ShowInsufficientFundsPopup()
{
    insufficientFundsPopup.SetActive(true); // Show the pop-up
    Invoke("CloseInsufficientFundsPopup", 2.0f); // Automatically close after 2 seconds
}

public void CloseInsufficientFundsPopup()
{
    insufficientFundsPopup.SetActive(false); // Hide the pop-up
}






    public void CloseGachaPopup()
    {
        gachaPopup.SetActive(false);
        openGatchaButton.gameObject.SetActive(true);
        //postProcessVolume.SetActive(false);
    }

    private bool AllItemsPurchased()
    {
        foreach (bool purchased in purchasedItems)
        {
            if (!purchased) return false;
        }
        return true;
    }

     public void ToggleCanvasVisibility()
    {
        // Flip the boolean
        showingCanvasA = !showingCanvasA;

        if (showingCanvasA)
        {
            ShowCanvasA();
        }
        else
        {
            ShowCanvasB();
        }
    }

  private void ShowCanvasA()
{
    if (canvasA != null) canvasA.gameObject.SetActive(true);
    if (canvasB != null) canvasB.gameObject.SetActive(false);

    Debug.Log("Canvas A is now active, Canvas B is hidden.");

    // Loop through all HoverHandlers and call SwitchToFrontView
    for (int i = 0; i < hoverHandlers.Length; i++)
    {
        hoverHandlers[i].SwitchToFrontView();
    }
}

private void ShowCanvasB()
{
    if (canvasA != null) canvasA.gameObject.SetActive(false);
    if (canvasB != null) canvasB.gameObject.SetActive(true);

    Debug.Log("Canvas B is now active, Canvas A is hidden.");

    // Loop through all HoverHandlers and call SwitchToBirdsEyeView
    for (int i = 0; i < hoverHandlers.Length; i++)
    {
        hoverHandlers[i].SwitchToBirdsEyeView();
    }
}

   

}
