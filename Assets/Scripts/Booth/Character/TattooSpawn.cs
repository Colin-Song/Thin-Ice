using UnityEngine;

public class TattooSpawn : MonoBehaviour
{
    private float posx, posy, posz;
    public GameObject Tattoo, character1, character2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BoothGlobalObjects.CharOnScreen)
        {
            if (BoothGlobalObjects.middle)
            {
                
                character1 = GameObject.Find("Dog(Clone)");
                character2 = GameObject.Find("Cat(Clone)");
                if (character1 != null)
                {
                    CharacterAttributes char1attributes = character1.GetComponent<CharacterAttributes>();
                    if (char1attributes.TATTOO && !BoothGlobalObjects.TattooOn)
                    {
                        BoothGlobalObjects.TattooOn = true;
                        TattooCreate();
                    }
                }
                else if (character2 != null)
                {
                    CharacterAttributes char2attributes = character2.GetComponent<CharacterAttributes>();
                    if (char2attributes.TATTOO && !BoothGlobalObjects.TattooOn)
                    {
                        BoothGlobalObjects.TattooOn = true;
                        TattooCreate();
                    }
                }
            }
        }
    }

    void TattooCreate()
    {
        posx = Random.Range(-2.11f, 2.11f);
        posy = Random.Range(-0.46f, 1.49f);
        posz = 0f;

        Vector3 TattooPosition = new Vector3(posx, posy, posz);
        Quaternion spawnRotation = Quaternion.identity;
        GameObject tattoo = Instantiate(Tattoo, TattooPosition, spawnRotation);
    }
}
