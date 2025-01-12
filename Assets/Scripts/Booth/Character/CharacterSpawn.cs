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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        posx = -11.8f;
        posy = 0.69f;
        posz = 0f;

        BoothGlobalObjects.AorR = 'n';
        BoothGlobalObjects.prewalk = true;
        BoothGlobalObjects.middle = false;
        BoothGlobalObjects.afterwalkr = false;
        BoothGlobalObjects.afterwalkl = false;

        Vector3 PrefabPosition = new Vector3(posx, posy, posz);
        Quaternion spawnRotation = Quaternion.identity;

        string[] animals = new string[] { "Cat", "Dog", "Penguin", "Pig", "Bear" };
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

        character.TYPE = animals[type].ToString();
        character.GENDER = Random.Range(0, 2) == 0 ? "Male" : "Female";
        character.AGE = Random.Range(1, 100); // Age between 1 and 99
        character.HEIGHT = Random.Range(100, 200); // Height between 100 and 199
        character.KILLER = Random.Range(0, 2) == 0;
        character.TATTOO = character.KILLER && Random.Range(0, 2) == 0;

        Debug.Log(character.TYPE + " " + character.GENDER + " " + character.AGE + " " + character.HEIGHT + " " + character.KILLER + " " + character.TATTOO);
    }
}