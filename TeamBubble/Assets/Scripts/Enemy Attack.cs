using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float meleeRange = 1.5f; // Range for melee attacks
    public int meleeDamage = 10; // Damage dealt by melee attacks
    public float attackCooldown = 2f; // Time between attacks
    public float debuffDuration = 3f; // Duration of the movement debuff

    private float attackTimer = 0f; // Timer to track cooldowns

    private void Update()
    {
        // Reduce attack cooldown timer
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        // Perform melee attack if player is in range and attack is ready
        PerformMeleeAttack();
    }

    private void PerformMeleeAttack()
    {
        // Detect the player within melee range
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, meleeRange);
        foreach (var hit in hitPlayers)
        {
            if (hit.CompareTag("Player") && attackTimer <= 0)
            {
                // Apply damage and movement debuff to the player
                PlayerStats playerStats = hit.GetComponent<PlayerStats>();
                PlayerMovement playerMovement = hit.GetComponent<PlayerMovement>();

                if (playerStats != null)
                {
                    playerStats.TakeDamage(meleeDamage);
                    Debug.Log("Enemy hit the player for " + meleeDamage + " damage!");
                }

                if (playerMovement != null)
                {
                    playerMovement.ApplyMovementDebuff(debuffDuration);
                    Debug.Log("Enemy applied movement debuff to the player!");
                }

                // Reset the attack cooldown timer
                attackTimer = attackCooldown;
                break; // Prevent hitting the player multiple times per frame
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the melee attack range in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }
}
