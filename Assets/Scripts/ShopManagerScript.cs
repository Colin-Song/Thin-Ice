using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    void Start()
    {
         for (int i = 0; i < shopItemsSO.Length; i++){
            shopPanelsGO[i].SetActive(true);
         }

        coinUI.text = "Coins: " + coins.ToString(); 
        LoadPanels();
        CheckPurchaseable();
    }

    void Update()
    {

    }

    public void AddCoins()
    {
        coins++;
        coinUI.text = "Coins: " + coins.ToString();
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
}
