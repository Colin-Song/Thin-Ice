using UnityEngine;

public class TattooSpawn : MonoBehaviour
{
    private float posx, posy, posz;
    public GameObject Tattoo, character1, character2, character3, character4, character5;
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
                character1 = GameObject.Find("Cat(Clone)");
                character2 = GameObject.Find("Dog(Clone)");
                character3 = GameObject.Find("Penguin(Clone)");
                character4 = GameObject.Find("Pig(Clone)");
                character5 = GameObject.Find("Bear(Clone)");

                Debug.Log("hi");
                if (character1 != null)
                {
                    if (BoothGlobalObjects.TATTOO && !BoothGlobalObjects.TattooOn)
                    {
                        TattooCreate();
                        BoothGlobalObjects.TattooOn = true;
                    }
                }
                else if (character2 != null)
                {
                    if (BoothGlobalObjects.TATTOO && !BoothGlobalObjects.TattooOn)
                    {
                        TattooCreate();
                        BoothGlobalObjects.TattooOn = true;
                    }
                }
                else if (character3 != null)
                {
                    if (BoothGlobalObjects.TATTOO && !BoothGlobalObjects.TattooOn)
                    {
                        TattooCreate();
                        BoothGlobalObjects.TattooOn = true;
                    }
                }
                else if (character4 != null)
                {
                    if (BoothGlobalObjects.TATTOO && !BoothGlobalObjects.TattooOn)
                    {
                        TattooCreate();
                        BoothGlobalObjects.TattooOn = true;
                    }
                }
                else if (character5 != null)
                {
                    if (BoothGlobalObjects.TATTOO && !BoothGlobalObjects.TattooOn)
                    {
                        TattooCreate();
                        BoothGlobalObjects.TattooOn = true;
                    }
                }
            }
        }
    }

    void TattooCreate()
    {
        posx = Random.Range(-0.6f, 0.6f);
        posy = Random.Range(-1.06f, 2.63f);
        posz = 0f;

        Vector3 TattooPosition = new Vector3(posx, posy, posz);
        Quaternion spawnRotation = Quaternion.identity;
        GameObject tattoo = Instantiate(Tattoo, TattooPosition, spawnRotation);
    }
}
