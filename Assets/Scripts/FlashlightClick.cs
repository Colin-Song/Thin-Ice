using UnityEngine;

public class FlashlightClick : MonoBehaviour
{
    // clipboard sizes
    public GameObject hand;

    void Start()
    {

    }

    private void Update()
    {
        if (BoothGlobalObjects.IsFlashlightHolding)
        {
            if (Input.GetMouseButtonDown(1))
            {
                BoothGlobalObjects.IsFlashlightOn = !BoothGlobalObjects.IsFlashlightOn;
            }
        }
    }
}

