using UnityEngine;
using TMPro;

public class IDcontentController : MonoBehaviour
{
    public GameObject IDpicture;
    public TextMeshProUGUI IDcontent;
    public static bool openId = false;
    public static bool closeId = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (IDcontent == null)
        {
            Debug.Log("IDcontent is null");
            IDcontent = GameObject.Find("IDContent").GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (openId)
        {
            Debug.Log("Opening ID");
            openContent();
            openId = true;
        }
        else if (closeId)
        {
            IDcontent.enabled = false;

            closeId = true;
        }
    }

    private void openContent(){

        IDpicture.SetActive(true);

        if (BoothGlobalObjects.KILLER)
        {
            int randomIndex = Random.Range(0,3);

            int changeAmount;
            do
            {
                changeAmount = Random.Range(-2, 3); 
                // Range(-2, 3) gives -2, -1, 0, 1, 2
            }
            while (changeAmount == 0);

            string gender = BoothGlobalObjects.GENDER;
            int age = BoothGlobalObjects.AGE;
            int height = BoothGlobalObjects.HEIGHT;

            switch (randomIndex){
                case 0:
                    if (BoothGlobalObjects.GENDER == "Male")
                    {
                        gender = "Female";
                    }
                    else {
                        gender = "Male";
                    }
                    break;
                case 1:
                    age = BoothGlobalObjects.AGE + changeAmount;
                    break;
                case 2:
                    height = BoothGlobalObjects.HEIGHT + changeAmount;
                    break;
            }

            
            IDcontent.text = "Type: " + BoothGlobalObjects.TYPE + "\n" + "Gender:" + gender + "\n" + "Age: " + age + "\n" + "Height: " + height;
            IDcontent.enabled = true;
        }

        else {
            // IDcontent.text = "Hello";
            // IDcontent.text = "Type: " + BoothGlobalObjects.TYPE + "\n" + "Gender:" + BoothGlobalObjects.GENDER + "\n" + "Age: " + BoothGlobalObjects.AGE + "\n" + "Height: " + BoothGlobalObjects.HEIGHT;
            IDcontent.enabled = true;
        }

    }
}
