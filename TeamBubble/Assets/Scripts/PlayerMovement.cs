using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;

    private float movementDebuffMultiplier = 1f; // Default movement speed is 1 (no debuff)
    private float debuffTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Update debuff timer
        if (debuffTimer > 0)
        {
            debuffTimer -= Time.deltaTime;
            if (debuffTimer <= 0)
            {
                ResetMovementDebuff();
            }
        }

        // Get movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized; // Prevent faster diagonal movement

        // Update animator parameters
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        // Apply movement with debuff multiplier
        rb.MovePosition(rb.position + movement * moveSpeed * movementDebuffMultiplier * Time.fixedDeltaTime);
    }

    // Apply the movement debuff
    public void ApplyMovementDebuff(float debuffDuration)
    {
        movementDebuffMultiplier = 0.5f; // Example: Slow down by 50% during debuff
        debuffTimer = debuffDuration;
        Debug.Log("Movement debuff applied!");
    }

    // Reset movement debuff
    private void ResetMovementDebuff()
    {
        movementDebuffMultiplier = 1f; // Reset to normal speed
        Debug.Log("Movement debuff removed!");
    }
}

