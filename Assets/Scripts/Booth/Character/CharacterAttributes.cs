using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
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
