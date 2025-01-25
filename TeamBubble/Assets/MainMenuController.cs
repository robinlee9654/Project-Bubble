using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
 public void OpenLevel()
 {
     SceneManager.LoadScene("What the name in your main scene");
 }
 public void SetRestartLevel()
 {

     SceneManager.LoadScene("What the name in your main scene");
     Time.timeScale = 1f;
 }
}