using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of enemy movement
    public float detectionRange = 5f; // Range to detect the player
    public float wanderInterval = 2f; // Interval between changing directions

    private Transform player; // Reference to the player
    private Rigidbody2D rb;
    private Vector2 movement;
    private float wanderTimer;
    private Vector2[] directions = new Vector2[]
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
    };

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player
        ChooseNewDirection(); // Start with a random direction
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Follow the player
            movement = GetDirectionTowardsPlayer();
        }
        else
        {
            // Wander around if the player is not in range
            Wander();
        }
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Wander()
    {
        wanderTimer += Time.deltaTime;

        if (wanderTimer >= wanderInterval)
        {
            // Change to a random direction at set intervals
            ChooseNewDirection();
            wanderTimer = 0;
        }
    }

    private void ChooseNewDirection()
    {
        // Pick a random direction (up, down, left, or right)
        movement = directions[Random.Range(0, directions.Length)];
    }

    private Vector2 GetDirectionTowardsPlayer()
    {
        // Determine the direction towards the player (snap to cardinal directions)
        Vector2 directionToPlayer = player.position - transform.position;

        // Snap to the nearest cardinal direction
        if (Mathf.Abs(directionToPlayer.x) > Mathf.Abs(directionToPlayer.y))
        {
            return directionToPlayer.x > 0 ? Vector2.right : Vector2.left;
        }
        else
        {
            return directionToPlayer.y > 0 ? Vector2.up : Vector2.down;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the detection range in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
