using System.Collections;
using TMPro;
using UnityEngine;

public class MurderEnding : MonoBehaviour
{
    [TextArea(3, 10)]
    public string fullText; // The complete text to display
    [SerializeField]
    private float typeSpeed = 0.05f; // Time between each character

    private TextMeshProUGUI textMeshPro;
    private int currentIndex = 0;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char c in fullText)
        {
            textMeshPro.text += c;
            currentIndex++;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    // Optional: To handle skipping the typing effect when the user clicks
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            textMeshPro.text = fullText;
        }
    }
}
