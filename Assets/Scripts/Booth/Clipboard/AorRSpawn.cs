using UnityEngine;
using UnityEngine.TextCore.Text;

public class AorRSpawn : MonoBehaviour
{
    public static bool buttonsOn;
    public static char result;

    private float Aposx, Aposy, Aposz, Rposx, Rposy, Rposz;
    private GameObject accept, reject;
    public GameObject ACCEPT, REJECT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonsOn = false;
        result = 'n';
    }

    // Update is called once per frame
    void Update()
    {
        if (BoothGlobalObjects.IsClipboardOpen)
        {
            if (!buttonsOn) 
            {
                buttonsOn = true;
                ButtonSpawn();
            }
        }

        if (BoothGlobalObjects.AorR == 'a' || BoothGlobalObjects.AorR == 'r' || !BoothGlobalObjects.IsClipboardOpen)
        {
            ButtonDelete();
            buttonsOn = false;
        }
    }
    void ButtonSpawn()
    {
        Quaternion spawnRotation = Quaternion.identity;

        Aposx = 2.7f;
        Aposy = -3.21f;
        Aposz = 0f;
        Vector3 AcceptPosition = new Vector3(Aposx, Aposy, Aposz);
        accept = Instantiate(ACCEPT, AcceptPosition, spawnRotation);

        Rposx = -2.7f;
        Rposy = -3.21f;
        Rposz = 0f;
        Vector3 RejectPosition = new Vector3(Rposx, Rposy, Rposz);
        reject = Instantiate(REJECT, RejectPosition, spawnRotation);
    }

    void ButtonDelete()
    {
        Destroy(accept);
        Destroy(reject);
    }
}
