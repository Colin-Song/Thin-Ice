using UnityEngine;

public class GlobalObjects : MonoBehaviour
{
    public static int money, X;
    public static bool killerIn;
    // public static ShopItemSO[] shopItemsSO;
    public static bool[] purchasedItems;

    void Start()
    {
        money = 0;
        X = 0;
        killerIn = false;
    }
}
