using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void OpenLevel1()
    {
        SceneManager.LoadScene("MainScene"); // Replace "MainScene" with your actual scene name
    }

    public void SetRestartLevel()
    {
        SceneManager.LoadScene("MainScene"); // Replace with your scene name
        Time.timeScale = 1f;
    }
}
