using UnityEngine;

public class OilEnemyAttack : MonoBehaviour
{
    public float meleeRange = 2f; // Distance for melee attack
    public int meleeDamage = 10; // Damage dealt by melee attack
    public float debuffDuration = 3f; // Duration of the debuff

    private void Update()
    {
        // Perform melee attack if player is in range
        PerformMeleeAttack();
    }

    private void PerformMeleeAttack()
    {
        // Detect if the player is within melee range and perform attack
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, meleeRange);
        foreach (var hit in hitEnemies)
        {
            if (hit.CompareTag("Player"))
            {
                // Apply movement debuff to player
                PlayerMovement playerMovement = hit.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.ApplyMovementDebuff(debuffDuration);
                    Debug.Log("Small enemy applied movement debuff to player.");
                }

                // Deal damage to player via PlayerStats
                PlayerStats playerStats = hit.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(meleeDamage);
                    Debug.Log("Small enemy performed a melee attack!");
                }
            }
        }
    }
}