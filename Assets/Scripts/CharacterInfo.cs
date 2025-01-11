using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public static string type, allergies;
    public static char gender, AorR;
    public static int age, height;
    public static bool killer, tattoo;

    private bool prewalk, middle, afterwalk;
    
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
        afterwalk = false;
        AorR = 'n';
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
            if (AorR == 'a' || AorR == 'r')
            {
                middle = false;
                afterwalk = true;
            }
        }
        else if (afterwalk)
        {
            if (AorR == 'a')
            {
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            }
        }
    }
}

