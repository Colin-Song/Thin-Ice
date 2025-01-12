using UnityEngine;

public class TattooDestroy : MonoBehaviour
{
    void Update()
    {
        //character.GetComponent<RectTransform>().anchoredPosition.x <= -11.8
        if (BoothGlobalObjects.afterwalkr || BoothGlobalObjects.afterwalkl)
        {
            TattooGone();
            BoothGlobalObjects.TattooOn = false;
        }
    }

    void TattooGone()
    {
        Destroy(gameObject);
    }
}

