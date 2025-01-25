using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform spawnPoint; // The position to respawn at
    public bool isBossFightCheckpoint = false; // Flag to check if it's a boss level checkpoint

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has reached the checkpoint
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                // Reset the player's stats to full
                playerStats.ResetStats();

                // Optionally, save the checkpoint position for respawn
                GameManager.Instance.SetCheckpoint(spawnPoint.position, isBossFightCheckpoint);

                Debug.Log("Checkpoint reached! Stats reset.");
            }
        }
    }
}
