using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LostFoundObjects : MonoBehaviour
{
    public static float pos1x, pos1y, pos2x, pos2y, pos3x, pos3y, pos4x, pos4y, pos5x, pos5y;
    public static bool[] placed = { false, false, false, false, false };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos1x = 0f;
        pos1y = 0f;

        pos2x = 0f;
        pos2y = 0f;

        pos3x = 0f;
        pos3y = 0f;

        pos4x = 0f;
        pos4y = 0f;

        pos5x = 0f;
        pos5y = 0f;

        //$"pos{i}x" = 
        for (int i = 0; i < LostFoundClick.items.Length; i++)
        {
            placed[i] = true;
        }
    }
}
