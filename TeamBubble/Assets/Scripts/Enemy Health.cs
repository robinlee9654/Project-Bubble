using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50; // Maximum health for the enemy
    private int currentHealth;

    public GameObject armorDropPrefab; // Prefab for armor item drop
    public GameObject staminaDropPrefab; // Prefab for stamina time item drop
    public float dropChance = 0.5f; // 50% chance to drop an item

    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (animator != null)
        {
            animator.SetTrigger("Hit"); // Trigger hit animation
        }

        Debug.Log($"Enemy took {damage} damage. Remaining health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");

        if (animator != null)
        {
            animator.SetTrigger("Die"); // Trigger death animation
        }

        // Drop item with a chance
        DropItem();

        // Destroy the enemy object after death animation
        Destroy(gameObject, 1.5f); // Adjust the delay to match the animation length
    }

    private void DropItem()
    {
        if (Random.value <= dropChance)
        {
            GameObject itemToDrop = Random.value > 0.5f ? armorDropPrefab : staminaDropPrefab;
            if (itemToDrop != null)
            {
                Instantiate(itemToDrop, transform.position, Quaternion.identity);
                Debug.Log("Dropped an item: " + itemToDrop.name);
            }
        }
    }
}
