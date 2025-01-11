using UnityEngine;

public class FlashlightPosition : MonoBehaviour
{
    public GameObject hand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!BoothGlobalObjects.IsFlashlightOn && !BoothGlobalObjects.IsFlashlightHolding)
        {
            if (BoothGlobalObjects.IsFlashlightWall)
            {
                transform.position = new Vector3(BoothGlobalObjects.Flashlightposx, BoothGlobalObjects.Flashlightposy, transform.position.z);
            }
            else if (BoothGlobalObjects.IsFlashlightAbove)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.17f, transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Right Wall")
        {
            BoothGlobalObjects.IsFlashlightWall = true;
        }
        else if (other.gameObject.name == "Left Wall")
        {
            BoothGlobalObjects.IsFlashlightWall = true;
        }
        else if (other.gameObject.name == "Above Desk")
        {
            BoothGlobalObjects.IsFlashlightAbove = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Right Wall")
        {
            BoothGlobalObjects.IsFlashlightWall = true;
        }
        else if (other.gameObject.name == "Left Wall")
        {
            BoothGlobalObjects.IsFlashlightWall = true;
        }
        else if (other.gameObject.name == "Above Desk")
        {
            BoothGlobalObjects.IsFlashlightAbove = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Right Wall")
        {
            BoothGlobalObjects.IsFlashlightWall = false;
        }
        else if (other.gameObject.name == "Left Wall")
        {
            BoothGlobalObjects.IsFlashlightWall = false;
        }
        else if (other.gameObject.name == "Above Desk")
        {
            BoothGlobalObjects.IsFlashlightAbove = false;
        }
    }
}
