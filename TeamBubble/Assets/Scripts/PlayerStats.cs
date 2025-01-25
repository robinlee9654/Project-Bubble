using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxArmor = 100;
    public int maxStamina = 100;
    public float armorDuration = 10f;
    public float staminaRegenRate = 5f;
    public float staminaDepletionRate = 10f;

    public int CurrentArmor { get; private set; }
    public int CurrentStamina { get; private set; }
    public bool IsArmorActive { get; private set; }

    private float armorTimer;

    void Start()
    {
        CurrentArmor = maxArmor;
        CurrentStamina = maxStamina;
        ActivateArmor(); // Start with armor
    }

    void Update()
    {
        // Handle armor timer
        if (IsArmorActive)
        {
            armorTimer -= Time.deltaTime;
            if (armorTimer <= 0)
            {
                DeactivateArmor();
            }
        }

        // Regenerate stamina over time
        if (CurrentStamina < maxStamina)
        {
            CurrentStamina += Mathf.RoundToInt(staminaRegenRate * Time.deltaTime);
            CurrentStamina = Mathf.Clamp(CurrentStamina, 0, maxStamina);
        }

        // Handle stamina depletion (e.g., during running)
        SimulateStaminaDepletion();

        // Check if the player has died
        if (CurrentStamina <= 0)
        {
            // Trigger player death and respawn
            GameManager.Instance.RestartFromCheckpoint(); // Respawn the player at the checkpoint
            Debug.Log("Player died, respawning...");
        }
    }

    private void SimulateStaminaDepletion()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // Simulate running, depletes stamina
        {
            CurrentStamina -= Mathf.RoundToInt(staminaDepletionRate * Time.deltaTime);
            CurrentStamina = Mathf.Clamp(CurrentStamina, 0, maxStamina);
        }
    }

    public void ResetStats()
    {
        CurrentArmor = maxArmor;
        CurrentStamina = maxStamina;
        ActivateArmor(); // Reapply armor if needed
    }

    public void ActivateArmor()
    {
        IsArmorActive = true;
        armorTimer = armorDuration;
    }

    public void DeactivateArmor()
    {
        IsArmorActive = false;
    }

    // Handle taking damage (Now handles damage to stamina)
    public void TakeDamage(int damage)
    {
        if (IsArmorActive)
        {
            // Armor absorbs part of the damage
            int remainingDamage = Mathf.Max(damage - CurrentArmor, 0);
            CurrentArmor = Mathf.Max(CurrentArmor - damage, 0);
            if (CurrentArmor <= 0) DeactivateArmor();

            // If armor breaks, apply the remaining damage to stamina
            if (remainingDamage > 0)
            {
                CurrentStamina -= remainingDamage;
                CurrentStamina = Mathf.Clamp(CurrentStamina, 0, maxStamina);
            }
        }
        else
        {
            // No armor, apply all damage directly to stamina
            CurrentStamina -= damage;
            CurrentStamina = Mathf.Clamp(CurrentStamina, 0, maxStamina);
        }
    }
}
