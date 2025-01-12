using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite cs1i, cs2i, cs3i, ds1i, ds2i, ds3i, ps1i, ps2i, ps3i, pis1i, pis2i, pis3i, bs1i, bs2i, bs3i;
    public Sprite cs1m, cs2m, cs3m, ds1m, ds2m, ds3m, ps1m, ps2m, ps3m, pis1m, pis2m, pis3m, bs1m, bs2m, bs3m;
    public Sprite cs1o, cs2o, cs3o, ds1o, ds2o, ds3o, ps1o, ps2o, ps3o, pis1o, pis2o, pis3o, bs1o, bs2o, bs3o;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = false;
    }

    void Update()
    {
        if (BoothGlobalObjects.prewalk)
        {
            if (transform.position.x < 0)
            {
                if (CharacterSpawn.type == 0)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = cs1i;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = cs2i;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = cs3i;
                    }

                }
                else if (CharacterSpawn.type == 1)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = ds1i;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = ds2i;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = ds3i;
                    }
                }
                else if (CharacterSpawn.type == 2)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = ps1i;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = ps2i;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = ps3i;
                    }
                }
                else if (CharacterSpawn.type == 3)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = pis1i;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = pis2i;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = pis3i;
                    }
                }
                else
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = bs1i;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = bs2i;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = bs3i;
                    }
                }
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            }
            else
            {
                BoothGlobalObjects.prewalk = false;
                BoothGlobalObjects.middle = true;
            }
        }
        else if (BoothGlobalObjects.middle)
        {
            if (CharacterSpawn.type == 0)
            {
                if (CharacterSpawn.skin == 0)
                {
                    spriteRenderer.sprite = cs1m;
                }
                else if (CharacterSpawn.skin == 1)
                {
                    spriteRenderer.sprite = cs2m;
                }
                else if (CharacterSpawn.skin == 2)
                {
                    spriteRenderer.sprite = cs3m;
                }

            }
            else if (CharacterSpawn.type == 1)
            {
                if (CharacterSpawn.skin == 0)
                {
                    spriteRenderer.sprite = ds1m;
                }
                else if (CharacterSpawn.skin == 1)
                {
                    spriteRenderer.sprite = ds2m;
                }
                else if (CharacterSpawn.skin == 2)
                {
                    spriteRenderer.sprite = ds3m;
                }
            }
            else if (CharacterSpawn.type == 2)
            {
                if (CharacterSpawn.skin == 0)
                {
                    spriteRenderer.sprite = ps1m;
                }
                else if (CharacterSpawn.skin == 1)
                {
                    spriteRenderer.sprite = ps2m;
                }
                else if (CharacterSpawn.skin == 2)
                {
                    spriteRenderer.sprite = ps3m;
                }
            }
            else if (CharacterSpawn.type == 3)
            {
                if (CharacterSpawn.skin == 0)
                {
                    spriteRenderer.sprite = pis1m;
                }
                else if (CharacterSpawn.skin == 1)
                {
                    spriteRenderer.sprite = pis2m;
                }
                else if (CharacterSpawn.skin == 2)
                {
                    spriteRenderer.sprite = pis3m;
                }
            }
            else
            {
                if (CharacterSpawn.skin == 0)
                {
                    spriteRenderer.sprite = bs1m;
                }
                else if (CharacterSpawn.skin == 1)
                {
                    spriteRenderer.sprite = bs2m;
                }
                else if (CharacterSpawn.skin == 2)
                {
                    spriteRenderer.sprite = bs3m;
                }
            }
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
                if (CharacterSpawn.type == 0)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = cs1o;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = cs2o;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = cs3o;
                    }

                }
                else if (CharacterSpawn.type == 1)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = ds1o;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = ds2o;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = ds3o;
                    }
                }
                else if (CharacterSpawn.type == 2)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = ps1o;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = ps2o;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = ps3o;
                    }
                }
                else if (CharacterSpawn.type == 3)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = pis1o;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = pis2o;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = pis3o;
                    }
                }
                else
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = bs1o;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = bs2o;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = bs3o;
                    }
                }
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            }
            else
            {
                if (CharacterSpawn.type == 0)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = cs1i;
                        spriteRenderer.flipX = true;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = cs2i;
                        spriteRenderer.flipX = true;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = cs3i;
                        spriteRenderer.flipX = true;
                    }

                }
                else if (CharacterSpawn.type == 1)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = ds1i;
                        spriteRenderer.flipX = true;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = ds2i;
                        spriteRenderer.flipX = true;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = ds3i;
                        spriteRenderer.flipX = true;
                    }
                }
                else if (CharacterSpawn.type == 2)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = ps1i;
                        spriteRenderer.flipX = true;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = ps2i;
                        spriteRenderer.flipX = true;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = ps3i;
                        spriteRenderer.flipX = true;
                    }
                }
                else if (CharacterSpawn.type == 3)
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = pis1i;
                        spriteRenderer.flipX = true;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = pis2i;
                        spriteRenderer.flipX = true;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = pis3i;
                        spriteRenderer.flipX = true;
                    }
                }
                else
                {
                    if (CharacterSpawn.skin == 0)
                    {
                        spriteRenderer.sprite = bs1i;
                        spriteRenderer.flipX = true;
                    }
                    else if (CharacterSpawn.skin == 1)
                    {
                        spriteRenderer.sprite = bs2i;
                        spriteRenderer.flipX = true;
                    }
                    else if (CharacterSpawn.skin == 2)
                    {
                        spriteRenderer.sprite = bs3i;
                        spriteRenderer.flipX = true;
                    }
                }
                transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            }

            if (transform.position.x <= -11.8f || transform.position.x >= 11.8f)
            {
                BoothGlobalObjects.charDelete = true;
            }
        }
    }
}

