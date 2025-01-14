using UnityEngine;

public class BoothGlobalObjects : MonoBehaviour
{
    // character info
    public static string TYPE = "none";
    public static string GENDER = "none";
    public static int AGE = 0;
    public static int HEIGHT = 0;
    public static bool KILLER = false;
    public static bool TATTOO = false;
    public static bool CharOnScreen = false;
    public static bool charDelete = false;
    public static bool prewalk, middle, afterwalkr, afterwalkl;

    // clipboard
    public static bool IsClipboardDragging = false, IsClipboardOpen = false, IsClipboardWall = false, IsClipboardAbove = false;
    public static float Clipboardposx, Clipboardposy;
    public static char AorR = 'n';

    // id
    public static bool IsIDDragging = false, IsIDOpen = false, IsIDWall = false, IsIDAbove = false;
    public static float IDposx, IDposy;

    // flashlight
    public static bool IsFlashlightHolding = false, IsFlashlightOn = false, IsFlashlightWall = false, IsFlashlightAbove = false;
    public static float Flashlightposx, Flashlightposy;
    public static bool UVOn = false;
    
    // tattoo
    public static bool TattooOn = false;


    public static int customers;

    public static int lfobjects;

    public static bool PopUp;

    private void Start()
    {
        lfobjects = Random.Range(0, 5);
    }
}
