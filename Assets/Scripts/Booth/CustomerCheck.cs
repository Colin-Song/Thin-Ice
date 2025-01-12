using UnityEngine;
using UnityEngine.TextCore.Text;

public class CustomerCheck : MonoBehaviour
{
    public GameObject char1, char2, char3, char4, char5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BoothGlobalObjects.AorR == 'a')
        {
            char1 = GameObject.Find("Cat(Clone)");
            char2 = GameObject.Find("Dog(Clone)");
            char3 = GameObject.Find("Penguin(Clone)");
            char4 = GameObject.Find("Pig(Clone)");
            char5 = GameObject.Find("Bear(Clone)");

            if (char1 != null)
            {
                CharacterAttributes char1attributes = char1.GetComponent<CharacterAttributes>();
                if (char1attributes.KILLER)
                {
                    GlobalObjects.killerIn = true;
                }
            }
            else if (char2 != null)
            {
                CharacterAttributes char2attributes = char2.GetComponent<CharacterAttributes>();
                if (char2attributes.KILLER)
                {
                    GlobalObjects.killerIn = true;
                }
            }
            else if (char3 != null)
            {
                CharacterAttributes char3attributes = char3.GetComponent<CharacterAttributes>();
                if (char3attributes.KILLER)
                {
                    GlobalObjects.killerIn = true;
                }
            }
            else if (char4 != null)
            {
                CharacterAttributes char4attributes = char4.GetComponent<CharacterAttributes>();
                if (char4attributes.KILLER)
                {
                    GlobalObjects.killerIn = true;
                }
            }
            else if (char5 != null)
            {
                CharacterAttributes char5attributes = char5.GetComponent<CharacterAttributes>();
                if (char5attributes.KILLER)
                {
                    GlobalObjects.killerIn = true;
                }
            }
        }
        else if (BoothGlobalObjects.AorR == 'r')
        {
            char1 = GameObject.Find("Cat(Clone)");
            char2 = GameObject.Find("Dog(Clone)");
            char3 = GameObject.Find("Penguin(Clone)");
            char4 = GameObject.Find("Pig(Clone)");
            char5 = GameObject.Find("Bear(Clone)");

            if (char1 != null)
            {
                CharacterAttributes char1attributes = char1.GetComponent<CharacterAttributes>();
                if (!char1attributes.KILLER)
                {
                    GlobalObjects.X += 1;
                }
            }
            else if (char2 != null)
            {
                CharacterAttributes char2attributes = char2.GetComponent<CharacterAttributes>();
                if (!char2attributes.KILLER)
                {
                    GlobalObjects.X += 1;
                }
            }
            else if (char3 != null)
            {
                CharacterAttributes char3attributes = char3.GetComponent<CharacterAttributes>();
                if (!char3attributes.KILLER)
                {
                    GlobalObjects.X += 1;
                }
            }
            else if (char4 != null)
            {
                CharacterAttributes char4attributes = char4.GetComponent<CharacterAttributes>();
                if (!char4attributes.KILLER)
                {
                    GlobalObjects.X += 1;
                }
            }
            else if (char5 != null)
            {
                CharacterAttributes char5attributes = char5.GetComponent<CharacterAttributes>();
                if (!char5attributes.KILLER)
                {
                    GlobalObjects.X += 1;
                }
            }
        }
    }
}
