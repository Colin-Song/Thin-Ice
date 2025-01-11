using UnityEngine;

public class UVLightSpawn : MonoBehaviour
{
    private float posx, posy, posz;
    private GameObject uvlight;
    public GameObject UVLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BoothGlobalObjects.IsFlashlightOn)
        {
            if (!BoothGlobalObjects.UVOn)
            {
                BoothGlobalObjects.UVOn = true;
                FlashOn();
            }
        }
        else
        {
            if (BoothGlobalObjects.UVOn)
            {
                BoothGlobalObjects.UVOn = false;
                FlashOff();
            }
        }
    }

    void FlashOn()
    {
        posx = GameObject.Find("Flashlight").transform.position.x;
        posy = GameObject.Find("Flashlight").transform.position.y + 3f;
        posz = GameObject.Find("Flashlight").transform.position.y;

        Vector3 UVLightPosition = new Vector3(posx, posy, posz);
        Quaternion spawnRotation = Quaternion.identity;
        uvlight = Instantiate(UVLight, UVLightPosition, spawnRotation);
    }

    void FlashOff()
    {
        Destroy(uvlight);
    }
}
