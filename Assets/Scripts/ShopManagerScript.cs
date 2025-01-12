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

    public GameObject ownedItemPopup; // Reference to the "Item Already Owned" popup
     public TMP_Text ownedItemText;

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
        //CheckPurchaseable();

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
    // Reset the reward text and image
    if (rewardText != null)
    {
        rewardText.text = string.Empty; // Clear the reward text
        rewardText.gameObject.SetActive(false); // Hide the reward text
    }
    if (rewardImage != null)
    {
        rewardImage.sprite = null; // Remove the reward image
        rewardImage.gameObject.SetActive(false); // Hide the reward image
    }

    // Show the Gacha window
    gachaPopup.SetActive(true);
    openGatchaButton.gameObject.SetActive(false);
    toggleCanvasButton.gameObject.SetActive(false);
}


    public void CloseGachaWindow()
{
    gachaPopup.SetActive(false); // Hide the Gacha window
    openGatchaButton.gameObject.SetActive(true); // Show the Open Gacha button
    toggleCanvasButton.gameObject.SetActive(true);
    isGachaActive = false; // Reset Gacha active state
}

      public void AddCoins()
    {
        coins++;
        coinUI.text = "Coins: " + coins.ToString();
        coinUI1.text = "Coins: " + coins.ToString();
       // CheckPurchaseable(); 
    }

   /* public void CheckPurchaseable(){
        for(int i = 0; i < shopItemsSO.Length; i++) {
            if (coins >= shopItemsSO[i].baseCost){
                myPurchaseBtns[i].interactable = true;
            } else {
                myPurchaseBtns[i].interactable = false; 
            }
        }
    }*/

 /*   public void PurchaseItem(int btnNo){
        Debug.Log(btnNo);
        Debug.Log(shopItemsSO.Length); 
        if (coins >= shopItemsSO[btnNo].baseCost){
            coins = coins - shopItemsSO[btnNo].baseCost;
            coinUI.text = "Coins: " + coins.ToString();
            coinUI1.text = "Coins: " + coins.ToString();
            CheckPurchaseable(); 
        }
    }*/

   public void LoadPanels() {
    for (int i = 0; i < shopItemsSO.Length; i++) { 
        Debug.Log($"Setting panel {i} with item {shopItemsSO[i].title}");
        shopPanels[i].titleTxt.text = shopItemsSO[i].title;
        //shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
        //shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString(); 
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
   // CheckPurchaseable();

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

    while (attempts < maxAttempts)
    {
        // Randomly select an item
        int randomIndex = Random.Range(0, shopItemsSO.Length);

        if (purchasedItems[randomIndex])
        {
            // If the item is already owned, show a popup and break
            rewardIndex = randomIndex;
            Debug.Log($"Item already owned: {shopItemsSO[randomIndex].title}");


            // Update the "Item Already Owned" popup
            ownedItemText.text = $"You already own: {shopItemsSO[randomIndex].title}";
            //Invoke("ownedItemPopup", 2.0f)
            ShowOwnedPopup(); 
            return; // Exit the function without giving a reward
        }

        rewardIndex = randomIndex;
        Debug.Log($"Reward chosen: {shopItemsSO[rewardIndex].title}");
        break;
    }

    if (rewardIndex == -1)
    {
        // If no valid item is found, fallback behavior
        rewardText.text = "No reward selected!";
        rewardImage.sprite = null;
        rewardImage.gameObject.SetActive(false);
    }
    else
    {
        // Update reward UI for newly received items
        purchasedItems[rewardIndex] = true;
        rewardImage.sprite = shopItemsSO[rewardIndex].itemImage;
        rewardText.text = $"You received: {shopItemsSO[rewardIndex].title}";

        rewardImage.gameObject.SetActive(true);
        rewardText.gameObject.SetActive(true);

        // Call hover handler for the item
        hoverHandlers[rewardIndex].GrantItemFromGacha();

        // Update view
        if (showingCanvasA)
        {
            hoverHandlers[rewardIndex].SwitchToFrontView();
        }
        else
        {
            hoverHandlers[rewardIndex].SwitchToBirdsEyeView();
        }
    }

    Debug.Log("Reward displayed.");
    isGachaActive = false;
}


public void ShowOwnedPopup()
{
    ownedItemPopup.SetActive(true); // Show the pop-up
    Invoke("CloseOwnedPopup", 2.0f); // Automatically close after 2 seconds
}

public void CloseOwnedPopup()
{
    ownedItemPopup.SetActive(false); // Hide the pop-up
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
        toggleCanvasButton.gameObject.SetActive(true);
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
