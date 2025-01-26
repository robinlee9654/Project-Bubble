using UnityEngine;
using UnityEngine.SceneManagement;  // Ensure you're using the correct namespace for SceneManager

public class MainMenuController : MonoBehaviour
{
    // This method is for starting the game and loading the main game scene
    public void OpenLevel()
    {
        // Replace "CutScene1" with the name of your temporary scene
        SceneManager.LoadScene("CutScene1");  // Now it loads the CutScene1 scene for testing
    }

    // This method can be used for restarting the game (optional, if needed)
    public void SetRestartLevel()
    {
        SceneManager.LoadScene("CutScene1");  // Replace "CutScene1" with the actual name of your game scene
        Time.timeScale = 1f;  // Resets the game speed (useful for pausing and resuming)
    }

    // This method is for quitting the game
    public void QuitGame()
    {
        Application.Quit();  // This will quit the game in the built version

        // If you are testing in Unity Editor, uncomment this line to stop play mode:
        // UnityEditor.EditorApplication.isPlaying = false;  // This stops the game in the Unity Editor (only works while testing)
    }
}
