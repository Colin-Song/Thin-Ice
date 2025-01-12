using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class OrnamentController : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Initial rotation speed in degrees per second.")]
    public float rotationSpeed = 10f;

    [Tooltip("Amount to increase rotation speed when button is clicked.")]
    public float speedIncrement = 100f;

    [Header("Scene Management")]
    [Tooltip("Name of the scene to switch to.")]
    public string targetSceneName = "Lake";

    // Reference to the UI Buttons
    [Header("UI Elements")]
    [Tooltip("UI Button to increase rotation speed.")]
    public Button spinButton;

    [Tooltip("UI Button to switch scenes.")]
    public Button switchSceneButton; // New Button for switching scenes


    [Tooltip("Reference to the child objects to rotate.")]
    public Transform child1; // Assign via Inspector
    public Transform child2; // Assign via Inspector
    public Transform child3; // Assign via Inspector
    public Transform child4; // Assign via Inspector
    public Transform child5; // Assign via Inspector

    public TMP_Text coinDisplay;
    public TMP_Text warningText;

    void Start()
    {
        // Initialize current rotation speed
        coinDisplay.text = "Coins: " + GlobalObjects.money.ToString();

        // Assign the SpeedUpRotation function to the speedUpButton's onClick event
        if (spinButton != null)
        {
            Debug.Log("Assign listener.");
            spinButton.onClick.AddListener(SpeedUpRotation);
        }
        else
        {
            Debug.LogWarning("Speed Up Button is not assigned in the Inspector.");
        }

        // Assign the SwitchScene function to the switchSceneButton's onClick event
        if (switchSceneButton != null)
        {
            switchSceneButton.onClick.AddListener(SwitchScene);
        }
        else
        {
            Debug.LogWarning("Switch Scene Button is not assigned in the Inspector.");
        }
    }

    void Update()
    {
        // Rotate the ornament around the Z-axis
        child1.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        child2.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        child3.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        child4.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        child5.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar pressed.");
            SpeedUpRotation();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Enter key pressed.");
            SwitchScene();
        }
    }

    /// <summary>
    /// Increases the rotation speed of the ornament.
    /// </summary>
    public void SpeedUpRotation()
    {
        Debug.Log("spin.");
        if (GlobalObjects.money > 0)
        {
            warningText.text = "Not enough coins!";
            warningText.gameObject.SetActive(true);
            return;
        }
        else {
            rotationSpeed += speedIncrement;
            GlobalObjects.money -= 15;
            Debug.Log("Ornament rotation speed increased to: " + rotationSpeed + " degrees/sec.");
            StartCoroutine(SwitchSceneAfterDelay());
        }
        
    }

    /// <summary>
    /// Switches to the specified target scene.
    /// </summary>
    public void SwitchScene()
    {
        SceneManager.LoadScene(targetSceneName);

        
        ShopManagerScript.ifSpinSuccessful = true;
        Debug.Log("Switching to scene: " + targetSceneName);
    }

    /// <summary>
    /// Coroutine that waits for a specified delay before switching scenes.
    /// </summary>
    /// <param name="delay">Time in seconds to wait before switching scenes.</param>
    /// <returns></returns>
    private IEnumerator SwitchSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(targetSceneName);
        ShopManagerScript.ifSpinSuccessful = true;
        Debug.Log("Switching to scene: " + targetSceneName);
    }

}
