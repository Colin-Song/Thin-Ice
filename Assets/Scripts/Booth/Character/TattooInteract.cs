using UnityEngine;
public class TattooInteract : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float fadeSpeed = 0.3f;
    public GameObject uvlight, tattoo;

    private float uvlposx, uvlposy, tposx, tposy;
    Color color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        color.a = 0;

        spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (BoothGlobalObjects.TattooOn)
        {
            uvlight = GameObject.Find("UV Light(Clone)");
            tattoo = GameObject.Find("Tattoo(Clone)");
            if (uvlight != null && tattoo != null)
            {
                
                Collider2D uvlightCollider = uvlight.GetComponent<Collider2D>();
                Collider2D tattooCollider = tattoo.GetComponent<Collider2D>();

                uvlposx = uvlightCollider.transform.position.x;
                uvlposy = uvlightCollider.transform.position.y;

                tposx = tattooCollider.transform.position.x;
                tposy = tattooCollider.transform.position.y;
                color = spriteRenderer.color;
                //((uvlposx - 0.75f <= tposx + 1.85f && uvlposy + 0.75 <= tposy + 1.85) || (uvlposx - 0.75f <= tposx + 1.85f && uvlposy - 0.75 >= tposy - 1.85))
                
                if ((uvlposx + 0.75f >= tposx - 1.85f && uvlposy + 0.75 <= tposy + 1.85) || (uvlposx + 0.75f >= tposx - 1.85f && uvlposy - 0.75 >= tposy - 1.85))
                {
                    color.a += fadeSpeed * Time.deltaTime;
                    color.a = Mathf.Clamp01(color.a);
                    spriteRenderer.color = color;
                }

                else
                {
                    color.a -= fadeSpeed * Time.deltaTime;
                    color.a = Mathf.Clamp01(color.a);
                    spriteRenderer.color = color;
                }
            }
        }
    }
}
