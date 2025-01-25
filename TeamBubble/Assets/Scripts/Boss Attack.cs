using UnityEngine;
using System.Collections;


public class BossAttack : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float meleeRange = 3f; // Range for melee attack
    public int meleeDamage = 20;

    public GameObject projectilePrefab; // Projectile prefab
    public Transform projectileSpawnPoint;
    public int projectileCount = 5; // Number of projectiles to fire
    public float projectileSpeed = 10f;

    public float aoeRange = 5f; // Range for AOE attack
    public float aoeDelay = 2f; // Delay before explosion
    public int aoeDamage = 30;
    public GameObject aoeEffectPrefab; // Visual effect for AOE attack

    private float attackCooldown = 2f; // Cooldown between attacks
    private float attackTimer = 0f;

    private void Update()
    {
        // Update attack timer
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            PerformAttack();
            attackTimer = attackCooldown; // Reset cooldown
        }
    }

    private void PerformAttack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= meleeRange)
        {
            MeleeAttack();
        }
        else if (distanceToPlayer > meleeRange && distanceToPlayer <= aoeRange)
        {
            ProjectileBarrage();
        }
        else
        {
            AreaExplosion();
        }
    }

    private void MeleeAttack()
    {
        Debug.Log("Boss performs a melee attack!");
        if (Vector3.Distance(transform.position, player.position) <= meleeRange)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(meleeDamage);
            }
        }
    }

    private void ProjectileBarrage()
    {
        Debug.Log("Boss performs a projectile barrage!");
        for (int i = 0; i < projectileCount; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
            Vector3 direction = (player.position - projectileSpawnPoint.position).normalized;
            projectile.GetComponent<Rigidbody>().linearVelocity = direction * projectileSpeed;
        }
    }

    private void AreaExplosion()
    {
        Debug.Log("Boss performs an area explosion!");
        StartCoroutine(PerformAoeAttack());
    }

    private IEnumerator PerformAoeAttack()
    {
        // Show the AOE effect (e.g., charging animation)
        GameObject aoeEffect = Instantiate(aoeEffectPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(aoeDelay);

        // Apply damage to the player if they're in the area
        if (Vector3.Distance(transform.position, player.position) <= aoeRange)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(aoeDamage);
            }
        }

        Destroy(aoeEffect); // Clean up the AOE effect
    }
}
