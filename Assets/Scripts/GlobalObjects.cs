using UnityEngine;
using System.Collections.Generic;

public class GlobalObjects : MonoBehaviour
{
    public static int money, X;
    public static bool killerIn;

    public static Dictionary<string, bool> objectsInScene; // Has all objects in the scene

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        money = 0;
        X = 0;
        killerIn = false;

        // Initialize the dictionary in Awake to ensure it's ready before any other script accesses it
        objectsInScene = new Dictionary<string, bool>();

        string[] allItems = {
            "Blue Ornament", "Candy Cane", "Christmas Lights", 
            "Silver Ornament", "Green Ornament", "Purple Ornament", 
            "Red Ornament", "Santa", "Snowman", "Navy Ornament"
        };

        for (int i = 0; i < allItems.Length; i++)
        {
            objectsInScene[allItems[i]] = false;
        }

        Debug.Log("GlobalObjects initialized successfully.");
    }
}
