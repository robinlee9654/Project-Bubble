using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject armorItemPrefab;
    public GameObject staminaItemPrefab;
    public float dropChance = 0.5f;
    public float armorTimeBoost = 5f; // Time boost for armor items
    public float staminaTimeBoost = 10f; // Time boost for stamina items

    public void DropItem()
    {
        if (Random.value <= dropChance)
        {
            GameObject itemToDrop;
            if (Random.value > 0.5f)
            {
                itemToDrop = armorItemPrefab;
                itemToDrop.GetComponent<ItemPickup>().timeBoost = armorTimeBoost;
            }
            else
            {
                itemToDrop = staminaItemPrefab;
                itemToDrop.GetComponent<ItemPickup>().timeBoost = staminaTimeBoost;
            }

            // Instantiate the item
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        DropItem();
    }
}
