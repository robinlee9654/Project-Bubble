using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float currentSpeed;
    private bool isDebuffed = false;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        // Get movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized; // Prevent faster diagonal movement
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }

    public void ApplyMovementDebuff(float duration)
    {
        if (!isDebuffed)
        {
            isDebuffed = true;
            currentSpeed = moveSpeed / 2; // Reduce speed by half
            Debug.Log("Movement debuff applied!");
            Invoke(nameof(RemoveMovementDebuff), duration);
        }
    }

    private void RemoveMovementDebuff()
    {
        isDebuffed = false;
        currentSpeed = moveSpeed; // Restore original speed
        Debug.Log("Movement debuff removed!");
    }
}
