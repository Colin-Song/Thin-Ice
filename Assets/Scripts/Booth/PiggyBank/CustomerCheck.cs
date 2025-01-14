using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.SceneManagement;

public class CustomerCheck : MonoBehaviour
{
    public GameObject char1, char2, char3, char4, char5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BoothGlobalObjects.AorR == 'a')
        {
            char1 = GameObject.Find("Cat(Clone)");
            char2 = GameObject.Find("Dog(Clone)");
            char3 = GameObject.Find("Penguin(Clone)");
            char4 = GameObject.Find("Pig(Clone)");
            char5 = GameObject.Find("Bear(Clone)");

            if (char1 != null)
            {
                if (BoothGlobalObjects.KILLER)
                {
                    GlobalObjects.Instance.killerIn = true;
                    SceneManager.LoadScene("MurderEnding");
                }
                else
                {
                    BoothGlobalObjects.customers += 1;
                    GlobalObjects.Instance.money += Random.Range(20, 30);
                }
            }
            else if (char2 != null)
            {
                if (BoothGlobalObjects.KILLER)
                {
                    GlobalObjects.Instance.killerIn = true;
                    SceneManager.LoadScene("MurderEnding");
                }
                else
                {
                    BoothGlobalObjects.customers += 1;
                    GlobalObjects.Instance.money += Random.Range(20, 30);
                }
            }
            else if (char3 != null)
            {
                if (BoothGlobalObjects.KILLER)
                {
                    GlobalObjects.Instance.killerIn = true;
                    SceneManager.LoadScene("MurderEnding");
                }
                else
                {
                    BoothGlobalObjects.customers += 1;
                    GlobalObjects.Instance.money += Random.Range(20, 30);
                }
            }
            else if (char4 != null)
            {
                if (BoothGlobalObjects.KILLER)
                {
                    GlobalObjects.Instance.killerIn = true;
                    SceneManager.LoadScene("MurderEnding");
                }
                else
                {
                    BoothGlobalObjects.customers += 1;
                    GlobalObjects.Instance.money += Random.Range(20, 30);
                }
            }
            else if (char5 != null)
            {
                if (BoothGlobalObjects.KILLER)
                {
                    GlobalObjects.Instance.killerIn = true;
                    SceneManager.LoadScene("MurderEnding");
                }
                else
                {
                    BoothGlobalObjects.customers += 1;
                    GlobalObjects.Instance.money += Random.Range(20, 30);
                }
            }
        }
        else if (BoothGlobalObjects.AorR == 'r')
        {
            char1 = GameObject.Find("Cat(Clone)");
            char2 = GameObject.Find("Dog(Clone)");
            char3 = GameObject.Find("Penguin(Clone)");
            char4 = GameObject.Find("Pig(Clone)");
            char5 = GameObject.Find("Bear(Clone)");

            if (char1 != null)
            {
                if (!BoothGlobalObjects.KILLER)
                {
                    GlobalObjects.Instance.X += 1;
                    if (GlobalObjects.Instance.X >= 3)
                    {
                        SceneManager.LoadScene("RiotEnding");
                    }

                }
                else
                {
                    GlobalObjects.Instance.money += Random.Range(20, 30);
                }
            }
            else if (char2 != null)
            {
                if (!BoothGlobalObjects.KILLER)
                {
                    GlobalObjects.Instance.X += 1;
                    if (GlobalObjects.Instance.X >= 3)
                    {
                        SceneManager.LoadScene("RiotEnding");
                    }
                }
                else
                {
                    GlobalObjects.Instance.money += Random.Range(20, 30);
                }
            }
            else if (char3 != null)
            {
                if (!BoothGlobalObjects.KILLER)
                {
                    GlobalObjects.Instance.X += 1;
                    if (GlobalObjects.Instance.X >= 3)
                    {
                        SceneManager.LoadScene("RiotEnding");
                    }
                }
                else
                {
                    GlobalObjects.Instance.money += Random.Range(20, 30);
                }
            }
            else if (char4 != null)
            {
                if (!BoothGlobalObjects.KILLER)
                {
                    GlobalObjects.Instance.X += 1;
                    if (GlobalObjects.Instance.X >= 3)
                    {
                        SceneManager.LoadScene("RiotEnding");
                    }
                }
                else
                {
                    GlobalObjects.Instance.money += Random.Range(20, 30);
                }
            }
            else if (char5 != null)
            {
                if (!BoothGlobalObjects.KILLER)
                {
                    GlobalObjects.Instance.X += 1;
                    if (GlobalObjects.Instance.X >= 3)
                    {
                        SceneManager.LoadScene("RiotEnding");
                    }
                }
                else
                {
                    GlobalObjects.Instance.money += Random.Range(20, 30);
                }
            }
        }
    }
}
