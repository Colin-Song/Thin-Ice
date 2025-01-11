using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UIElements;

public class CharacterSpawn : MonoBehaviour
{
    private float posx, posy, posz;
    private GameObject character;
    public GameObject CHARACTER;
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

        if (CharacterInfo.AorR == 'a' || CharacterInfo.AorR == 'r')
        {
            if (CharacterInfo.charDelete)
            {
                CharGone();
                BoothGlobalObjects.CharOnScreen = false;
            }
        }
    }

    void CharSpawn()
    {
        posx = -11.8f;
        posy = 0.69f;
        posz = 0f;

        Vector3 CharPosition = new Vector3(posx, posy, posz);
        Quaternion spawnRotation = Quaternion.identity;
        character = Instantiate(CHARACTER, CharPosition, spawnRotation);
    }

    void CharGone()
    {
        Destroy(character);
    }
}
