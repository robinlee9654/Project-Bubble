using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    // Function to load the ending scene after a delay
    public void LoadEndingScene()
    {
        Debug.Log("LoadEndingScene triggered.");  // Debugging line
        Invoke("LoadScene", 2f);  // Add a delay before transitioning to the ending scene
    }

    void LoadScene()
    {
        Debug.Log("Loading Ending Scene...");  // Debugging line
        SceneManager.LoadScene("EndingScene");  // Ensure the scene name matches exactly
    }

    // Function for restarting the game
    public void RestartGame()
    {
        Debug.Log("Restart button clicked!");  // Debugging line
        SceneManager.LoadScene("StartScene");  // Ensure this is the correct scene name
    }
}
