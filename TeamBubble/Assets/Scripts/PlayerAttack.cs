using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // Projectile prefab
    public Transform shootPoint;       // Where the projectile spawns
    public float projectileSpeed = 10f; // Speed of the projectile
    public float fireRate = 0.5f;      // Time between attacks

    private float nextFireTime;        // Timer to limit fire rate
    private Vector2 facingDirection;  // Stores the player's facing direction

    void Update()
    {
        // Update the facing direction based on movement input
        UpdateFacingDirection();

        // Handle shooting
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // Left mouse button
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Update the cooldown timer
        }
    }

    private void UpdateFacingDirection()
    {
        // Get the player's last movement direction from input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Only update facing direction if there's input
        if (horizontal != 0 || vertical != 0)
        {
            facingDirection = new Vector2(horizontal, vertical).normalized;
        }
    }

    private void Shoot()
    {
        if (facingDirection == Vector2.zero) return; // Don't shoot if no direction is set

        // Instantiate the projectile at the shoot point
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        // Apply velocity to the projectile in the facing direction
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = facingDirection * projectileSpeed;
        }

        // Destroy the projectile after some time to avoid clutter
        Destroy(projectile, 3f);

        Debug.Log($"Player fired a projectile in direction: {facingDirection}");
    }
}
