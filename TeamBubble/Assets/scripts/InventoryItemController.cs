using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public Item item;
    public Button RemoveButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveItem(){
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);    
    }

    public void AddItem(Item NewItem){
        item = NewItem;
    }
}
