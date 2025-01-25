using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public enum ItemType { Armor, Stamina }
    public ItemType itemType;
    public int value = 20; // Value to add to armor or stamina
    public float timeBoost = 5f; // Time boost to armor or stamina duration

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                if (itemType == ItemType.Armor)
                {
                    playerStats.ExtendArmorTime(timeBoost);
                }
                else if (itemType == ItemType.Stamina)
                {
                    playerStats.ExtendStaminaTime(timeBoost);
                }

                // Destroy the item after being picked up
                Destroy(gameObject);
            }
        }
    }
}
