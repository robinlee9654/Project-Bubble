using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour
{
    public GameObject visualCue; // Reference to the "Click to Continue" text

    void Start()
    {
        // Ensure the visual cue is active at the start
        if (visualCue != null)
        {
            visualCue.SetActive(true);
        }
        else
        {
            Debug.LogError("Visual Cue GameObject is not assigned in the Inspector.");
        }
    }

    void Update()
    {
        // Detect mouse click or touch
        if (Input.GetMouseButtonDown(0)) // Left mouse button or screen tap
        {
            if (visualCue != null)
            {
                visualCue.SetActive(false); // Hide the visual cue after clicking
            }
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // Delay the transition by 2 seconds before loading the next scene
        Invoke("LoadScene", 2f);
    }

    void LoadScene()
    {
        // Replace "GameTutorial" with the exact name of your next scene
        SceneManager.LoadScene("GameTutorial"); // Update with the correct scene name for the next scene
    }
}





