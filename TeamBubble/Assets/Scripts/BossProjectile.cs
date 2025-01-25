using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public int damage = 10;
    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime); // Destroy the projectile after a set time
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }

            Destroy(gameObject); // Destroy the projectile on impact
        }
    }
}
