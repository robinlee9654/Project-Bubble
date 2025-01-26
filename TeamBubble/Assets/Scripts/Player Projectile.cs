using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int damage = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(damage);
            }

            Destroy(gameObject); // Destroy projectile after hitting an enemy
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject); // Destroy projectile if it hits a wall
        }
    }
}