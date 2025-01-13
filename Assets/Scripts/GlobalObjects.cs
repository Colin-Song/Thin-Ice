using UnityEngine;
using System.Collections.Generic;

public class GlobalObjects: MonoBehaviour
{
    public static GlobalObjects Instance { get; private set; }

    public int money;
    public int X;
    public bool killerIn;
    public int day;
    public int hour;
    public int minute;
    public int moneyCollectedToday;
    public int numCustomersAccepted;
    public int numCustomersRejected;

    public Dictionary<string, bool> objectsInScene = new Dictionary<string, bool>(); // Has all objects in the scene

    private void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            
            DontDestroyOnLoad(gameObject);
            InitializeGlobalVar();

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitializeGlobalVar()
    {
        // Initialize the dictionary in Awake to ensure it's ready before any other script accesses it
        money = 0;
        day = 1;
        hour = 8;
        minute = 0;
        moneyCollectedToday = 0;
        numCustomersAccepted = 0;
        numCustomersRejected = 0;

        string[] allItems = {
            "Blue Ornament", "Candy Cane", "Christmas Lights", 
            "Silver Ornament", "Green Ornament", "Purple Ornament", 
            "Red Ornament", "Santa", "Snowman", "Navy Ornament"
        };

        for (int i = 0; i < allItems.Length; i++)
        {
            objectsInScene.Add(allItems[i], false);
        }

        Debug.Log("GlobalObjects initialized successfully.");
    }
}