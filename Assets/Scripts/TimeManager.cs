using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    [Header("Time Settings")]
    [Tooltip("Real-world seconds for 8 AM → 8 PM (12-hour in-game day).")]
    public float realSecondsPerGameDay = 30f; // 30 seconds for demonstration

    // 12 in-game hours (8 AM to 8 PM) = 720 minutes
    private float minutesPerDay = 720f;

    [Header("Current Game Time")]
    public int day = 1;
    private int hour;
    private int minute; // We'll track minutes internally, but won't display them

    [Header("UI References")]
    public TextMeshProUGUI timeDisplay;
    public GameObject dayEndPanel;   
    public Button nextDayButton;  
        
    // >>>  NEW: Add a reference to the IrisOutOverlay <<<
    [Header("Iris Out Overlay")]
    public RectTransform irisOutOverlay;   // The circular overlay's RectTransform
    public float irisOutDuration = 1.5f;   // Seconds to animate the iris out
    public float irisMaxScale = 5f;        // How large we scale the overlay to cover the screen

    // Internal tracking
    private float currentDayTimeInMinutes;
    private bool isDayEnded = false;

    private void Start()
    {
        // Start day at 8:00 AM
        day = 1;
        hour = 8;
        minute = 0;
        currentDayTimeInMinutes = 0f;

        // Hide or disable the dayEndPanel at the start
        if (dayEndPanel != null)
            dayEndPanel.SetActive(false);

        // Hook up the Next Day button
        if (nextDayButton != null)
            nextDayButton.onClick.AddListener(StartNextDay);

        // Ensure the overlay is invisible or scaled to 0 at start
        if (irisOutOverlay != null)
        {
            irisOutOverlay.gameObject.SetActive(false);    // or keep active but set localScale to zero
            irisOutOverlay.localScale = Vector3.zero;
        }
    }

    private void Update()
    {
        if (isDayEnded) return;

        // Advance current day time
        float inGameMinutesPerRealSecond = minutesPerDay / realSecondsPerGameDay;
        currentDayTimeInMinutes += Time.deltaTime * inGameMinutesPerRealSecond;

        // End the day if we exceed 720 in-game minutes
        if (currentDayTimeInMinutes >= minutesPerDay)
        {
            isDayEnded = true;
            // Start the iris-out animation BEFORE showing the day end panel
            StartCoroutine(IrisOutThenEndDay());
        }

        // Convert to hour/minute for 8 AM → 8 PM
        float totalMinutesSince8AM = Mathf.Min(currentDayTimeInMinutes, minutesPerDay);
        float absoluteMinutesOfDay = (8f * 60f) + totalMinutesSince8AM;

        hour = (int)(absoluteMinutesOfDay / 60f) % 24;
        minute = (int)(absoluteMinutesOfDay % 60);

        // Update text (display hour in AM/PM without minutes)
        if (timeDisplay != null)
        {
            bool isAM = (hour < 12);
            int displayHour = hour % 12;
            if (displayHour == 0) displayHour = 12;

            string amPmLabel = isAM ? "AM" : "PM";
            timeDisplay.text = $"Day {day} - {displayHour} {amPmLabel}";
        }
    }

    // ------------------------------------------------
    // Coroutine: Play Iris Out animation, then show panel
    // ------------------------------------------------
    private IEnumerator IrisOutThenEndDay()
    {
        // Activate overlay
        if (irisOutOverlay != null)
        {
            irisOutOverlay.gameObject.SetActive(true);

            // Reset scale to 0 if it isn't already
            irisOutOverlay.localScale = Vector3.zero;

            float timer = 0f;
            while (timer < irisOutDuration)
            {
                timer += Time.deltaTime;
                float t = Mathf.Clamp01(timer / irisOutDuration);
                
                // Scale from 0 to irisMaxScale
                float scaleValue = Mathf.Lerp(0f, irisMaxScale, t);
                irisOutOverlay.localScale = new Vector3(scaleValue, scaleValue, 1f);

                yield return null;
            }
        }

        // After the iris out is complete, show the day-end panel
        if (dayEndPanel != null)
        {
            dayEndPanel.SetActive(true);
        }
    }

    /// <summary>
    /// Called by the "Next Day" button.
    /// Resets time for the new day (8 AM → 8 PM), hides the overlay, hides the panel, and resumes time.
    /// </summary>
    public void StartNextDay()
    {
        day++;

        // Reset day to 8:00 AM
        hour = 8;
        minute = 0;
        currentDayTimeInMinutes = 0f;

        // Hide panel
        if (dayEndPanel != null)
            dayEndPanel.SetActive(false);

        // Reset and hide iris overlay
        if (irisOutOverlay != null)
        {
            irisOutOverlay.localScale = Vector3.zero;
            irisOutOverlay.gameObject.SetActive(false);
        }

        isDayEnded = false;
    }
}
