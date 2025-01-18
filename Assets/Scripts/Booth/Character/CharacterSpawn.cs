using System.Reflection;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UIElements;

public class CharacterSpawn : MonoBehaviour
{
    private float posx, posy, posz;
    public static int skin, type;
    public GameObject Cat1, Cat2, Cat3, Dog1, Dog2, Dog3, Penguin1, Penguin2, Penguin3, Pig1, Pig2, Pig3, Bear1, Bear2, Bear3;
    public GameObject characterObject;
    string[] animals = new string[] { "Cat", "Dog", "Penguin", "Pig", "Bear" };
    Vector3 PrefabPosition;
    Quaternion spawnRotation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posx = -11.8f;
        posy = 0.69f;
        posz = 0f;
        Vector3 PrefabPosition = new Vector3(posx, posy, posz);
        spawnRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (!BoothGlobalObjects.CharOnScreen)
        {

            BoothGlobalObjects.CharOnScreen = true;
            CharSpawn();
        }
    }

    void CharSpawn()
    {
        BoothGlobalObjects.AorR = 'n';
        BoothGlobalObjects.prewalk = true;
        BoothGlobalObjects.middle = false;
        BoothGlobalObjects.afterwalkr = false;
        BoothGlobalObjects.afterwalkl = false;

        type = Random.Range(0, 5);
        skin = Random.Range(0, 3);
        if (type == 0)
        {
            if (skin == 0)
            {
                characterObject = Instantiate(Cat1, PrefabPosition, spawnRotation);
            }
            else if (skin == 1) 
            {
                characterObject = Instantiate(Cat2, PrefabPosition, spawnRotation);
            }
            else if (skin == 2)
            {
                characterObject = Instantiate(Cat3, PrefabPosition, spawnRotation);
            }
        }
        else if (type == 1)
        {
            if (skin == 0)
            {
                characterObject = Instantiate(Dog1, PrefabPosition, spawnRotation);
            }
            else if (skin == 1)
            {
                characterObject = Instantiate(Dog2, PrefabPosition, spawnRotation);
            }
            else if (skin == 2)
            {
                characterObject = Instantiate(Dog3, PrefabPosition, spawnRotation);
            }
        }
        else if (type == 2)
        {
            if (skin == 0)
            {
                characterObject = Instantiate(Penguin1, PrefabPosition, spawnRotation);
            }
            else if (skin == 1)
            {
                characterObject = Instantiate(Penguin2, PrefabPosition, spawnRotation);
            }
            else if (skin == 2)
            {
                characterObject = Instantiate(Penguin3, PrefabPosition, spawnRotation);
            }
        }
        else if (type == 3)
        {
            if (skin == 0)
            {
                characterObject = Instantiate(Pig1, PrefabPosition, spawnRotation);
            }
            else if (skin == 1)
            {
                characterObject = Instantiate(Pig2, PrefabPosition, spawnRotation);
            }
            else if (skin == 2)
            {
                characterObject = Instantiate(Pig3, PrefabPosition, spawnRotation);
            }
        }
        else if (type == 4)
        {
            if (skin == 0)
            {
                characterObject = Instantiate(Bear1, PrefabPosition, spawnRotation);
            }
            else if (skin == 1)
            {
                characterObject = Instantiate(Bear2, PrefabPosition, spawnRotation);
            }
            else if (skin == 2)
            {
                characterObject = Instantiate(Bear3, PrefabPosition, spawnRotation);
            }
        }

        CharacterAttributes character = characterObject.GetComponent<CharacterAttributes>();

        BoothGlobalObjects.TYPE = animals[type].ToString();
        BoothGlobalObjects.skin = skin;
        BoothGlobalObjects.GENDER = Random.Range(0, 2) == 0 ? "Male" : "Female";
        BoothGlobalObjects.AGE = Random.Range(1, 100); // Age between 1 and 99
        BoothGlobalObjects.HEIGHT = Random.Range(100, 200); // Height between 100 and 199
        BoothGlobalObjects.KILLER = Random.Range(0, 2) == 0;
        BoothGlobalObjects.TATTOO = BoothGlobalObjects.KILLER && Random.Range(0, 2) == 0;


        //Debug.Log(BoothGlobalObjects.TYPE + " " + BoothGlobalObjects.GENDER + " " + BoothGlobalObjects.AGE + " " + BoothGlobalObjects.HEIGHT + " " + BoothGlobalObjects.KILLER + " " + BoothGlobalObjects.TATTOO);
    }
}