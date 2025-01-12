using UnityEngine;
using UnityEngine.TextCore.Text;

public class CustomerCheck : MonoBehaviour
{
    public GameObject Tattoo, character1, character2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BoothGlobalObjects.AorR == 'a')
        {
            character1 = GameObject.Find("Dog(Clone)");
            character2 = GameObject.Find("Cat(Clone)");
            if (character1 != null)
            {
                CharacterAttributes char1attributes = character1.GetComponent<CharacterAttributes>();
                if (char1attributes.KILLER)
                {

                }
            }
            else if (character2 != null)
            {
                CharacterAttributes char2attributes = character2.GetComponent<CharacterAttributes>();
                if (char2attributes.KILLER)
                {

                }
            }
        }
        else if (BoothGlobalObjects.AorR == 'r')
        {
            character1 = GameObject.Find("Dog(Clone)");
            character2 = GameObject.Find("Cat(Clone)");
            if (character1 != null)
            {
                CharacterAttributes char1attributes = character1.GetComponent<CharacterAttributes>();
                if (!char1attributes.KILLER)
                {
                    GlobalObjects.killerIn = true;
                }
            }
            else if (character2 != null)
            {
                CharacterAttributes char2attributes = character2.GetComponent<CharacterAttributes>();
                if (!char2attributes.KILLER)
                {
                    GlobalObjects.X += 1;
                }
            }
        }
    }
}
