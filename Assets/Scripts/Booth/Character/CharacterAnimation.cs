using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite startsprite, midsprite;
    private bool prewalk, afterwalk;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = false;
        prewalk = false;
        afterwalk = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BoothGlobalObjects.prewalk && !prewalk)
        {
            prewalk = true;
            spriteRenderer.sprite = startsprite;
        }
        else if (BoothGlobalObjects.middle)
        {
            spriteRenderer.sprite = midsprite;
        }
        else if (BoothGlobalObjects.afterwalkr && !afterwalk)
        {
            afterwalk = true;
            spriteRenderer.sprite = startsprite;
        }
        else if (BoothGlobalObjects.afterwalkl && !afterwalk)
        {
            afterwalk = true;
            spriteRenderer.sprite = startsprite;
            spriteRenderer.flipX = true;
        }
    }
}
