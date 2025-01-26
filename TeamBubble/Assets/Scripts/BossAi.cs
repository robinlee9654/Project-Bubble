using UnityEngine;

public class BossAi : MonoBehaviour
{
    public float moveSpeed = 3f; // Movement speed
    public float detectionRange = 10f; // Range to detect the player
    public Transform[] patrolPoints; // Points for patrolling
    public float attackCooldown = 2f; // Cooldown between attacks

    private Transform player;
    private int currentPatrolIndex = 0;
    private float attackTimer = 0f;
    private bool isEnraged = false;

    private Animator animator;
    private BossStats bossStats;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        bossStats = GetComponent<BossStats>();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // If the player is in range, chase and attack
            ChasePlayer();
        }
        else
        {
            // Otherwise, patrol between points
            Patrol();
        }

        // Handle attack cooldown
        attackTimer -= Time.deltaTime;
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];
        MoveTowards(targetPoint.position);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }

        if (animator != null)
        {
            animator.SetBool("IsMoving", true);
        }
    }

    private void ChasePlayer()
    {
        MoveTowards(player.position);

        if (attackTimer <= 0f)
        {
            AttackPlayer();
            attackTimer = attackCooldown; // Reset the cooldown
        }

        if (animator != null)
        {
            animator.SetBool("IsMoving", true);
        }
    }

    private void MoveTowards(Vector2 targetPosition)
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.position = newPosition;

        // Update animation direction
        if (animator != null)
        {
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
        }
    }

    private void AttackPlayer()
    {
        // Trigger attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Deal damage to the player
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage(20); // Adjust damage value as needed
            Debug.Log("Boss attacked the player!");
        }

        // Check if the player is dead
        if (player.GetComponent<PlayerStats>().CurrentStamina <= 0)
        {
            TriggerBadEnding();
        }
    }

    public void EnterEnrageMode()
    {
        isEnraged = true;
        moveSpeed *= 1.5f; // Increase speed during enrage
        attackCooldown /= 2f; // Decrease attack cooldown during enrage

        Debug.Log("Boss is enraged!");
    }

    private void TriggerBadEnding()
    {
        Debug.Log("Bad Ending triggered! The boss defeated the player.");
        // Load the bad ending scene or trigger the bad ending event
        UnityEngine.SceneManagement.SceneManager.LoadScene("BadEnding"); // Replace "BadEnding" with your scene name
    }
}
