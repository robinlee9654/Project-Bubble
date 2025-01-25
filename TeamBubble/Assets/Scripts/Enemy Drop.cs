using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject armorItemPrefab; // Assign in the inspector
    public GameObject staminaItemPrefab; // Assign in the inspector
    public float dropChance = 0.7f; // 50% chance to drop an item

    public void DropItem()
    {
        if (Random.value <= dropChance)
        {
            // Randomly decide which item to drop
            GameObject itemToDrop = Random.value > 0.5f ? armorItemPrefab : staminaItemPrefab;

            // Instantiate the item at the enemy's position
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        DropItem();
    }
}

