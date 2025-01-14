using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    private float idposx, idposy, idposz, cbposx, cbposy, cbposz;
    private bool objects;
    private GameObject id, clipboard;
    public GameObject ID, CLIPBOARD;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objects = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BoothGlobalObjects.middle)
        {
            if (BoothGlobalObjects.AorR == 'n')
            {
                
                if (!objects){
                    objects = true;
                    IDSpawn();
                    ClipboardSpawn();
                }
                
            }
        }
        if (BoothGlobalObjects.AorR == 'a' || BoothGlobalObjects.AorR == 'r')
        {
            ObjectsGone();
            objects = false;
        }
    }

    void IDSpawn()
    {
        idposx = -1.46f;
        idposy = -2.4f;
        idposz = 0f;

        Vector3 IDPosition = new Vector3(idposx, idposy, idposz);
        Quaternion spawnRotation = Quaternion.identity;
        id = Instantiate(ID, IDPosition, spawnRotation);
    }

    void ClipboardSpawn()
    {
        cbposx = 1.65f;
        cbposy = -2.4f;
        cbposz = 0f;

        Vector3 CBPosition = new Vector3(cbposx, cbposy, cbposz);
        Quaternion spawnRotation = Quaternion.identity;
        clipboard = Instantiate(CLIPBOARD, CBPosition, spawnRotation);
    }
    void ObjectsGone()
    {
        Destroy(id);
        Destroy(clipboard);
    }
}
