using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    [Header("Time Settings")]
    [Tooltip("Real-world seconds for 8 AM → 8 PM (12-hour in-game day).")]
    // <-- Changed the default to 30 seconds
    public float realSecondsPerGameDay = 30f;

    // 12 in-game hours (8 AM to 8 PM) = 720 minutes
    private float minutesPerDay = 720f;

    [Header("Current Game Time")]
    public int day = 1;
    private int hour;
    private int minute; // We'll track minutes internally, but won't display them

    [Header("UI References")]
    public TextMeshProUGUI timeDisplay;     // Reference to the UI TextMeshPro (for time)
    public RectTransform summaryContainer;  // Container for end-of-day summary lines
    public GameObject summaryLinePrefab;    // Prefab for each line in the summary
    public GameObject dayEndPanel;          // Panel shown at the end of each day
    public Button nextDayButton;            // Button to start the next day

    // Internal: how many in-game minutes have passed in the current day
    private float currentDayTimeInMinutes;

    // When the day ends (8:00 PM), we pause time until the user clicks the "Next Day" button
    private bool isDayEnded = false;

    private Animator _animator;

    public string[] dailySummaryLines = new string[5]
    {
        "You collected 10 coins.",
        "You defeated 2 enemies.",
        "You gained 50 XP.",
        "You found 1 rare item.",
        "End of Day results complete."
    };

    private void Start()
    {
        _animator = GameObject.Find("IrisOut").GetComponent<Animator>();
        // Start on Day 1 at 8:00 AM
        day = 1;
        hour = 8;
        minute = 0;
        
        // 8:00 AM corresponds to 0 "day minutes" in our system
        currentDayTimeInMinutes = 0f;

        // Hide the end-of-day panel at the start
        if (dayEndPanel != null) 
            dayEndPanel.SetActive(false);

        // Hook up the "Next Day" button if assigned
        if (nextDayButton != null)
            nextDayButton.onClick.AddListener(StartNextDay);

        IrisOut();
    }

    private void Update()
    {
        // If the day has ended, stop updating time until "Next Day" is clicked
        if (isDayEnded) return;

        // Convert real-time seconds to in-game minutes
        // 30 real seconds => 720 in-game minutes
        float inGameMinutesPerRealSecond = minutesPerDay / realSecondsPerGameDay;

        // Advance current in-game time
        currentDayTimeInMinutes += Time.deltaTime * inGameMinutesPerRealSecond;

        // If we exceed 720 in-game minutes, we've passed 8:00 PM
        if (currentDayTimeInMinutes >= minutesPerDay)
        {
            isDayEnded = true;
            // Show the "Day End" panel
            timeDisplay.gameObject.SetActive(false);
           
            IrisIn();
            IrisOut();
            StartCoroutine(activatePanel());
        }

        // Calculate total minutes since 8 AM
        float totalMinutesSince8AM = Mathf.Min(currentDayTimeInMinutes, minutesPerDay);
        float absoluteMinutesOfDay = (8f * 60f) + totalMinutesSince8AM; 
        // 8 AM => 480 minutes into a normal 24-hr cycle

        // Convert to hour/minute
        hour   = (int)(absoluteMinutesOfDay / 60f) % 24;
        minute = (int)(absoluteMinutesOfDay % 60);  

        // Update the UI text (without minutes, as requested)
        if (timeDisplay != null)
        {
            // Convert 24-hour to 12-hour format
            bool isAM       = (hour < 12);
            int displayHour = hour % 12;
            if (displayHour == 0) displayHour = 12; // 12-hour clock "0" => "12"

            string amPmLabel = isAM ? "AM" : "PM";
            timeDisplay.text = $"Day {day} - {displayHour} {amPmLabel}";
        }
    }

    /// <summary>
    /// Called by the "Next Day" button. 
    /// Resets time for the new day (8 AM → 8 PM), hides the panel, and resumes time.
    /// </summary>
    public void StartNextDay()
    {
        // Increment day counter
        day++;

        // Reset to 8:00 AM
        hour = 8;
        minute = 0;
        currentDayTimeInMinutes = 0f; 
        timeDisplay.gameObject.SetActive(true);
        
        // Hide the "Day End" panel
        IrisIn();
        IrisOut();
        StartCoroutine(deactivatePanel());
        isDayEnded = false;
    }

    private IEnumerator activatePanel()
    {
        yield return new WaitForSeconds(1f);
        dayEndPanel.SetActive(true);
        ShowDayEndSummary();
    }

    private IEnumerator deactivatePanel()
    {
        yield return new WaitForSeconds(1f);
        dayEndPanel.SetActive(false);
    }

    public void IrisOut()
    {
        _animator.SetTrigger("Out");
    }

    public void IrisIn()
    {
        _animator.SetTrigger("In");
    }

    private void ShowDayEndSummary()
    {
        if (dayEndPanel != null)
        {
            

            // Clear any existing summary lines in the container
            foreach (Transform child in summaryContainer)
            {
                if (child.name == "nextDayButton") continue;
                Destroy(child.gameObject);
            }
            dayEndPanel.SetActive(true);
            // Start displaying the summary lines
            StartCoroutine(DisplaySummaryLines());
        }
    }

    private IEnumerator DisplaySummaryLines()
    {
        for (int i = 0; i < dailySummaryLines.Length; i++)
        {
            // Instantiate the prefab for each line
            GameObject newLine = Instantiate(summaryLinePrefab, summaryContainer);

            

            // Update the text of the new line
            TextMeshProUGUI textComponent = newLine.GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = dailySummaryLines[i];
            }

            // Optional: Customize the image background if needed
            Image backgroundImage = newLine.GetComponent<Image>();
            if (backgroundImage != null)
            {
                // Example: Change the sprite/color dynamically if desired
                // backgroundImage.sprite = someCustomSprite;
                // backgroundImage.color = new Color(1, 1, 1, 0.5f); // Semi-transparent white
            }

            // Wait before displaying the next line
            yield return new WaitForSeconds(1f);

            newLine.SetActive(true);
        }
    }

}