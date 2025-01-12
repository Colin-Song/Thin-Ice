using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UIElements;

public class CharacterSpawn : MonoBehaviour
{
    private float posx, posy, posz;
    public static int skin, type;
    public GameObject Cat, Dog, Penguin, Pig, Bear, prefab;
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
        string[] animals = new string[] { "Cat", "Dog", "Penguin", "Pig", "Bear" };
        type = Random.Range(0, 5);
        skin = Random.Range(0, 3);
        if (type == 0)
        {
            prefab = Cat;
        }
        else if (type == 1)
        {
            prefab = Dog;
        }
        else if (type == 2)
        {
            prefab = Penguin;
        }
        else if (type == 3)
        {
            prefab = Pig;
        }
        else
        {
            prefab = Bear;
        }

        posx = -11.8f;
        posy = 0.69f;
        posz = 0f;

        Vector3 PrefabPosition = new Vector3(posx, posy, posz);
        Quaternion spawnRotation = Quaternion.identity;
        characterObject = Instantiate(prefab, PrefabPosition, spawnRotation);

        CharacterAttributes character = characterObject.GetComponent<CharacterAttributes>();

        BoothGlobalObjects.AorR = 'n';
        BoothGlobalObjects.prewalk = true;
        BoothGlobalObjects.middle = false;
        BoothGlobalObjects.afterwalkr = false;
        BoothGlobalObjects.afterwalkl = false;

        character.TYPE = prefab.ToString();
        character.GENDER = Random.Range(0, 2) == 0 ? "Male" : "Female";
        character.AGE = Random.Range(1, 100); // Age between 1 and 99
        character.HEIGHT = Random.Range(100, 200); // Height between 100 and 199
        character.KILLER = Random.Range(0, 2) == 0;
        character.TATTOO = character.KILLER && Random.Range(0, 2) == 0;

        Debug.Log(character.TYPE + " " + character.GENDER + " " + character.AGE + " " + character.HEIGHT + " " + character.KILLER + " " + character.TATTOO);
    }
}