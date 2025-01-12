using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    /*
    public static string[] TYPE = { "dog", "cat" }, ALLERGIES;
    public static char[] GENDER = { 'm', 'f' };
    public static int[] AGE = { 1, 99 }, HEIGHT = { 100, 190 };
    public static bool[] KILLER = { true, false }, TATTOO = { true, false };
    */

    public string TYPE { get; set; }
    public string GENDER { get; set; }
    public int AGE { get; set; }
    public int HEIGHT { get; set; }
    public bool KILLER { get; set; }
    public bool TATTOO { get; set; }

    void Update()
    {
        //character.GetComponent<RectTransform>().anchoredPosition.x <= -11.8
        if (BoothGlobalObjects.charDelete)
        {
            CharGone();
            BoothGlobalObjects.CharOnScreen = false;
            BoothGlobalObjects.charDelete = false;
        }
    }

    void CharGone()
    {
        Destroy(gameObject);
    }
}
