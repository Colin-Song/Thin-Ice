using UnityEngine;

public class UVLightMovement : MonoBehaviour
{
    private float posx, posy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BoothGlobalObjects.IsFlashlightOn)
        {
            posx = GameObject.Find("Flashlight").transform.position.x;
            posy = GameObject.Find("Flashlight").transform.position.y;
            transform.position = new Vector3(posx, posy + 3f, transform.position.z);
        }
        
    }
}
