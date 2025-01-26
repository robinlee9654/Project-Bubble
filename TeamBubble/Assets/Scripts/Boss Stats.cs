using UnityEngine;

public class BossStats : MonoBehaviour
{
    public int maxHealth = 500; // Maximum health of the boss
    public int currentHealth; // Current health of the boss
    public int phaseThreshold = 50; // Health percentage for phase transitions

    public bool isEnraged = false; // If the boss is enraged (special mode)

    private Animator animator; // To trigger animations
    private BossAi bossAI; // Reference to the BossAI script for behavior changes

    void Start()
    {
        currentHealth = maxHealth; // Set the initial health
        animator = GetComponent<Animator>();
        bossAI = GetComponent<BossAi>(); // Ensure you have the BossAI script attached
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return; // Prevent overkill or redundant logic

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Trigger hit animations
        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }

        // Check for phase transitions
        CheckPhase();

        // Handle boss death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void CheckPhase()
    {
        float healthPercentage = (float)currentHealth / maxHealth * 100f;

        // Enrage or change behavior if below the threshold
        if (!isEnraged && healthPercentage <= phaseThreshold)
        {
            isEnraged = true;
            Debug.Log("Boss has entered Enrage Mode!");
            if (bossAI != null)
            {
                bossAI.EnterEnrageMode();
            }

            // Optional: Trigger enrage animation or effects
            if (animator != null)
            {
                animator.SetTrigger("Enrage");
            }
        }
    }

    private void Die()
    {
        Debug.Log("Boss defeated!");

        // Trigger death animation
        if (animator != null)
        {
            animator.SetTrigger("Death");
        }

        // Disable further actions for the boss
        if (bossAI != null)
        {
            bossAI.enabled = false;
        }

        // Optionally, destroy the boss GameObject after a delay
        Destroy(gameObject, 3f);
    }
}
