using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerStats playerStats;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerStats = GetComponent<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerStats.TakeDamage(20); // Damage from enemy
        }
        else if (other.CompareTag("ArmorPickup"))
        {
            playerStats.ActivateArmor(); // Activate armor from pickup
            Destroy(other.gameObject); // Remove pickup
        }
    }
}