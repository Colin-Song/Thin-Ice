using UnityEngine;

public class BoothGlobalObjects : MonoBehaviour
{
    public static bool IsClipboardDragging = false, IsClipboardOpen = false, IsClipboardWall = false, IsClipboardAbove = false;
    public static float Clipboardposx, Clipboardposy;

    public static bool IsIDDragging = false, IsIDOpen = false, IsIDWall = false, IsIDAbove = false;
    public static float IDposx, IDposy;

    public static bool IsFlashlightHolding = false, IsFlashlightOn = false, IsFlashlightWall = false, IsFlashlightAbove = false;
    public static float Flashlightposx, Flashlightposy;

    public static bool UVOn = false, CharOnScreen = false, TattooOn = false;

    public static char AorR = 'n';
    public static bool charDelete = false;
    public static bool prewalk, middle, afterwalkr, afterwalkl;

    public static int customers;
}
