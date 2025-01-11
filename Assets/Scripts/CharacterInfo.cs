using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public static string type, allergies;
    public static char gender, AorR;
    public static int age, height;
    public static bool killer, tattoo, charDelete;

    private bool prewalk, middle, afterwalkr, afterwalkl;
    
    void Start()
    {
        type = CharacterAttributes.TYPE[Random.Range(1, 2)];
        //allergies = CharacterAttributes.ALLERGIES[Random.Range(1, 2)];
        gender = CharacterAttributes.GENDER[Random.Range(1, 2)];
        age = CharacterAttributes.AGE[Random.Range(1, 2)];
        height = CharacterAttributes.HEIGHT[Random.Range(1, 2)];
        killer = CharacterAttributes.KILLER[Random.Range(1, 2)];
        if (killer)
        {
            tattoo = CharacterAttributes.TATTOO[Random.Range(1, 2)];
        }
        else
        {
            tattoo = false;
        }

        prewalk = true;
        middle = false;
        afterwalkr = false;
        afterwalkl = false;
        AorR = 'n';
        charDelete = false;
    }

    void Update()
    {
        if (prewalk)
        {
            if (transform.position.x < 0)
            {
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            }
            else
            {
                prewalk = false;
                middle = true;
            }
        }
        else if (middle)
        {
            if (AorR == 'a')
            {
                middle = false;
                afterwalkr = true;
            }
            else if (AorR == 'r')
            {
                middle = false;
                afterwalkl = true;
            }
        }
        else if (afterwalkr || afterwalkl)
        {
            if (afterwalkr)
            {
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            }

            if (transform.position.x <= -11.8f || transform.position.x >= 11.8f)
            {
                charDelete = true;
            }
        }
    }
}

