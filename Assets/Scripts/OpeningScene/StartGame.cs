using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class StartGame : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_InputField playerNameInput;
    public Button startGameButton;
    public TextMeshProUGUI warningText; // Assign in Inspector
    public AudioSource buttonClickSound;

    public GameObject titleContainer;
    public GameObject welcomeContainer;
    public Button switchSceneButton;

    void Start()
    {
        // Add listener to the start button
        startGameButton.onClick.AddListener(GameStart);
        startGameButton.onClick.AddListener(playSound);
        switchSceneButton.onClick.AddListener(() => StartCoroutine(goToBooth()));
        switchSceneButton.onClick.AddListener(playSound);

        // Hide warning text initially
        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }
    }

    void GameStart()
    {
        string playerName = playerNameInput.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            // Show warning message
            if (warningText != null)
            {
                warningText.gameObject.SetActive(true);
                warningText.text = "Your name cannot be empty";
            }
            return;
        }

        if (playerName.Length < 3)
        {
            // Show different warning message
            if (warningText != null)
            {
                warningText.gameObject.SetActive(true);
                warningText.text = "Name must be at least 3 characters long.";
            }
            return;
        }

        // Hide warning message if previously shown
        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }

        // Save the player's name using PlayerPrefs
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save(); // Ensure data is saved immediately

        Debug.Log("Starting game for player: " + playerName);

        welcomeText();
    }

    public void welcomeText()
    {
        titleContainer.SetActive(false);
        welcomeContainer.SetActive(true);
        
    }
    public void playSound()
    {
        buttonClickSound.Play();
    }
    IEnumerator goToBooth()
    {
        buttonClickSound.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Booth");
    }


}
