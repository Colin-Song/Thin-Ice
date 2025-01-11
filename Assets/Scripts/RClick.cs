using UnityEngine;

public class RClick : MonoBehaviour
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
        if (AorRSpawn.buttonsOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D handCollider = hand.GetComponent<Collider2D>();
                Collider2D rejectCollider = GetComponent<Collider2D>();
                if (handCollider.bounds.Intersects(rejectCollider.bounds))
                {
                    CharacterInfo.AorR = 'r';
                }
            }
        }
    }
}

