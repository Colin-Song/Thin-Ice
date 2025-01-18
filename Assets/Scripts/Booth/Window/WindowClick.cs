using UnityEngine;
using UnityEngine.SceneManagement;
public class WindowClick : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D handCollider = hand.GetComponent<Collider2D>();
            Collider2D popupCollider = GetComponent<Collider2D>();
            if (handCollider.bounds.Intersects(popupCollider.bounds))
            {
                SceneManager.LoadScene("IceSkating");
               
            }
        }
    }
}
