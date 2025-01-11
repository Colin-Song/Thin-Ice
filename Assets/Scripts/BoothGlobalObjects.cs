using UnityEngine;

public class BoothGlobalObjects : MonoBehaviour
{
    public static bool IsClipboardDragging = false, IsClipboardOpen = false, IsClipboardWall = false, IsClipboardAbove = true;
    public static float Clipboardposx, Clipboardposy;

    public static bool IsIDDragging = false, IsIDOpen = false, IsIDWall = false, IsIDAbove = true;
    public static float IDposx, IDposy;

    public static bool IsFlashlightHolding = false, IsFlashlightOn = false, IsFlashlightWall = false, IsFlashlightAbove = true;
    public static float Flashlightposx, Flashlightposy;

    public static bool UVOn = false;
}
