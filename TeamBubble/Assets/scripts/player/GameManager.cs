using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Vector3 checkpointPosition;
    private bool isInBossFight = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetCheckpoint(Vector3 position, bool bossFight)
    {
        checkpointPosition = position;
        isInBossFight = bossFight;
    }

    public void RestartFromCheckpoint()
    {
        // Optionally, you can restart the level or just teleport the player
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene

        // After reloading, you want to place the player at the checkpoint position with full stats
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // Set the player position to the checkpoint
        player.transform.position = checkpointPosition;

        // Reset player's stats to full (armor, stamina)
        playerStats.ResetStats();

        // Optionally, you can reset the boss fight state here if needed
        if (isInBossFight)
        {
            // Handle boss-specific logic if needed (e.g., resetting the boss fight state)
        }
    }
}
