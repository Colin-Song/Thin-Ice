using System.Collections.Generic;
using UnityEngine;

public class IceSkatingSceneManager : MonoBehaviour
{
    void Start()
    {
        DisplayPurchasedItems();
    }

    void DisplayPurchasedItems()
    {
        if (GlobalObjects.objectsInScene == null)
        {
            Debug.LogError("GlobalObjects.objectsInScene is null!");
            return;
        }

        foreach (KeyValuePair<string, bool> entry in GlobalObjects.objectsInScene)
        {
            GameObject item = GameObject.Find(entry.Key); // Find object by name

            if (item != null)
            {
                // Set active if purchased
                item.SetActive(entry.Value);
                Debug.Log($"Item '{entry.Key}' set active: {entry.Value}");
            }
            else
            {
                Debug.LogWarning($"Item '{entry.Key}' not found in the scene.");
            }
        }
    }
}
