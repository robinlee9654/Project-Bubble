using UnityEngine;
using TMPro; // Required for TextMeshPro
using System.Collections; // Required for IEnumerator

public class TextBlinker : MonoBehaviour
{
    private TextMeshProUGUI text; // Reference to the TextMeshProUGUI component
    private bool isFading;

    void Start()
    {
        // Get the TextMeshProUGUI component on this GameObject
        text = GetComponent<TextMeshProUGUI>();
        
        if (text == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on the visual cue GameObject.");
        }
        else
        {
            StartCoroutine(Blink()); // Start the blinking coroutine
        }
    }

    IEnumerator Blink()
    {
        while (true) // Infinite loop for blinking
        {
            isFading = !isFading; // Toggle between faded and visible
            text.color = new Color(text.color.r, text.color.g, text.color.b, isFading ? 0.5f : 1f); // Adjust opacity
            yield return new WaitForSeconds(0.5f); // Adjust blink speed
        }
    }
}
