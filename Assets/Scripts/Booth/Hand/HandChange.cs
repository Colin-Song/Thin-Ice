using UnityEngine;

public class HandChange : MonoBehaviour
{
    public Sprite newSprite1, newSprite2, newSprite3;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BoothGlobalObjects.IsFlashlightHolding && !BoothGlobalObjects.IsFlashlightOn)
        {
            spriteRenderer.sprite = newSprite1;
        }
        else if (BoothGlobalObjects.IsFlashlightHolding && BoothGlobalObjects.IsFlashlightOn)
        {
            spriteRenderer.sprite = newSprite2;
        }
        else if (!BoothGlobalObjects.IsFlashlightHolding && !BoothGlobalObjects.IsFlashlightOn)
        {
            spriteRenderer.sprite = newSprite3;
        }
    }
}
