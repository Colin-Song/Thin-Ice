using UnityEngine;

public class IDPosition : MonoBehaviour
{
    public GameObject hand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hand = GameObject.Find("Hand");
    }

    // Update is called once per frame
    void Update()
    {
        if (!BoothGlobalObjects.IsIDOpen && !BoothGlobalObjects.IsIDDragging)
        {
            if (BoothGlobalObjects.IsIDWall)
            {
                transform.position = new Vector3(BoothGlobalObjects.IDposx, BoothGlobalObjects.IDposy, transform.position.z);
            }
            else if (BoothGlobalObjects.IsIDAbove)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.17f, transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Right Wall")
        {
            BoothGlobalObjects.IsIDWall = true;
        }
        else if (other.gameObject.name == "Left Wall")
        {
            BoothGlobalObjects.IsIDWall = true;
        }
        else if (other.gameObject.name == "Above Desk" && !BoothGlobalObjects.IsIDOpen)
        {
            BoothGlobalObjects.IsIDAbove = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Right Wall")
        {
            BoothGlobalObjects.IsIDWall = true;
        }
        else if (other.gameObject.name == "Left Wall")
        {
            BoothGlobalObjects.IsIDWall = true;
        }
        else if (other.gameObject.name == "Above Desk" && !BoothGlobalObjects.IsIDOpen)
        {
            BoothGlobalObjects.IsIDAbove = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Right Wall")
        {
            BoothGlobalObjects.IsIDWall = false;
        }
        else if (other.gameObject.name == "Left Wall")
        {
            BoothGlobalObjects.IsIDWall = false;
        }
        else if (other.gameObject.name == "Above Desk" && !BoothGlobalObjects.IsIDOpen)
        {
            BoothGlobalObjects.IsIDAbove = false;
        }
    }
}