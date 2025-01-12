using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UIElements;

public class CharacterSpawn : MonoBehaviour
{
    private float posx, posy, posz;
    public GameObject Dog;
    public GameObject Cat;
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
        bool type = Random.Range(0, 2) == 0;
        GameObject prefab = type ? Dog : Cat;
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

        character.TYPE = type ? "dog" : "cat";
        character.GENDER = Random.Range(0, 2) == 0 ? "Male" : "Female";
        character.AGE = Random.Range(1, 100); // Age between 1 and 99
        character.HEIGHT = Random.Range(100, 200); // Height between 100 and 199
        character.KILLER = Random.Range(0, 2) == 0;
        character.TATTOO = character.KILLER && Random.Range(0, 2) == 0;

        Debug.Log(character.TYPE + " " + character.GENDER + " " + character.AGE + " " + character.HEIGHT + " " + character.KILLER + " " + character.TATTOO);
    }
}