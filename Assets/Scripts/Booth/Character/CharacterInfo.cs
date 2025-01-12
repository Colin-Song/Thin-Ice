using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (BoothGlobalObjects.prewalk)
        {
            if (transform.position.x < 0)
            {
                transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y, transform.position.z);
            }
            else
            {
                BoothGlobalObjects.prewalk = false;
                BoothGlobalObjects.middle = true;
            }
        }
        else if (BoothGlobalObjects.middle)
        {
            if (BoothGlobalObjects.AorR == 'a')
            {
                BoothGlobalObjects.middle = false;
                BoothGlobalObjects.afterwalkr = true;
                BoothGlobalObjects.IsClipboardOpen = false;
                BoothGlobalObjects.IsClipboardDragging = false;
            }
            else if (BoothGlobalObjects.AorR == 'r')
            {
                BoothGlobalObjects.middle = false;
                BoothGlobalObjects.afterwalkl = true;
                BoothGlobalObjects.IsClipboardOpen = false;
                BoothGlobalObjects.IsClipboardDragging = false;
            }
        }
        else if (BoothGlobalObjects.afterwalkr || BoothGlobalObjects.afterwalkl)
        {
            
            if (BoothGlobalObjects.afterwalkr)
            {

                transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 0.03f, transform.position.y, transform.position.z);
            }

            if (transform.position.x <= -11.8f || transform.position.x >= 11.8f)
            {
                BoothGlobalObjects.charDelete = true;
            }
        }
    }
}

